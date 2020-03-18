using NutritionalCalculator.Model.Entities.Db;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionalCalculator.Model.Repositories
{
    class RolesRepository : ModelRepository<Roles>, IRolesRepository
    {
        public RolesRepository(IDbContext dbContext) : base(dbContext)
        {
        }
        public Roles GetByRoleId(int roleId) => (from role in _context.Roles
                                                 where role.Id == roleId
                                                 select role).FirstOrDefault();
    }
}
