using NutritionalCalculator.Model.Entities.Db;
using NutritionalCalculator.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionalCalculator.Unit.Test.Mocks
{
    class FoodsEditedByUsersRepositoryMock : IFoodsEditedByUsersRepository
    {
        public FoodsEditedByUsers Add(FoodsEditedByUsers entity)
        {
            return entity;
        }

        public void Delete(FoodsEditedByUsers entity)
        {
            throw new NotImplementedException();
        }

        public List<FoodsEditedByUsers> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public void update(FoodsEditedByUsers entity)
        {
            throw new NotImplementedException();
        }
    }
}
