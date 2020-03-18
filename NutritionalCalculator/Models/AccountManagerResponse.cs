
using System.Collections.Generic;

namespace NutritionalCalculator.Models
{
    public partial class AccountManagerResponse : IValidatorResponse
    {
        public UserData User { get; set; }
        public TokenModel Token { get; set; }
        public bool IsValid { get; set; }
        public int StatusCode { get; set; }
    }
}
