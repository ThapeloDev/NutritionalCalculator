using NutritionalCalculator.Model.Entities;
using NutritionalCalculator.Model.Entities.Db;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionalCalculator.Model.Repositories
{
    public interface IUsersRepository : IModelRepository<Users>
    {
        Users GetUserById(string id);
        Users GetUserByUserName(string userName);
        Users GetUserByEmail(string email);
    }
}
