using NutritionalCalculator.Model.Entities.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionalCalculator.Models
{
    public class UserResponse : IValidatorResponse
    {
        public Users User { get; set; }
        public bool IsValid { get; set; }
        public int StatusCode { get; set; }
    }
}
