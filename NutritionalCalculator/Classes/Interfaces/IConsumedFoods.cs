using Microsoft.AspNetCore.Mvc;
using NutritionalCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsumedFoodsModel = NutritionalCalculator.Model.Entities.Db.ConsumedFoods;

namespace NutritionalCalculator.Classes.Interfaces
{
    public interface IConsumedFoods
    {
        ConsumedFoodsResponse GetByUser(string userId);
        ConsumedFoodsResponse Create(ConsumedFoodsModel consumedFood);
        ConsumedFoodsResponse Update(ConsumedFoodsModel consumedFood);
        ConsumedFoodsResponse Delete(ConsumedFoodsModel consumedFood);
    }
}
