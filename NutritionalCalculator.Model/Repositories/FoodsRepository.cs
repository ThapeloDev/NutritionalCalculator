using NutritionalCalculator.Model.Entities.Db;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace NutritionalCalculator.Model.Repositories
{
    public class FoodsRepository : ModelRepository<Foods>, IFoodsRepository
    {
        public FoodsRepository(IDbContext dbContext) : base(dbContext)
        {

        }

        public Foods GetByName(string name) => (from food in _context.Foods
                                                where food.Name == name
                                                select food)
                                                .Include(x => x.FattyAcidsAndCholesterol)
                                                .Include(x => x.Macronutrients)  
                                                .Include(x => x.Minerals)
                                                .Include(x => x.Vitamins)
                                                .FirstOrDefault();
        public Foods GetById(string id) => (from food in _context.Foods
                                            where food.Id == id
                                            select food)
                                                .Include(x => x.FattyAcidsAndCholesterol)
                                                .Include(x => x.Macronutrients)
                                                .Include(x => x.Minerals)
                                                .Include(x => x.Vitamins)
                                                .FirstOrDefault();
    }
}
