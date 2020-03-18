using NutritionalCalculator.Model.Entities.Db;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionalCalculator.Model.Repositories
{
    public class FoodsEditedByUsersRepository: ModelRepository<FoodsEditedByUsers>, IFoodsEditedByUsersRepository
    {
        public FoodsEditedByUsersRepository(IDbContext dbContext): base(dbContext) 
        {
        }
    }
}
