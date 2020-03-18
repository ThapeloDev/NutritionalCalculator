using NutritionalCalculator.Classes.Interfaces;
using NutritionalCalculator.Classes.StaticClasses;
using NutritionalCalculator.Model;
using NutritionalCalculator.Model.Entities;
using NutritionalCalculator.Model.Entities.Db;
using NutritionalCalculator.Models;
using System;

namespace NutritionalCalculator.Classes
{
    public class UserManager : IUserManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private IRoles _roles;
        private UserResponse response = new UserResponse();
        public UserManager(IUnitOfWork unitOfWork, IRoles roles)
        {
            _unitOfWork = unitOfWork;
            _roles = roles;
            response.IsValid = true;
        }

        public Users GetByUserName(string userName)
        {
            return _unitOfWork.Users.GetUserByUserName(userName);
        }

        public Users GetByEmail(string email)
        {
            return _unitOfWork.Users.GetUserByEmail(email);
        }

        public UserResponse Create(EditedUser model)
        {
            NonNullParametersChecker.checkObjectTypeParameter(model);   
            ValidateNewUser(model);
            ProcessRequest(model);
            
            return response;
        }
        private void ValidateNewUser(EditedUser newUser)
        {
            ValidateNewUserName(newUser.UserName);
            ValidateNewUserEmail(newUser.Email);
        }
        private void ValidateNewUserName(string userName)
        {
            if(_unitOfWork.Users.GetUserByUserName(userName) != null)
            {
                response.IsValid = false;
                response.StatusCode = 400;
            }
        }
        private void ValidateNewUserEmail(string email)
        {
            if(_unitOfWork.Users.GetUserByEmail(email) != null) {
                response.IsValid = false;
                response.StatusCode = 400;
            }
        }
        private void ProcessRequest(EditedUser model)
        {
            if (response.IsValid)
            {
                Users user = SetUserModel(model);
                response.User = _unitOfWork.Users.Add(user);
                _unitOfWork.commit();
            }
        }

        private Users SetUserModel(EditedUser model) => new Users()
        {
            Id = GenerateId(),
            UserName = model.UserName,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            PasswordHash = PasswordHash.GetPasswordHash(model.Password)
        };
        private string GenerateId()
        {
            string id = Guid.NewGuid().ToString();
            while (_unitOfWork.Users.GetUserById(id) != null)
            {
                id = Guid.NewGuid().ToString();
            }
            return id;
        }
        private void AssingRoleToUser ()
        {
            if (response.IsValid)
            {
                _roles.AssingRoleToUser(0, response.User.Id);
            }
        }
    }
}
