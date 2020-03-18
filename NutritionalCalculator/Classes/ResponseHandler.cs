
using Microsoft.AspNetCore.Mvc;
using NutritionalCalculator.Classes.Interfaces;
using NutritionalCalculator.Models;

namespace NutritionalCalculator.Classes
{
    public class ResponseHandler : IResponseHandler
    {
        private IActionResult Result { get; set; }

        public IActionResult ProcessResponse(IValidatorResponse response)
        {
            switch (response.StatusCode)
            {
                case 400: case 401:
                    Result = new BadRequestObjectResult(response);
                    break;
                case 404:
                    Result = new NotFoundObjectResult(response);
                    break;
                case 200:
                    Result = new OkObjectResult(response);
                    break;
                default:
                    SetIfThereIsNoStatuscode(response);
                    break;
            }
            return Result;
        }
        private void SetIfThereIsNoStatuscode(IValidatorResponse response)
        {
            if (response.IsValid)
            {
                Result = new OkObjectResult(response);
            } else
            {
                Result = new BadRequestObjectResult(response);
            }
        }
    }
}
