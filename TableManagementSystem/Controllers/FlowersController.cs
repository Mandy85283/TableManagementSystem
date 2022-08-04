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
    public class FlowersController : ControllerBase
    {
        private readonly IFlowers _flowers;
      
        public FlowersController(IFlowers flowers)
        {
            _flowers = flowers;
        }
        // GET: api/<FlowersController>
        [HttpGet]
        public async Task <IList<flowers>> Get()
        {
            return await  _flowers.GetFlowersList();
        }

        // GET api/<FlowersController>/5
        [HttpGet("{id}")]
        public async Task<flowers> Get(int id)
        {
            var flowers = await _flowers.GetFlowerById(id);

            return flowers;
        }

        // POST api/<FlowersController>
        [HttpPost]
        public async Task<bool> Post([FromBody] flowers value)
        {
            

            bool result = false;
            try
            {
                result= await _flowers.CreateAsync(value);
                

            }
            catch (Exception)
            {

                result = false;
            }

            return result;
        }

        // PUT api/<FlowersController>
        [HttpPut]
        public async Task<bool> Put([FromBody] flowers value)
        {

            bool result = false;
            try
            {
                flowers getRecord = await _flowers.GetFlowerById(value.FlowerId);
                if (getRecord != null)
                {
                    result = await _flowers.UpdateAsync(value);
                  
                }

            }
            catch (Exception)
            {

                result = false;
            }

            return result;
        }

        // DELETE api/<FlowersController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            bool result = false;
            try
            {
                flowers getRecord = await _flowers.GetFlowerById(id);
                if (getRecord != null)
                {
                    result= await _flowers.DeleteAsysn(getRecord);
                   
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
