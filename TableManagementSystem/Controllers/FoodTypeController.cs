using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TableManagementLibrary.Interface;
using TableManagementLibrary.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TableManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodTypeController : ControllerBase
    {
        private readonly IFoodType _foodType;
      
        public FoodTypeController(IFoodType foodType)
        {
            _foodType = foodType;
        }
        // GET: api/<FoodTypeController>
        [HttpGet]
        public async Task <IList<foodType>> Get()
        {
            return await  _foodType.GetFoodTypeList();
        }

        // GET api/<FoodTypeController>/5
        [HttpGet("{id}")]
        public async Task<foodType> Get(int id)
        {
            var foodType = await _foodType.GetFoodTypeById(id);

            return foodType;
        }

        // POST api/<FoodTypeController>
        [HttpPost]
        public async Task<bool> Post([FromBody] foodType value)
        {
            

            bool result = false;
            try
            {
                result= await _foodType.CreateAsync(value);
                

            }
            catch (Exception)
            {

                result = false;
            }

            return result;
        }

        // PUT api/<FoodTypeController>
        [HttpPut]
        public async Task<bool> Put([FromBody] foodType value)
        {

            bool result = false;
            try
            {
                foodType getRecord = await _foodType.GetFoodTypeById(value.FoodId);
                if (getRecord != null)
                {
                    result = await _foodType.UpdateAsync(value);
                  
                }

            }
            catch (Exception)
            {

                result = false;
            }

            return result;
        }

        // DELETE api/<FoodTypeController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            bool result = false;
            try
            {
                foodType getRecord = await _foodType.GetFoodTypeById(id);
                if (getRecord != null)
                {
                    result= await _foodType.DeleteAsysn(getRecord);
                   
                }
                
            }
            catch (Exception)
            {

                result = false;
            }
          
            return result;
        }
    }
}
