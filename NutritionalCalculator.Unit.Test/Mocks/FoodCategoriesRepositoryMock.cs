using NutritionalCalculator.Model.Entities.Db;
using NutritionalCalculator.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionalCalculator.Unit.Test.Mocks
{
    class FoodCategoriesRepositoryMock : IFoodCategoriesRepository
    {
        public FoodsCategories Add(FoodsCategories entity)
        {
            return null;
        }

        public void Delete(FoodsCategories entity)
        {
            throw new NotImplementedException();
        }

        public List<FoodsCategories> GetAllEntities()
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

        public FoodsCategories GetFoodCategoryByName(string name)
        {
            FoodsCategories response = null;
            if (name == "Registered category") response = new FoodsCategories() { Name = name };
            return response;
        }

        public void update(FoodsCategories entity)
        {
            throw new NotImplementedException();
        }
    }
}
