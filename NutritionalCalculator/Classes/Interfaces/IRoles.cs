using NutritionalCalculator.Model.Entities.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionalCalculator.Classes.Interfaces
{
    public interface IRoles
    {
        UsersInRoles AssingRoleToUser(int roleId, string userId);
    }
}
