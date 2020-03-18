using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionalCalculator.Model.Entities.Db
{
    public partial class Reference
    {
        public Reference()
        {
            FoodReferences = new HashSet<FoodsReferences>();
        }

        public string Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<FoodsReferences> FoodReferences { get; set; }
    }
}
