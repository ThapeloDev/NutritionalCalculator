using NutritionalCalculator.Model.Entities.Db;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace NutritionalCalculator.Model.Repositories
{
    public class UsersInRolesRepository : ModelRepository<UsersInRoles>, IUsersInRolesRepository
    {
        public UsersInRolesRepository(IDbContext dbContext) : base(dbContext)
        {

        }

        public List<Roles> GetByUserId(string userId) => (from role in _context.Roles
                                                          join usersInRoles in _context.UsersInRoles on role.Id equals usersInRoles.RoleId
                                                          where usersInRoles.UserId == userId
                                                          select role).ToList();
        public UsersInRoles GetByUserAndRoleId(string userId, int RoleId) => (from userInRole in _context.UsersInRoles
                                                                              where userInRole.UserId == userId &&
                                                                              userInRole.RoleId == RoleId
                                                                              select userInRole).FirstOrDefault();
    }
}
