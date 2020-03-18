using Microsoft.VisualStudio.TestTools.UnitTesting;
using NutritionalCalculator.Classes;
using NutritionalCalculator.Classes.Interfaces;
using NutritionalCalculator.Model;
using NutritionalCalculator.Models;
using NutritionalCalculator.Unit.Test.Mocks;
using System;
using ConsumedFoodsModel = NutritionalCalculator.Model.Entities.Db.ConsumedFoods;

namespace NutritionalCalculator.Unit.Test.Api.Classes
{
    [TestClass]
    public class ConsumedFoodsTests
    {
        [TestMethod]
        public void GetByUser_return_valid_user()
        {
            IConsumedFoods consumedFoods = GetConsumedFoods();
            ConsumedFoodsResponse response = consumedFoods.GetByUser("RegisteredUserId");
            Assert.IsTrue(response.IsValid);
            Assert.IsTrue((response.ConsumedFood.Count > 0));
        }

        [TestMethod]
        public void GetById_return_user_null ()
        {
            IConsumedFoods consumedFoods = GetConsumedFoods();
            ConsumedFoodsResponse response = consumedFoods.GetByUser("NonExistenUser");
            Assert.IsTrue(response.IsValid);
            Assert.IsTrue(response.ConsumedFood.Count < 1);
        }
        
        [TestMethod]
        public void Create_return_ok_test()
        {
            IConsumedFoods consumedFoods = GetConsumedFoods();
            ConsumedFoodsModel consumedFoodsModel = GetConsumedFoodForTest();
            consumedFoodsModel.IdFood = "New_Food_Consumed";
            ConsumedFoodsResponse response = consumedFoods.Create(consumedFoodsModel);
            Assert.IsTrue(response.IsValid);
        }

        [TestMethod]
        public void Create_throw_exception_test()
        {
            IConsumedFoods consumedFoodsClass = GetConsumedFoods();
            ConsumedFoodsModel consumedFoods = GetConsumedFoodForTest();
            consumedFoods.MassConsumedInGr = 0;
            Assert.ThrowsException<Exception>(() => consumedFoodsClass.Create(consumedFoods));
        }

        [TestMethod]
        public void Delete_return_ok_test()
        {
            IConsumedFoods consumedFoodsClass = GetConsumedFoods();
            ConsumedFoodsModel consumedFood = GetConsumedFoodForTest();
            ConsumedFoodsResponse response = consumedFoodsClass.Delete(consumedFood);
            Assert.IsTrue(response.IsValid);
        }

        [TestMethod]
        public void Delete_return_bad_test()
        {
            IConsumedFoods consumedFoodsClass = GetConsumedFoods();
            ConsumedFoodsModel consumedFood = GetConsumedFoodForTest();
            consumedFood.IdFood = "Invalid_food";
            Assert.ThrowsException<Exception>(() => consumedFoodsClass.Delete(consumedFood));
        }

        private IConsumedFoods GetConsumedFoods()
        {
            IUnitOfWork unitOfWork = new UnitOfWorkMock();
            return new ConsumedFoods(unitOfWork);
        }

        private ConsumedFoodsModel GetConsumedFoodForTest()
        {
            return new ConsumedFoodsModel()
            {
                IdUser = "User_test",
                Date = new DateTime(2019, 01, 01),
                NumberOfPlate = 1,
                IdFood = "Registered_food_test",
                MassConsumedInGr = 100
            };
        }
    }
}
