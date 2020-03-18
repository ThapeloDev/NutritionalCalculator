using Microsoft.VisualStudio.TestTools.UnitTesting;
using NutritionalCalculator.Classes;
using NutritionalCalculator.Classes.Interfaces;
using NutritionalCalculator.Model;
using NutritionalCalculator.Model.Entities;
using NutritionalCalculator.Models;
using NutritionalCalculator.Unit.Test.Mocks;

namespace NutritionalCalculator.Unit.Test.Api.Classes
{
    [TestClass]
    public class FoodCategoriesManagerTests
    {
        [TestMethod]
        public void GetAllCategories_Test()
        {
            IUnitOfWork unitOfWork = new UnitOfWorkMock();
            IFoodsCategories foodCategoriesManager = new FoodsCategories(unitOfWork);
            FoodsCategoriesResponse response = foodCategoriesManager.GetAllCategories();
            Assert.AreEqual(2, response.FoodCategories.Count);
        }

        [TestMethod]
        public void GetCategoryByName_return_ok_test()
        {
            IFoodsCategories foodCategoriesManager = GetCategoryManager();
            FoodsCategoriesResponse response = foodCategoriesManager.GetCategoryByName("Registered category");
            Assert.AreEqual("Registered category",  response.FoodCategories[0].Name);
        }
        [TestMethod]
        public void GetCategoryByName_return_bad_test()
        {
            IFoodsCategories foodCategoriesManager = GetCategoryManager();
            FoodsCategoriesResponse response = foodCategoriesManager.GetCategoryByName("Invalid category");
            Assert.AreEqual(response.FoodCategories[0], null);
        }
        private IFoodsCategories GetCategoryManager()
        {
            IUnitOfWork unitOfWork = new UnitOfWorkMock();
            return new FoodsCategories(unitOfWork);
        }

        [TestMethod]
        public void Create_return_ok()
        {
            IUnitOfWork unitOfWork = new UnitOfWorkMock();
            IFoodsCategories foodCategoriesManager = new FoodsCategories(unitOfWork);
            EditedFoodCategory category = new EditedFoodCategory(){ Name = "New category" };
            var response = foodCategoriesManager.Create(category);
            Assert.IsTrue(response.IsValid);
        }

        [TestMethod]
        public void Create_return_bad()
        {
            IUnitOfWork unitOfWork = new UnitOfWorkMock();
            IFoodsCategories foodCategories = new FoodsCategories(unitOfWork);
            EditedFoodCategory category = new EditedFoodCategory(){ Name = "Registered category" };
            var response = foodCategories.Create(category);
            Assert.AreEqual(response.StatusCode, 400);
            Assert.IsFalse(response.IsValid);
        }
    }
}
