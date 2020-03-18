using NutritionalCalculator.Classes.Interfaces;
using NutritionalCalculator.Model;
using NutritionalCalculator.Model.Entities.Db;
using System;
using RolesModel = NutritionalCalculator.Model.Entities.Db.Roles;

namespace NutritionalCalculator.Classes
{
    public class Roles : IRoles
    {
        private IUnitOfWork _unitOfWork;
        private UsersInRoles newUserInRole;
        public Roles(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            newUserInRole = new UsersInRoles();
        }

        public UsersInRoles AssingRoleToUser(int roleId, string userId)
        {
            SetNewUserInRole(userId, roleId);
            validateNewUserInRole(newUserInRole);
            return AddUserInRole(newUserInRole);
        }

        private void SetNewUserInRole(string userId, int roleId)
        {
            newUserInRole.UserId = userId;
            newUserInRole.RoleId = roleId;         
        }

        private void validateNewUserInRole(UsersInRoles newUserInRole)
        {
            if ((_unitOfWork.Users.GetUserById(newUserInRole.UserId) == null) || (_unitOfWork.Roles.GetByRoleId(newUserInRole.RoleId) == null) || (_unitOfWork.UsersInRoles.GetByUserAndRoleId(newUserInRole.UserId, newUserInRole.RoleId) != null))
            {
                throw new Exception();
            }   
        }

        private UsersInRoles AddUserInRole(UsersInRoles userInRole)
        {
            userInRole = _unitOfWork.UsersInRoles.Add(userInRole);
            _unitOfWork.commit();
            return userInRole;
        }
    }
}
