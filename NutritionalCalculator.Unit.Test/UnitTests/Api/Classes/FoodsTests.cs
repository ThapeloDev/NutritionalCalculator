using Microsoft.VisualStudio.TestTools.UnitTesting;
using NutritionalCalculator.Classes;
using NutritionalCalculator.Classes.Interfaces;
using NutritionalCalculator.Model;
using NutritionalCalculator.Models;
using NutritionalCalculator.Unit.Test.Mocks;
using FoodModel = NutritionalCalculator.Model.Entities.Db.Foods;

namespace NutritionalCalculator.Unit.Test.Api.Classes
{
    [TestClass]
    public class FoodsTests
    {
        [TestMethod]
        public void GetAll_return_all_foods_test()
        {
            IFoods foodsManager = GetFoodsManager();
            FoodsResponse response = foodsManager.GetAll();
            Assert.AreEqual(response.Foods.Count, 2);
        }

        [TestMethod]
        public void GetById_return_ok()
        {
            IFoods foodsManager = GetFoodsManager();
            FoodsResponse response = foodsManager.GetById("id_food_test");
            Assert.AreEqual(response.Foods.Count, 1);
        }

        [TestMethod]
        public void GetByName_return_ok()
        {
            IFoods foodsManager = GetFoodsManager();
            FoodsResponse response = foodsManager.GetByName("Registered food");
            Assert.IsTrue(response.IsValid);
            Assert.AreNotEqual(response.Foods[0], null);
        }

        [TestMethod]
        public void Create_return_ok_test()
        {
            IFoods foodsManager = GetFoodsManager();
            FoodModel food = GetFoodTest();
            FoodsResponse response = foodsManager.Create(food, "UserId");
            Assert.IsTrue(response.IsValid);
            Assert.AreEqual(response.Foods.Count, 1);
        }
        private FoodModel GetFoodTest()
        {
            return new FoodModel()
            {
                Name = "Food test",
                ReferenceMassInGrams = 100
            };
        }

        [TestMethod]
        public void Create_return_bad_test()
        {
            IFoods foodsManager = GetFoodsManager();
            FoodModel food = GetInvalidFoodTest();
            FoodsResponse response = foodsManager.Create(food, "UserId");
            Assert.IsFalse(response.IsValid);
        }
        private FoodModel GetInvalidFoodTest()
        {
            FoodModel food = GetFoodTest();
            food.Name = "Registered food";
            return food;
        }

        [TestMethod]
        public void Update_return_ok_test()
        {
            IFoods foodsManager = GetFoodsManager();
            FoodModel food = GetFoodTest();
            food.Id = "id_food_test";
            FoodsResponse response = foodsManager.Update(food, "UserId");
            Assert.IsTrue(response.IsValid);
        }

        [TestMethod]
        public void Update_return_bad_test()
        {
            IFoods foodsManager = GetFoodsManager();
            FoodModel food = GetInvalidFoodTest();
            FoodsResponse response = foodsManager.Update(food, "UserId");
            Assert.IsFalse(response.IsValid);
        }

        [TestMethod]
        public void Delete_return_ok_test()
        {
            IFoods foodsManager = GetFoodsManager();
            FoodsResponse response = foodsManager.Delete("id_food_test");
            Assert.IsTrue(response.IsValid);
        }

        [TestMethod]
        public void Delete_return_bad_test()
        {
            IFoods foodsManager = GetFoodsManager();
            FoodsResponse response = foodsManager.Delete("ivalid_food");
            Assert.IsFalse(response.IsValid);
        }

        private IFoods GetFoodsManager()
        {
            IUnitOfWork unitOfWork = new UnitOfWorkMock();
            return new Foods(unitOfWork);
        }
    }
}
