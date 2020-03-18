using NutritionalCalculator.Model.Entities.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionalCalculator.Models
{
    public class FoodsCategoriesResponse: IValidatorResponse
    {
        public IList<FoodsCategories> FoodCategories { get; set; }
        public bool IsValid { get; set; }
        public int StatusCode { get; set; }
    }
}
