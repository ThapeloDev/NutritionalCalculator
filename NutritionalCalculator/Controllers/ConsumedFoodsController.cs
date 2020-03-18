using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NutritionalCalculator.Classes.Interfaces;
using ConsumedFoodsModel = NutritionalCalculator.Model.Entities.Db.ConsumedFoods;

namespace NutritionalCalculator.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class ConsumedFoodsController : Controller
    {
        IConsumedFoods _consumedFoods;
        IActionResult response;
        IResponseHandler _responseHandler;

        public ConsumedFoodsController(IConsumedFoods consumedFoods, IResponseHandler responseHandler)
        {
            _consumedFoods = consumedFoods;
            _responseHandler = responseHandler;
        }

        // GET: api/<controller>
        [HttpGet("userId")]
        [Route("GetByUser")]
        public IActionResult GetByUser(string userId)
        {
            try
            {
                response = _responseHandler.ProcessResponse(_consumedFoods.GetByUser(userId));
            }
            catch (Exception exception)
            {
                response = new BadRequestObjectResult(exception);
            }
            return response;
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Create([FromBody]ConsumedFoodsModel consumedFood)
        {
            try
            {
                response = _responseHandler.ProcessResponse(_consumedFoods.Create(consumedFood));
            }catch(Exception exception)
            {
                response = new BadRequestObjectResult(exception);
            }
            return response;
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IActionResult Update([FromBody]ConsumedFoodsModel consumedFood)
        {
            try
            {
                response = _responseHandler.ProcessResponse(_consumedFoods.Update(consumedFood));
            }
            catch (Exception exception)
            {
                response = new BadRequestObjectResult(exception);
            }
            return response;

        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public IActionResult Delete([FromBody]ConsumedFoodsModel consumedFood)
        {
            try
            {
                response = _responseHandler.ProcessResponse(_consumedFoods.Delete(consumedFood));
            }
            catch (Exception exception)
            {
                response = new BadRequestObjectResult(exception);
            }
            return response;
        }
    }
}
