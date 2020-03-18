using Microsoft.AspNetCore.Identity;
using NutritionalCalculator.Model.Entities;
using NutritionalCalculator.Model.Entities.Db;
using NutritionalCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionalCalculator.Classes
{
    public interface IUserManager
    {
        UserResponse Create(EditedUser model);
        Users GetByUserName(string userName);
        Users GetByEmail(string email);
    }
}
