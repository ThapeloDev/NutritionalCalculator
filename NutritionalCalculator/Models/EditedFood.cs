using NutritionalCalculator.Model.Entities.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionalCalculator.Models
{
    public class EditedFood
    {
        public Foods Food { get; set; }
        public string UserId { get; set; }
    }
}
