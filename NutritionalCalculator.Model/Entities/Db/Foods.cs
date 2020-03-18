using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionalCalculator.Model.Entities.Db
{
    public partial class Foods
    {
        public Foods()
        {
            ConsumedFoods = new HashSet<ConsumedFoods>();
            FoodInCategories = new HashSet<FoodsInCategories>();
            FoodReferences = new HashSet<FoodsReferences>();
            FoodsEditedByUsers = new HashSet<FoodsEditedByUsers>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public float? ReferenceMassInGrams { get; set; }
        public float? ReferenceVolumeInMililiters { get; set; }
        public short? ReferenceUnits { get; set; }

        public FattyAcidsAndCholesterol FattyAcidsAndCholesterol { get; set; }
        public Macronutrients Macronutrients { get; set; }
        public Minerals Minerals { get; set; }
        public Vitamins Vitamins { get; set; }
        public ICollection<ConsumedFoods> ConsumedFoods { get; set; }
        public ICollection<FoodsInCategories> FoodInCategories { get; set; }
        public ICollection<FoodsReferences> FoodReferences { get; set; }
        public ICollection<FoodsEditedByUsers> FoodsEditedByUsers { get; set; }
    }
}
