using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NutritionalCalculator.Classes;
using NutritionalCalculator.Classes.Interfaces;
using NutritionalCalculator.Controllers;
using NutritionalCalculator.Models;
using NutritionalCalculator.Unit.Test.Mocks;
using FoodsModel = NutritionalCalculator.Model.Entities.Db.Foods;

namespace NutritionalCalculator.Unit.Test.Api.Controllers
{
    [TestClass]
    public class FoodsControllerTests
    {
        const bool throwException = true;
        const bool doNotThrowException = false;

        [TestMethod]
        public void GetAll_return_all_categories()
        {
            FoodsController controller = GetController(doNotThrowException);
            var result = controller.GetAll() as OkObjectResult;
            var value = result.Value as FoodsResponse;
            Assert.AreEqual(value.Foods.Count, 2);
        }

        [TestMethod]
        public void GetAll_catch_exception()
        {
            FoodsController controller = GetController(throwException);
            var result = controller.GetAll() as BadRequestObjectResult;
            var message = result.Value.GetType().Name;
            Assert.AreEqual(message, "Exception");
        }

        [TestMethod]
        public void GetById_return_food ()
        {
            FoodsController controller = GetController(doNotThrowException);
            var result = controller.GetById("id_test_food") as OkObjectResult;
            FoodsResponse response = result.Value as FoodsResponse;
            Assert.IsNotNull(response.Foods[0]);
        }

        [TestMethod]
        public void GetById_catch_exception()
        {
            FoodsController controller = GetController(throwException);
            var result = controller.GetById("id_test_food") as BadRequestObjectResult;
            var message = result.Value.GetType().Name;
            Assert.AreEqual(message, "Exception");
        }

        [TestMethod]
        public void GetByName_return_food ()
        {

            FoodsController controller = GetController(doNotThrowException);
            var result = controller.GetByName("test_food_name") as OkObjectResult;
            FoodsResponse response = result.Value as FoodsResponse;
            Assert.IsNotNull(response.Foods[0]);
        }

        [TestMethod]
        public void GetByName_catch_exception()
        {
            FoodsController controller = GetController(throwException);
            var result = controller.GetByName("test_food_name") as BadRequestObjectResult;
            var message = result.Value.GetType().Name;
            Assert.AreEqual(message, "Exception");
        }

        [TestMethod]
        public void CreateFood_return_ok()
        {
            FoodsController controller = GetController(doNotThrowException);
            EditedFood food = GetFood();
            var response = controller.CreateFood(food);
            Assert.AreEqual("OkObjectResult", response.GetType().Name);
        }

        [TestMethod]
        public void CreateFood_return_bad_test()
        {
            FoodsController controller = GetController(doNotThrowException);
            EditedFood food = GetInvalidFood();           
            var response = controller.CreateFood(food);
            Assert.AreEqual("NotFoundObjectResult", response.GetType().Name);
        }     

        [TestMethod]
        public void CreateFood_CatchException_test()
        {
            FoodsController controller = GetController(throwException);
            EditedFood food = GetFood();
            var response = controller.CreateFood(food) as BadRequestObjectResult;
            var message = response.Value.GetType().Name;
            Assert.AreEqual("Exception", message);
        }

        [TestMethod]
        public void Update_return_ok_test()
        {
            FoodsController controller = GetController(doNotThrowException);
            EditedFood editedFood = GetFood();
            var response = controller.Update(editedFood).GetType().Name;
            Assert.AreEqual(response, "OkObjectResult");
        }

        [TestMethod]
        public void Update_return_bad_test()
        {
            FoodsController controller = GetController(doNotThrowException);
            EditedFood editedFood = GetInvalidFood();
            var response = controller.Update(editedFood).GetType().Name;
            Assert.AreEqual(response, "NotFoundObjectResult");
        }

        private EditedFood GetInvalidFood()
        {
            EditedFood food = GetFood();
            food.Food.Name = "Invalid test food";
            return food;
        }

        [TestMethod]
        public void Update_catchException_test()
        {
            FoodsController controller = GetController(throwException);
            EditedFood editedFood = GetFood();
            var response = controller.Update(editedFood) as BadRequestObjectResult;
            var message = response.Value.GetType().Name;
            Assert.AreEqual("Exception", message);
        }

        private EditedFood GetFood()
        {
            return new EditedFood()
            {
                Food = new FoodsModel()
                {
                    Name = "Test food",
                    ReferenceMassInGrams = 100
                }
            };
        }

        [TestMethod]
        public void Delete_return_ok_test()
        {
            FoodsController controller = GetController(doNotThrowException);
            var response = controller.Delete("Registered_food").GetType().Name;
            Assert.AreEqual(response, "OkObjectResult");
        }

        [TestMethod]
        public void Delete_return_bad_test()
        {
            FoodsController controller = GetController(doNotThrowException);
            var response = controller.Delete("Invalid_food").GetType().Name;
            Assert.AreEqual(response, "NotFoundObjectResult");
        }

        [TestMethod]
        public void Delete_catchExeception()
        {
            FoodsController controller = GetController(throwException);
            var response = controller.Delete("Registered_food") as BadRequestObjectResult;
            var message = response.Value.GetType().Name;
            Assert.AreEqual("Exception", message);
        }

        private FoodsController GetController(bool exceptionControl)
        {
            IFoods foodManager = new FoodsMock(exceptionControl);
            IResponseHandler responseHandler = new ResponseHandler();
            return new FoodsController(foodManager, responseHandler);
        }
    }
}
