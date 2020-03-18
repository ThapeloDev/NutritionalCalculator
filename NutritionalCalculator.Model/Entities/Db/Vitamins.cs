using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionalCalculator.Model.Entities.Db
{
    public partial class Vitamins
    {
        public string IdFood { get; set; }
        public float? Thiamin { get; set; }
        public float? Riboflavin { get; set; }
        public float? Niacin { get; set; }
        public float? Folates { get; set; }
        public float? VitaminB12 { get; set; }
        public float? VitaminC { get; set; }
        public float? VitaminA { get; set; }

        public virtual Foods IdFoodNavigation { get; set; }
    }
}
