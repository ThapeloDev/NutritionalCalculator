using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionalCalculator.Model.Entities.Db
{
    public partial class FoodsCategories
    {
        public FoodsCategories()
        {
            FoodInCategories = new HashSet<FoodsInCategories>();
        }

        public short Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<FoodsInCategories> FoodInCategories { get; set; }
    }
}
