using System;
using System.Collections.Generic;

namespace NutritionalCalculator.Model.Entities.Db
{
    public partial class FattyAcidsAndCholesterol
    {
        public string IdFood { get; set; }
        public float? SaturatedFat { get; set; }
        public float? MonounsaturatedFat { get; set; }
        public float? PolyunsaturatedFat { get; set; }
        public float? Cholesterol { get; set; }

        public Foods IdFoodNavigation { get; set; }
    }
}
