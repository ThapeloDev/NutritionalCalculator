using NutritionalCalculator.Model.Entities.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionalCalculator.Models
{
    public class FoodsResponse : IValidatorResponse
    {
        public IList<Foods> Foods { get; set; }
        public bool IsValid { get; set; }
        public int StatusCode { get; set; }
    }
}
