using NutritionalCalculator.Models;

namespace NutritionalCalculator.Unit.Test.Mocks
{
    class ValidatorResponseMock : IValidatorResponse
    {
        public bool IsValid { get; set; }
        public int StatusCode { get; set; }
    }
}
