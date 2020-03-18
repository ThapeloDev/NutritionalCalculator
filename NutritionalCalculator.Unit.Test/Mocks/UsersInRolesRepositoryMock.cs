using NutritionalCalculator.Model.Entities.Db;
using NutritionalCalculator.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionalCalculator.Unit.Test.Mocks
{
    class UsersInRolesRepositoryMock : IUsersInRolesRepository
    {
        public UsersInRoles Add(UsersInRoles entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(UsersInRoles entity)
        {
            throw new NotImplementedException();
        }

        public List<UsersInRoles> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public List<Roles> GetByUserId(string userId)
        {
            List<Roles> response = null;
            if(userId == "IdTest")
            {
                response = new List<Roles>
                {
                    new Roles ()
                    {
                        Id = 1,
                        RoleName = "RoleTest"
                    }
                };
            }
            return response;
        }

        public UsersInRoles GetByUserAndRoleId(string userId, int RoleId)
        {
            return new UsersInRoles()
            {
                UserId = userId,
                RoleId = RoleId
            };
        }

        public void update(UsersInRoles entity)
        {
            throw new NotImplementedException();
        }
    }
}
