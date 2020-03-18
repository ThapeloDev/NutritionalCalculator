using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NutritionalCalculator.Classes;
using NutritionalCalculator.Classes.Interfaces;
using NutritionalCalculator.Controllers;
using NutritionalCalculator.Model.Entities;
using NutritionalCalculator.Unit.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalCalculator.Unit.Test.Api.Controllers
{
    [TestClass]
    public class AccountControllerTests
    {
        private const bool throwException = true;
        private const bool doNotThrowException = false;
        private IResponseHandler responseHandler = new ResponseHandler();

        [TestMethod]
        public void Test_Account_Create_return_Ok()
        {
            IAccount _account = new AccountMock(doNotThrowException);
            EditedUser model = CorrectUser();
            var controller = new AccountController(_account, responseHandler);
            var result = controller.CreateUser(model).GetType().Name;
            Assert.AreEqual("OkObjectResult", result);
        }

        private EditedUser CorrectUser()
        {
            return new EditedUser()
            {
                UserName = "UserNameTest",
                Email = "email@nutritionalcalculator.com",
                Password = "P@ssw0rd"
            };
        }

        [TestMethod]
        public void Test_Account_Create_return_Bad()
        {
            IAccount _account = new AccountMock(doNotThrowException);
            EditedUser model = IncorrectUser();
            var controller = new AccountController(_account, responseHandler);
            var result = controller.CreateUser(model).GetType().Name;
            Assert.IsTrue(result.Contains("BadRequestObjectResult"));
        }

        private EditedUser IncorrectUser()
        {
            return new EditedUser()
            {
                Email = "wrongEmail@nutritionalcalculator.com",
                Password = "invalid"
            };
        }

        [TestMethod]
        public void Create_catch_exception_test()
        {
            IAccount _account = new AccountMock(throwException);
            EditedUser model = CorrectUser();
            var controller = new AccountController(_account, responseHandler);
            var result = controller.CreateUser(model) as BadRequestObjectResult;
            var message = result.Value.GetType().Name;
            Assert.AreEqual(message, "Exception");
        }

        [TestMethod]
        public void Test_Account_Login_return_Ok()
        {
            IAccount _account = new AccountMock(doNotThrowException);
            LoginModel model = CorrectUserFromLogin();
            var controller = new AccountController(_account, responseHandler);
            var result = controller.Login(model).GetType().Name;
            Assert.AreEqual("OkObjectResult", result);
        }
        private LoginModel CorrectUserFromLogin()
        {
            return new LoginModel()
            {
                UserName = "UserNameTest",
                Password = "P@ssw0rd"
            };
        }

        [TestMethod]
        public void Test_Account_Login_return_Bad()
        {
            IAccount _account = new AccountMock(doNotThrowException);
            LoginModel model = IncorrectUserFromLogin();
            var controller = new AccountController(_account, responseHandler);
            var result = controller.Login(model).GetType().Name;
            Assert.IsTrue(result.Contains("BadRequestObjectResult"));
        }
        private LoginModel IncorrectUserFromLogin()
        {
            return new LoginModel()
            {
                UserName = "wrongEmail@nutritionalcalculator.com",
                Password = "invalid"
            };
        }

        [TestMethod]
        public void Login_catch_exception_test()
        {
            IAccount _account = new AccountMock(throwException);
            LoginModel model = CorrectUserFromLogin();
            var controller = new AccountController(_account, responseHandler);
            var result = controller.Login(model) as BadRequestObjectResult;
            var message = result.Value.GetType().Name;
            Assert.AreEqual(message, "Exception");
        }

        [TestMethod]
        public void CheckAvailability_return_Ok()
        {
            IAccount _account = new AccountMock(doNotThrowException);
            var controller = new AccountController(_account, responseHandler);
            var response = controller.CheckAvailability("UserValid") as OkObjectResult;
            Assert.AreEqual(response.Value, true);
        }

        [TestMethod]
        public void CheckAvailability_return_Bad()
        {
            IAccount _account = new AccountMock(doNotThrowException);
            var controller = new AccountController(_account, responseHandler);
            var response = controller.CheckAvailability("InvalidUser") as OkObjectResult;
            Assert.AreEqual(response.Value, false);
        }

        [TestMethod]
        public void CheckAvailability_catch_exception()
        {
            IAccount _account = new AccountMock(throwException);
            var controller = new AccountController(_account, responseHandler);
            var result = controller.CheckAvailability("UserName") as BadRequestObjectResult;
            var message = result.Value.GetType().Name;
            Assert.AreEqual(message, "Exception");
        }

    }
}
