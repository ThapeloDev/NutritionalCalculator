using NutritionalCalculator.Model.Entities.Db;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionalCalculator.Model.Repositories
{
    public interface IUsersInRolesRepository : IModelRepository<UsersInRoles>
    {
        List<Roles> GetByUserId(string userId);
        UsersInRoles GetByUserAndRoleId(string userId, int RoleId);
    }
}
