using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NutritionalCalculator.Unit.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Text;
using NutritionalCalculator.Classes;
using NutritionalCalculator.Model.Entities.Db;
using Microsoft.AspNetCore.Mvc;
using NutritionalCalculator.Model;
using NutritionalCalculator.Models;

namespace NutritionalCalculator.Unit.Test.Api.Classes
{
    [TestClass]
    public class TokenTests
    {
        [TestMethod]
        public void Get_return_ok_test()
        {
            IConfiguration configuration = new ConfigurationMock();
            IUnitOfWork unitOfWork = new UnitOfWorkMock();
            IToken token = new Token(configuration, unitOfWork);
            UserData user = new UserData()
            {
                Id = "IdTest",
                UserName = "UserNameTest",
                FirstName = "First name test",
                LastName = "Last name test",
                Email = "email@test"
            };
            TokenModel response = token.Get(user);

            Assert.IsTrue(response.Value != null);
        }
    }
}
