using NutritionalCalculator.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionalCalculator.Model
{
    public interface IUnitOfWork
    {
        IUsersRepository Users { get; }
        IFoodCategoriesRepository FoodCategories { get; }
        IFoodsRepository Foods { get; }
        IFoodsEditedByUsersRepository FoodsEditedByUsers { get; }
        IConsumedFoodsRepository ConsumedFoods { get; }
        IUsersInRolesRepository UsersInRoles { get; }
        IRolesRepository Roles { get; }
        void commit();
    }
}
