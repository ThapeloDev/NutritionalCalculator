using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionalCalculator.Models
{
    public interface IValidatorResponse
    {
        bool IsValid { get; set; }
        int StatusCode { get; set; }
    }
}
