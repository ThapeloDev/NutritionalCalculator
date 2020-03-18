using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsumedFoodsModel = NutritionalCalculator.Model.Entities.Db.ConsumedFoods;

namespace NutritionalCalculator.Models
{
    public class ConsumedFoodsResponse : IValidatorResponse
    {
        public List<ConsumedFoodsModel> ConsumedFood { get; set; }
        public bool IsValid { get; set; }
        public int StatusCode { get; set; }
    }
}
