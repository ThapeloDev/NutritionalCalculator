using NutritionalCalculator.Model.Entities.Db;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionalCalculator.Model.Repositories
{
    public interface IConsumedFoodsRepository : IModelRepository<ConsumedFoods>
    {
        List<ConsumedFoods> GetByUser(string idUser);
        ConsumedFoods GetById(ConsumedFoods consumedFood);
    }
}
