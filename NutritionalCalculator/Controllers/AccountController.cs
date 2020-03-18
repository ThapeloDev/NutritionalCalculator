using System;
using Microsoft.AspNetCore.Mvc;
using NutritionalCalculator.Classes;
using NutritionalCalculator.Classes.Interfaces;
using NutritionalCalculator.Model.Entities;

namespace NutritionalCalculator.Controllers
{
    [Route("Api/Usuarios")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccount _account;
        private IResponseHandler _responseHandler;

        public AccountController(IAccount account, IResponseHandler responseHandler)
        {
            _account = account;
            _responseHandler = responseHandler;
        }

        [Route("Registrarse")]
        [HttpPost]
        public IActionResult CreateUser([FromBody] EditedUser model)
        {
            IActionResult response;
            try
            {
                response = _responseHandler.ProcessResponse(_account.CreateUser(model));
            }
            catch (Exception e)
            {
                response = BadRequest(e);
            }
            return response;
        }

        [Route("Iniciar_sesion")]
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel model)
        {
            IActionResult response;
            try
            {
                response = _responseHandler.ProcessResponse(_account.Login(model));
            }
            catch (Exception e)
            {
                response = BadRequest(e);
            }
            return response;
        }

        [Route("check_availability")]
        [HttpGet("userName")]
        public IActionResult CheckAvailability(string userName)
        {
            IActionResult response;
            try
            {
                response = new OkObjectResult(_account.CheckAvailability(userName));
            }
            catch (Exception e)
            {
                response = BadRequest(e);
            }
            return response;  
        }
    }
}