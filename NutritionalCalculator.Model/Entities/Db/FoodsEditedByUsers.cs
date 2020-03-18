using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionalCalculator.Model.Entities.Db
{
    public partial class FoodsEditedByUsers
    {
        public string UserId { get; set; }
        public string FoodId { get; set; }
        public DateTime EditionDate { get; set; }
        public bool Creation { get; set; }
        public bool Edition { get; set; }

        public virtual Foods Food { get; set; }
        public virtual Users User { get; set; }
    }
}
