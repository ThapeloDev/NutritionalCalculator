using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionalCalculator.Model.Entities.Db
{
    public partial class FoodsReferences
    {
        public string IdFood { get; set; }
        public string IdReference { get; set; }

        public virtual Foods IdFoodNavigation { get; set; }
        public virtual Reference IdReferenceNavigation { get; set; }
    }
}
