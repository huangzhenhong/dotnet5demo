using dotnet5.WebApi.EFCoreDemo.Models;
using dotnet5.WebApi.EFCoreDemo.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dotnet5.WebApi.EFCoreDemo
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        public readonly MainDbContext _dbContext;
        public ItemsController(MainDbContext dbContext) {
            _dbContext = dbContext;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IEnumerable<Item>> Get()
        {
            return await _dbContext.Items.ToListAsync();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<Item> Get(int id)
        {
            return await _dbContext.Items.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<Item> Post([FromBody] Item item)
        {
            var _item = await _dbContext.Items.Where(x => x.Id == item.Id).FirstOrDefaultAsync();
            if (_item == default)
            {
                await _dbContext.Items.AddAsync(new Item { Value = item.Value, DateUpdated = item.DateUpdated });
            }
            else {
                _item.Value = item.Value;
                _item.DateUpdated = item.DateUpdated;
            }

            _dbContext.SaveChanges();
            return await _dbContext.Items.Where(x => x.Id == item.Id).FirstOrDefaultAsync();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var _item = _dbContext.Items.Where(x => x.Id == id).FirstOrDefault();
            if (_item != default)
            {
                _dbContext.Items.Remove(_item);
            }
            _dbContext.SaveChanges();
        }
    }
}
