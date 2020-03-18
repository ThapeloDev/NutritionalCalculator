using Microsoft.AspNetCore.Mvc;
using NutritionalCalculator.Classes;
using NutritionalCalculator.Model.Entities.Db;
using NutritionalCalculator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionalCalculator.Unit.Test.Mocks
{
    class TokenMock : Controller, IToken
    {
        public TokenModel Get(UserData model)
        {
            return new TokenModel()
            {
                Value = "Token_generated"
            };
        }
    }
}
