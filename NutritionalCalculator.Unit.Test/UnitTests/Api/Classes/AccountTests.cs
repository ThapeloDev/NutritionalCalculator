using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NutritionalCalculator.Classes;
using NutritionalCalculator.Model;
using NutritionalCalculator.Model.Entities;
using NutritionalCalculator.Model.Entities.Db;
using NutritionalCalculator.Models;
using NutritionalCalculator.Unit.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionalCalculator.Unit.Test.Api.Classes
{
    [TestClass]
    public class AccountTests
    {
        private IUserManager userManager = new UserManagerMock();
        private IToken token = new TokenMock();
        [TestMethod]
        public void Test_CreateUser_return_ok()
        {
            EditedUser user = UserValid();
            Account account = new Account(userManager, token);
            AccountManagerResponse response = account.CreateUser(user);
            Assert.IsTrue(response.IsValid);
        }

        private EditedUser UserValid()
        {
            var user = User();
            user.UserName = "UserNameTestValid";
            return user;
        }
        private EditedUser User()
        {
            return new EditedUser()
            {
                UserName = "UserNameTest",
                FirstName = "First name test",
                LastName = "Last name test",
                Email = "email@test",
                Password = "passwordTest"
            };
        }

        [TestMethod]
        public void Test_CreateUser_bad()
        {
            EditedUser user = User();
            Account account = new Account(userManager, token);
            AccountManagerResponse response = account.CreateUser(user);
            Assert.IsFalse(response.IsValid);
            Assert.AreEqual(response.StatusCode, 400);
        }

        [TestMethod]
        public void Test_Login_ok()
        {
            LoginModel loginCredentials = Login_Credentials_Ok_Test();
            Account account = new Account(userManager, token);
            AccountManagerResponse response = account.Login(loginCredentials);
            Assert.IsTrue(response.IsValid);
        }
        private LoginModel Login_Credentials_Ok_Test()
        {
            return new LoginModel()
            {
                UserName = "RegisteredUser",
                Password = "password"
            };
        }

        [TestMethod]
        public void Test_Login_credentials_bad_test()
        {
            LoginModel loginCredentials = LoginCredentials_bad();
            Account account = new Account(userManager, token);
            AccountManagerResponse response = account.Login(loginCredentials);
            Assert.IsFalse(response.IsValid);
            Assert.AreEqual(response.StatusCode, 400);
        }

        private LoginModel LoginCredentials_bad()
        {
            return new LoginModel()
            {
                UserName = "UserNameTest",
                Password = "passwordTest"
            };
        }

        [TestMethod]
        public void checkAvailability_return_true()
        {
            Account account = new Account(userManager, token);
            bool response = account.CheckAvailability("RegisteredUser");
            Assert.IsTrue(response);
        }

        [TestMethod]
        public void CheckAvailability_return_false()
        {
            Account account = new Account(userManager, token);
            bool response = account.CheckAvailability("IvalidUser");
            Assert.IsFalse(response);
        }
    }
}
