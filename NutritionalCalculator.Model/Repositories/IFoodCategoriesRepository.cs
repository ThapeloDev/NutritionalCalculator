using NutritionalCalculator.Model.Entities.Db;

namespace NutritionalCalculator.Model.Repositories
{
    public interface IFoodCategoriesRepository : IModelRepository<FoodsCategories>
    {
        FoodsCategories GetFoodCategoryByName(string name);
    }
}
