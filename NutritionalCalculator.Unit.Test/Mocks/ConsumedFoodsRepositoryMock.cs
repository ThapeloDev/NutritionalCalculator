using NutritionalCalculator.Model.Entities.Db;
using NutritionalCalculator.Model.Repositories;
using NutritionalCalculator.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ConsumedFoodsModel = NutritionalCalculator.Model.Entities.Db.ConsumedFoods;

namespace NutritionalCalculator.Unit.Test.Mocks
{
    class ConsumedFoodsRepositoryMock : IConsumedFoodsRepository
    {        
        public ConsumedFoodsModel Add(ConsumedFoodsModel entity)
        {
            return entity;
        }
        public void Delete(ConsumedFoodsModel entity)
        {

        }
        public List<ConsumedFoodsModel> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public List<ConsumedFoods> GetByUser(string idUser)
        {
            List<ConsumedFoodsModel>response = new List<ConsumedFoodsModel>();
            if (idUser == "RegisteredUserId")
                response.Add(new ConsumedFoodsModel() { IdUser = idUser });
            return response;
        }

        public ConsumedFoodsModel GetById(ConsumedFoodsModel consumedFood)
        {
            ConsumedFoodsModel response = null;
            if (consumedFood.IdFood == "Registered_food_test")
                response = consumedFood;
            return response;
        }

        public void update(ConsumedFoodsModel entity)
        {

        }
    }
}
