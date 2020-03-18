using NutritionalCalculator.Model.Entities.Db;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionalCalculator.Model.Repositories
{
    public class FoodCategoriesRepository : ModelRepository<FoodsCategories>, IFoodCategoriesRepository
    {
        public FoodCategoriesRepository(IDbContext dbContext) : base(dbContext)
        {
        }
        public FoodsCategories GetFoodCategoryByName(string name) => (from category in _context.FoodsCategories
                                                                     where category.Name == name
                                                                     select category).FirstOrDefault();
    }
}
