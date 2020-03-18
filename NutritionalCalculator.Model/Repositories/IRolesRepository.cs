using NutritionalCalculator.Model.Entities.Db;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionalCalculator.Model.Repositories
{
    public interface IRolesRepository : IModelRepository<Roles>
    {
        Roles GetByRoleId(int Roleid);
    }
}
