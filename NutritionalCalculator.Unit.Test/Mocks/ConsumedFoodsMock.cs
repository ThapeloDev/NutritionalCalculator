using Microsoft.AspNetCore.Mvc;
using NutritionalCalculator.Classes.Interfaces;
using NutritionalCalculator.Models;
using System;
using System.Collections.Generic;
using ConsumedFoodsModel = NutritionalCalculator.Model.Entities.Db.ConsumedFoods;

namespace NutritionalCalculator.Unit.Test.Mocks
{
    public class ConsumedFoodsMock : IConsumedFoods
    {
        bool _exeption;
        public ConsumedFoodsMock(bool exeption)
        {
            _exeption = exeption;
        }

        public ConsumedFoodsResponse GetByUser(string userId)
        {
            if (_exeption) throw new Exception();
            ConsumedFoodsResponse response = new ConsumedFoodsResponse() { ConsumedFood = new List<ConsumedFoodsModel>() };
            if (userId == "RegisteredUserId")
            {
                response.ConsumedFood.Add(new ConsumedFoodsModel() { IdUser = userId });
            }
            response.IsValid = true;
            return response;
        }

        public ConsumedFoodsResponse Create(ConsumedFoodsModel consumedFood)
        {
            if (_exeption) throw new Exception();
            ConsumedFoodsResponse response = GetConsumedFood();
            if (consumedFood.IdFood != "Registered_Test_Food") 
                response.ConsumedFood.Add(consumedFood);
            return response;
        }

        public ConsumedFoodsResponse Update(ConsumedFoodsModel consumedFood)
        {
            if (_exeption) throw new Exception();
            ConsumedFoodsResponse response = GetConsumedFood();
            if (consumedFood.IdFood == "Registered_Test_Food")
                response.ConsumedFood.Add(consumedFood);
            return response;
        }

        public ConsumedFoodsResponse Delete(ConsumedFoodsModel consumedFood)
        {
            if (_exeption) throw new Exception();
            ConsumedFoodsResponse response = GetConsumedFood();
            if (consumedFood.IdFood == "Registered_test_food")
                response.ConsumedFood.Add(consumedFood);
            return response;
        }

        private ConsumedFoodsResponse GetConsumedFood()
        {
            return new ConsumedFoodsResponse()
            {
                ConsumedFood = new List<ConsumedFoodsModel>(),
                IsValid = true
            };
        }
    }
}
