using NutritionalCalculator.Classes.Interfaces;
using NutritionalCalculator.Model.Entities.Db;

namespace NutritionalCalculator.Unit.Test.Mocks
{
    public class RolesMock : IRoles
    {
        public UsersInRoles AssingRoleToUser(int roleId, string userId)
        {
            return new UsersInRoles()
            {
                RoleId = roleId,
                UserId = userId
            };
        }
    }
}
