using System;
using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NutritionalCalculator.Classes.Interfaces;
using NutritionalCalculator.Model.Entities.Db;
using NutritionalCalculator.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NutritionalCalculator.Controllers
{
    [ApiController]
    // [Authorize(Policy = "AdministratorRequirement")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] 
    public class FoodsController : Controller
    {
        private IFoods _foodsManager;
        private IResponseHandler _responseHandler;

        public FoodsController(IFoods foodsManager, IResponseHandler responseHandler)
        {
            _foodsManager = foodsManager;
            _responseHandler = responseHandler;
        }

        // GET: api/<controller>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            IActionResult response;
            try
            {
                response = _responseHandler.ProcessResponse(_foodsManager.GetAll());
            }catch(Exception e)
            {
                response = new BadRequestObjectResult(e);
            }
            return response;
        }

        [AllowAnonymous]
        [Route("GetById")]
        [HttpGet("foodId")]
        public IActionResult GetById(string foodId)
        {
            IActionResult response;
            try
            {
                response = _responseHandler.ProcessResponse(_foodsManager.GetById(foodId));
            }
            catch (Exception e)
            {
                response = new BadRequestObjectResult(e);
            }
            return response;
        }

        // GET api/<controller>/5
        [AllowAnonymous]
        [Route("Get")]
        [HttpGet("name")]
        public IActionResult GetByName(string name)
        {
            IActionResult response;
            try
             {
                response = _responseHandler.ProcessResponse(_foodsManager.GetByName(name));
            }
            catch (Exception e)
            {
                response = new BadRequestObjectResult(e);
            }
            return response;
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult CreateFood([FromBody]EditedFood editedFood)
        {
            IActionResult response;
            try
            {
                response = _responseHandler.ProcessResponse(_foodsManager.Create(editedFood.Food, editedFood.UserId));
            }catch(Exception e)
            {
                response = new BadRequestObjectResult(e);
            }
            return response;
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IActionResult Update([FromBody]EditedFood editedFood)
        {
            IActionResult response;
            try
            {
                response = _responseHandler.ProcessResponse(_foodsManager.Update(editedFood.Food, editedFood.UserId));
            }catch(Exception e)
            {
                response = new BadRequestObjectResult(e);
            }
            return response;
        }

        // DELETE api/<controller>/5
        [Route("Delete")]
        [HttpDelete("id")]
        public IActionResult Delete(string id)
        {
            IActionResult response;
            try
            {
                response = _responseHandler.ProcessResponse(_foodsManager.Delete(id));
            }
            catch(Exception e)
            {
                response = new BadRequestObjectResult(e);
            }
            return response;
        }
    }
}
