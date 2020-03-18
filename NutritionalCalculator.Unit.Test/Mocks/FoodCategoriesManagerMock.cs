using Microsoft.AspNetCore.Mvc;
using NutritionalCalculator.Classes.Interfaces;
using NutritionalCalculator.Model.Entities;
using NutritionalCalculator.Model.Entities.Db;
using NutritionalCalculator.Models;
using System;
using System.Collections.Generic;

namespace NutritionalCalculator.Unit.Test.Mocks
{
    public class FoodCategoriesManagerMock : ControllerBase, IFoodsCategories
    {
        private bool _throwException;
        public FoodCategoriesManagerMock(bool throwException)
        {
            _throwException = throwException;
        }
        public FoodsCategoriesResponse Create(EditedFoodCategory model)
        {
            FoodsCategoriesResponse response = new FoodsCategoriesResponse();
            if (_throwException) throw new Exception();
            if (model.Name == "Category valid test")
            {
                response.IsValid = true;
            }
            else
            {
                response.IsValid = false;
            }
            return response;
        }

        public FoodsCategoriesResponse GetAllCategories()
        {
            FoodsCategoriesResponse response = new FoodsCategoriesResponse();
            if (_throwException) throw new Exception();
            response.FoodCategories = CategoriesList();
            return response;
        }
        private List<FoodsCategories> CategoriesList()
        {
            return new List<FoodsCategories>()
            {
                new FoodsCategories()
                {
                    Name = "Category test 1"
                },
                new FoodsCategories()
                {
                    Name = "Category test 2"
                }
            };
        }

        public FoodsCategoriesResponse GetCategoryByName(string name)
        {
            FoodsCategoriesResponse response = new FoodsCategoriesResponse()
            {
                FoodCategories = new List<FoodsCategories>()
            };
            if (_throwException) throw new Exception();
            if (name == "Invalid category")
            {
                response.IsValid = false;
                response.StatusCode = 400;
            }
            else
            {
                response.FoodCategories.Add(new FoodsCategories() { Name = name });
                response.IsValid = true;
                response.StatusCode = 200;
            }
            return response;
        }
    }
}
