using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NutritionalCalculator.Classes.Interfaces;
using NutritionalCalculator.Model.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NutritionalCalculator.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Policy = "AdministratorRequirement")]
    [ApiController]
    [Route("api/[controller]")]
    public class FoodCategoriesController : Controller
    {
        private IFoodsCategories _foodCategoryManager;
        private IResponseHandler _responseHandler;
        public FoodCategoriesController(IFoodsCategories foodCategoryManager, IResponseHandler responseHandler)
        {
            _foodCategoryManager = foodCategoryManager;
            _responseHandler = responseHandler;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult response;
            try
            {
                response = Ok(_foodCategoryManager.GetAllCategories());
            }
            catch(Exception e)
            {
                response = BadRequest(e);
            }
            return response;
        }

        // GET api/<controller>/5
        [Route("Get")]
        [HttpGet("name")]
        public IActionResult Get(string name)
        {
            IActionResult response;
            try
            {
                response = _responseHandler.ProcessResponse(_foodCategoryManager.GetCategoryByName(name));
            }
            catch (Exception e)
            {
                response = new BadRequestObjectResult(e);
            }
            return response;
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Create([FromBody]EditedFoodCategory model)
        {
            IActionResult response;
            try
            {
                response = _responseHandler.ProcessResponse(_foodCategoryManager.Create(model));
            }catch(Exception e)
            {
                response = BadRequest(e);
            }
            return response;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            //TODO: Completar el metodo para actualizar una categoria.
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //TODO: Completar el metodo para borrar una categoria. 
        }
    }
}
