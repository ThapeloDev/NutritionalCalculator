using Microsoft.AspNetCore.Mvc;
using NutritionalCalculator.Model.Entities.Db;
using NutritionalCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionalCalculator.Classes
{
    public interface IToken
    {
        TokenModel Get(UserData model);
    }
}
