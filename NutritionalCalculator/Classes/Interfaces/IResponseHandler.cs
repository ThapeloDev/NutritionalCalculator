using Microsoft.AspNetCore.Mvc;
using NutritionalCalculator.Models;

namespace NutritionalCalculator.Classes.Interfaces
{
    public interface IResponseHandler
    {
        IActionResult ProcessResponse(IValidatorResponse response);
    }
}
