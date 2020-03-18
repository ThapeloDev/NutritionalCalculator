using Microsoft.AspNetCore.Mvc;
using NutritionalCalculator.Classes.Interfaces;
using NutritionalCalculator.Model.Entities.Db;
using NutritionalCalculator.Models;
using System;
using System.Collections.Generic;

namespace NutritionalCalculator.Unit.Test.Mocks
{
    public class FoodsMock : IFoods
    {
        private bool throwExeption;
        private FoodsResponse response;

        public FoodsMock(bool exceptionControl)
        {
            throwExeption = exceptionControl;
            response = new FoodsResponse();
            response.IsValid = true;
            response.StatusCode = 200;
            response.Foods = new List<Foods>();
        }

        public FoodsResponse GetAll()
        {
            if (throwExeption) throw new Exception();
            response.Foods = Foods();
            return response;
        }
        private List<Foods> Foods()
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

        public FoodsResponse GetById(string foodId)
        {
            if (throwExeption) throw new Exception();
            if (foodId == "id_test_food")
            {
                response.Foods.Add(Foods()[0]);
            }
            return response;
        }

        public FoodsResponse GetByName(string name)
        {
            if (throwExeption) throw new Exception();
            if (name == "test_food_name")
            {
                response.Foods.Add(Foods()[0]);
            }
            return response;
        }

        public FoodsResponse Create(Foods food, string userIdOfCreator)
        {
            if (throwExeption) throw new Exception();
            if (food.Name == "Invalid test food") 
            {
                response.IsValid = false;
                response.StatusCode = 404;
            } 
            else
                response.Foods.Add(food);
            return response;
        }

        public FoodsResponse Update(Foods model, string userIdOfEditor)
        {
            if (throwExeption) throw new Exception();
            if (model.Name == "Test food") 
                response.Foods.Add(model);
            else
            {
                response.IsValid = false;
                response.StatusCode = 404;
            }        
            return response;
        }

        public FoodsResponse Delete(string id)
        {
            if (throwExeption) throw new Exception();
            if (id != "Registered_food") 
            {
                response.IsValid = false;
                response.StatusCode = 404;
            } 
            return response;
        }

    }
}
