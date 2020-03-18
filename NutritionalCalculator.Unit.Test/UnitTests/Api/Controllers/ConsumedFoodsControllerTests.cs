using Microsoft.VisualStudio.TestTools.UnitTesting;
using NutritionalCalculator.Controllers;
using System;
using NutritionalCalculator.Unit.Test.Mocks;
using Microsoft.AspNetCore.Mvc;
using NutritionalCalculator.Classes.Interfaces;
using ConsumedFoodsModel = NutritionalCalculator.Model.Entities.Db.ConsumedFoods;
using NutritionalCalculator.Classes;

namespace NutritionalCalculator.Unit.Test.Api.Controllers
{
    [TestClass]
    public class ConsumedFoodsControllerTests
    {
        const bool throwException = true;
        const bool doNotThrowException = false; 

        [TestMethod]
        public void GetByUser_retur_ok_test()
        {
            ConsumedFoodsController controller = GetController(doNotThrowException);
            var response = controller.GetByUser("RegisteredUserId").GetType().Name;
            Assert.AreEqual(response, "OkObjectResult");
        }

        [TestMethod]
        public void GetByUser_catch_exception()
        {
            ConsumedFoodsController controller = GetController(throwException);
            var response = controller.GetByUser("RegisteredUserId") as BadRequestObjectResult;
            var message = response.Value.GetType().Name;
            Assert.AreEqual(message, "Exception");
        }

        [TestMethod]
        public void Create_return_ok_test()
        {
            ConsumedFoodsController controller = GetController(doNotThrowException);
            var response = controller.Create(GetConsumedFoods()).GetType().Name;
            Assert.AreEqual(response, "OkObjectResult");
        }
        
        [TestMethod]
        public void Create_catch_exception()
        {
            ConsumedFoodsController controller = GetController(throwException);
            var response = controller.Create(GetConsumedFoods()) as ObjectResult;
            var message = response.Value.GetType().Name;
            Assert.AreEqual(message, "Exception");
        }

        [TestMethod]
        public void Update_return_ok_test()
        {
            ConsumedFoodsController controller = GetController(doNotThrowException);
            ConsumedFoodsModel consumedFood = GetConsumedFoods();
            consumedFood.IdFood = "Registered_Test_Food";
            var response = controller.Update(consumedFood).GetType().Name;
            Assert.AreEqual(response, "OkObjectResult");
        }

        [TestMethod]
        public void Update_catch_exception_test()
        {
            ConsumedFoodsController controller = GetController(throwException);
            var response = controller.Update(GetConsumedFoods()) as BadRequestObjectResult;
            var message = response.Value.GetType().Name;
            Assert.AreEqual(message, "Exception");
        }

        [TestMethod]
        public void Delete_return_ok_test()
        {
            ConsumedFoodsController controller = GetController(doNotThrowException);
            ConsumedFoodsModel consumedFood = GetConsumedFoods();
            consumedFood.IdFood = "Registered_test_food";
            var response = controller.Delete(consumedFood).GetType().Name;
            Assert.AreEqual(response, "OkObjectResult");
        }

        [TestMethod]
        public void Delete_catch_exception_test()
        {
            ConsumedFoodsController controller = GetController(throwException);
            var response = controller.Delete(GetConsumedFoods()) as BadRequestObjectResult;
            var message = response.Value.GetType().Name;
            Assert.AreEqual(message, "Exception");
        }

        private ConsumedFoodsController GetController(bool exception)
        {
            IConsumedFoods consumedFoodsManager = new ConsumedFoodsMock(exception);
            IResponseHandler responseHandler = new ResponseHandler();
            return new ConsumedFoodsController(consumedFoodsManager, responseHandler);
        }

        private ConsumedFoodsModel GetConsumedFoods()
        {
            return new ConsumedFoodsModel()
            {
                IdUser = "User_test",
                Date = new DateTime(2019, 01, 01),
                NumberOfPlate = 1,
                IdFood = "Test_Food",
                MassConsumedInGr = 100
            };
        }
    }
}
