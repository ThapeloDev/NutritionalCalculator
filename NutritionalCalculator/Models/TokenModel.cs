using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionalCalculator.Models
{
    public partial class TokenModel
    {
        public string Value { get; set; }
        public DateTime Expiration { get; set; }
    }
}
