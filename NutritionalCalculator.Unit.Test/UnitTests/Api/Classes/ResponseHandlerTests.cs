using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NutritionalCalculator.Classes;
using NutritionalCalculator.Classes.Interfaces;
using NutritionalCalculator.Models;
using NutritionalCalculator.Unit.Test.Mocks;

namespace NutritionalCalculator.Unit.Test.Api.Classes
{
    [TestClass]
    public class ResponseHandlerTests
    {
        private IValidatorResponse response = new ValidatorResponseMock(); 
        
        [TestMethod]
        public void ProcessResponse_Return_Ok()
        {
            IResponseHandler responseHandler = new ResponseHandler();
            response.IsValid = true;
            response.StatusCode = 200;
            IActionResult result = responseHandler.ProcessResponse(response);
            Assert.AreEqual(result.GetType().Name, "OkObjectResult");
        }

        [TestMethod]
        public void ProcessResponse_Return_Bad()
        {
            IResponseHandler responseHandler = new ResponseHandler();
            response.IsValid = false;
            response.StatusCode = 400;
            IActionResult result = responseHandler.ProcessResponse(response);
            Assert.AreEqual(result.GetType().Name, "BadRequestObjectResult");
        }

        [TestMethod]
        public void ProcessResponse_Return_Ok_If_Not_Have_StatusCode()
        {
            IResponseHandler responseHandler = new ResponseHandler();
            response.IsValid = true;
            response.StatusCode = 0;
            IActionResult result = responseHandler.ProcessResponse(response);
            Assert.AreEqual(result.GetType().Name, "OkObjectResult");
        }

        [TestMethod]
        public void ProcessResponse_Return_Bad_If_Not_Have_StatusCode()
        {
            IResponseHandler responseHandler = new ResponseHandler();
            response.IsValid = false;
            response.StatusCode = 0;
            IActionResult result = responseHandler.ProcessResponse(response);
            Assert.AreEqual(result.GetType().Name, "BadRequestObjectResult");
        }
    }
}
