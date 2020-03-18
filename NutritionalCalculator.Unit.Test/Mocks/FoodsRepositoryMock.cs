using NutritionalCalculator.Model.Entities.Db;
using NutritionalCalculator.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionalCalculator.Unit.Test.Mocks
{
    class FoodsRepositoryMock : IFoodsRepository
    {
        public Foods Add(Foods entity)
        {
            return entity;
        }

        public void Delete(Foods entity)
        {
            
        }

        public List<Foods> GetAllEntities()
        {
            return new List<Foods>()
            {
                new Foods()
                {
                    Name = "Test food 1",
                    ReferenceMassInGrams = 100
                },
                new Foods()
                {
                    Name = "Test food 2",
                    ReferenceMassInGrams = 100
                }
            };
        }

        public Foods GetById(string id)
        {
            Foods food = null;
            if (id == "id_food_test")
            {
                food = new Foods() { Id = id };
            }
            return food;
        }

        public Foods GetByName(string name)
        {
            Foods food = null;
            if(name == "Registered food")
            {
                food = new Foods() { Name = name };    
            }
            return food;
        }

        public void update(Foods entity)
        {
            
        }
    }
}
