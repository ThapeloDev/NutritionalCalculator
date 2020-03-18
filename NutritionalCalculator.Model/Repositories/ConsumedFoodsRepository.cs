using NutritionalCalculator.Model.Entities.Db;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace NutritionalCalculator.Model.Repositories
{
    class ConsumedFoodsRepository : ModelRepository<ConsumedFoods>, IConsumedFoodsRepository
    {
        public ConsumedFoodsRepository(IDbContext dbContext) : base(dbContext)
        {

        }

        public List<ConsumedFoods> GetByUser(string idUser) => (from c in _context.ConsumedFoods
                                                                where c.IdUser == idUser
                                                                select c).ToList();

        public ConsumedFoods GetById(ConsumedFoods consumedFood) => (from c in _context.ConsumedFoods
                                                                     where
                                                                     c.IdUser == consumedFood.IdUser &&
                                                                     c.Date.ToString() == consumedFood.Date.ToString("yyyy-MM-dd") &&
                                                                     c.NumberOfPlate == consumedFood.NumberOfPlate &&
                                                                     c.IdFood == consumedFood.IdFood
                                                                     select c).FirstOrDefault();
    }
}
