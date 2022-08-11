using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TableManagementLibrary.Interface;
using TableManagementLibrary.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TableManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITables _tables;

        public TableController(ITables tables)
        {
            _tables = tables;
        }
        [HttpGet]
        public async Task<IList<tables>> Get()
        {
            return await _tables.GetTableList();
        }
        [HttpGet("{id}")]
        public async Task<tables> Get(int id)
        {
            var flowers = await _tables.GetTableById(id);

            return flowers;
        }
        [HttpPost]
        public async Task<bool> Post([FromBody] tables value)
        {
            var result = false;
            try
            {
                result = await _tables.CreateAsync(value);
            }
            catch (Exception)
            {
                result = false;

            }

            return result;

        }
        [HttpPut]
        public async Task<bool> Put([FromBody] tables value)
        {

            var result = false;
            try
            {
                var getRecord = await _tables.GetTableById(value.TableId);
                if (getRecord != null)
                {
                    result = await _tables.UpdateAsync(value);
                }
            }
            catch (Exception)
            {
                result = false;

            }

            return result;
        }
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var result = false;
            try
            {
                var getRecord = await _tables.GetTableById(id);
                if (getRecord != null)
                {
                    result = await _tables.DeleteAsysn(getRecord);
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
