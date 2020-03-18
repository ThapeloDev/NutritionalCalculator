using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NutritionalCalculator.Classes;
using NutritionalCalculator.Classes.Interfaces;
using NutritionalCalculator.Controllers;
using NutritionalCalculator.Model.Entities;
using NutritionalCalculator.Models;
using NutritionalCalculator.Unit.Test.Mocks;

namespace NutritionalCalculator.Unit.Test.Api.Controllers
{
    [TestClass]
    public class FoodCategoriesControllerTests
    {
        const bool throwException = true;
        const bool doNotThrowException = false;

        [TestMethod]
        public void Get_return_all_categories_test()
        {
            FoodCategoriesController controller = GetFoodCategoriesController(doNotThrowException);
            OkObjectResult response = controller.Get() as OkObjectResult;
            var categories = response.Value as FoodsCategoriesResponse;
            Assert.AreEqual(2, categories.FoodCategories.Count);
        }

        [TestMethod]
        public void Get_catch_exception()
        {
            FoodCategoriesController controller = GetFoodCategoriesController(throwException);
            var response = controller.Get() as BadRequestObjectResult;
            var message = response.Value.GetType().Name;
            Assert.AreEqual("Exception", message);
        }

        [TestMethod]
        public void Get_return_category_by_name_ok_test()
        {
            FoodCategoriesController controller = GetFoodCategoriesController(doNotThrowException);
            OkObjectResult result = controller.Get("Food category") as OkObjectResult;
            FoodsCategoriesResponse responseValue = result.Value as FoodsCategoriesResponse;
            Assert.IsTrue(responseValue.IsValid);
        }

        [TestMethod]
        public void Get_return_category_by_name_bad_test()
        {
            FoodCategoriesController controller = GetFoodCategoriesController(doNotThrowException);
            var response = controller.Get("Invalid category");
            Assert.AreEqual("BadRequestObjectResult", response.GetType().Name);
        }

        [TestMethod]
        public void Get_return_category_by_name_catch_exception()
        {
            FoodCategoriesController controller = GetFoodCategoriesController(throwException);
            var response = controller.Get("Category") as BadRequestObjectResult;
            var message = response.Value.GetType().Name;
            Assert.AreEqual("Exception", message);
        }

        [TestMethod]
        public void Create_ok_test()
        {
            FoodCategoriesController controller = GetFoodCategoriesController(doNotThrowException);
            EditedFoodCategory category = new EditedFoodCategory() { Name = "Category valid test" };
            var response = controller.Create(category).GetType().Name;
            Assert.AreEqual("OkObjectResult", response);
        }
        private FoodCategoriesController GetFoodCategoriesController(bool ExceptionControl)
        {
            IFoodsCategories foodCategories = new FoodCategoriesManagerMock(ExceptionControl);
            IResponseHandler responseHandler = new ResponseHandler();
            return new FoodCategoriesController(foodCategories, responseHandler);
        }

        [TestMethod]
        public void Create_bad_test()
        {
            EditedFoodCategory category = new EditedFoodCategory() { Name = "Category invalid test" };
            FoodCategoriesController controller = GetFoodCategoriesController(doNotThrowException);
            var response = controller.Create(category).GetType().Name;
            Assert.AreEqual("BadRequestObjectResult", response);
        }

        [TestMethod]
        public void Create_catch_exception()
        {
            EditedFoodCategory category = new EditedFoodCategory() { Name = "Exception" };
            FoodCategoriesController controller = GetFoodCategoriesController(throwException);
            var response = controller.Create(category) as BadRequestObjectResult;
            var message = response.Value.GetType().Name;
            Assert.AreEqual("Exception", message);
        }  
    }
}
