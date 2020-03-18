using NutritionalCalculator.Model;
using NutritionalCalculator.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionalCalculator.Unit.Test.Mocks
{
    public class UnitOfWorkMock : IUnitOfWork
    {
        public IUsersRepository Users => new UsersRepositoryMock() ?? throw new NotImplementedException();
        public IFoodCategoriesRepository FoodCategories => new FoodCategoriesRepositoryMock() ?? throw new NotImplementedException();
        public IFoodsRepository Foods => new FoodsRepositoryMock() ?? throw new NotImplementedException();
        public IConsumedFoodsRepository ConsumedFoods => new ConsumedFoodsRepositoryMock() ?? throw new NotImplementedException();
        public IUsersInRolesRepository UsersInRoles => new UsersInRolesRepositoryMock() ?? throw new NotImplementedException();
        public IRolesRepository Roles => new RolesRepositoryMock() ?? throw new NotImplementedException();

        public IFoodsEditedByUsersRepository FoodsEditedByUsers => new FoodsEditedByUsersRepositoryMock() ?? throw new NotImplementedException();

        public void commit()
        {
            
        }
    }
}
