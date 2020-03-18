using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionalCalculator.Model.Entities.Db
{
    public partial class FoodsInCategories
    {
        public short FoodCategoryId { get; set; }
        public string FoodId { get; set; }

        public virtual Foods Food { get; set; }
        public virtual FoodsCategories FoodCategory { get; set; }
    }
}
