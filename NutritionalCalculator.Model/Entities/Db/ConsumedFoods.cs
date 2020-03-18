using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionalCalculator.Model.Entities.Db
{
    public partial class ConsumedFoods
    {
        public string IdUser { get; set; }
        public DateTime Date { get; set; }
        public byte NumberOfPlate { get; set; }
        public string IdFood { get; set; }
        public float? MassConsumedInGr { get; set; }
        public float? VolumeConsumedInMl { get; set; }
        public short? ConsumedUnits { get; set; }

        public virtual Foods IdFoodNavigation { get; set; }
        public virtual Users IdUserNavigation { get; set; }
    }
}
