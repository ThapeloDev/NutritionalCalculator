using NutritionalCalculator.Model.Entities.Db;
using NutritionalCalculator.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionalCalculator.Unit.Test.Mocks
{
    public class RolesRepositoryMock : IRolesRepository
    {
        public Roles Add(Roles entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Roles entity)
        {
            throw new NotImplementedException();
        }

        public List<Roles> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public Roles GetByRoleId(int roleId)
        {
            Roles response = null;
            if(roleId == 0)
            {
                response = new Roles()
                {
                    Id = roleId,
                    RoleName = "Role test"
                };
            }
            return response;
        }

        public void update(Roles entity)
        {
            throw new NotImplementedException();
        }
    }
}
