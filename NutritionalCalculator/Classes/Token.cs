using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NutritionalCalculator.Model;
using NutritionalCalculator.Model.Entities.Db;
using NutritionalCalculator.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using RolesModel = NutritionalCalculator.Model.Entities.Db.Roles;

namespace NutritionalCalculator.Classes
{
    public class Token : IToken
    {
        private readonly IConfiguration _configuration;
        private IUnitOfWork _unitOfWork;
        private List<Claim> claims;
        private TokenModel tokenModel;
        public Token(IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            tokenModel = new TokenModel();
        }
        public TokenModel Get(UserData model)
        {
            CreateToken(model);
            return tokenModel;
        }

        private void CreateToken(UserData model)
        {
            ConfigureClaims(model);
            var prueba = _configuration["UserTokenKey"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["UserTokenKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(5);
            JwtSecurityToken token = ConfigureToken(creds, expiration);
            GenerateToken(token, expiration);
        }

        private void ConfigureClaims(UserData model)
        {
            claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, model.Id),
                new Claim(JwtRegisteredClaimNames.Email, model.Email)
            };
            GetUserRoles(model.Id);
        }
        private void GetUserRoles(string userId)
        {
            List<RolesModel> userRoles = _unitOfWork.UsersInRoles.GetByUserId(userId);
            AssingRoleIfUserNotHave(userRoles, userId);
            SetRolesClaims(userRoles);
        }

        private void AssingRoleIfUserNotHave(List<RolesModel> userRoles, string userId)
        {
            if(userRoles == null || userRoles.Count == 0)
            {
                UsersInRoles roleToAssing = new UsersInRoles()
                {
                    UserId = userId,
                    RoleId = 0
                };
                _unitOfWork.UsersInRoles.Add(roleToAssing);
                _unitOfWork.commit();
            }
        }

        private void SetRolesClaims(List<RolesModel> userRoles)
        {
            foreach (RolesModel role in userRoles)
            {
                claims.Add(new Claim(role.RoleName, role.RoleName));
            }

        }

        private JwtSecurityToken ConfigureToken(SigningCredentials creds, DateTime expiration)
        {
            return new JwtSecurityToken(
                    claims: claims,
                    expires: expiration,
                    signingCredentials: creds
                );
        }

        private void GenerateToken(JwtSecurityToken token, DateTime expiration)
        {
            tokenModel.Value = new JwtSecurityTokenHandler().WriteToken(token);
            tokenModel.Expiration = expiration;
        }
    }
}
