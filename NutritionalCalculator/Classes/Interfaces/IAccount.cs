using Microsoft.AspNetCore.Mvc;
using NutritionalCalculator.Model.Entities;
using NutritionalCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionalCalculator.Classes
{
    public interface IAccount
    {
        AccountManagerResponse CreateUser(EditedUser model);
        AccountManagerResponse Login(LoginModel model);
        bool CheckAvailability(string value);
    }
}
