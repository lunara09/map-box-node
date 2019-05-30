using assignment.Models;
using assignment.Xml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeachesController : Controller
    {

        private readonly BeachContext _context;

        public BeachesController(BeachContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BeachEf>>> Get()
        {
            return await _context.Beach.Include(l => l.Geometry).ToListAsync();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BeachEf>> GetTodoItem(long id)
        {
            var beachItem = await _context.Beach.FindAsync(id);
            if (beachItem == null)
            {
                return NotFound();
            }

            return beachItem;

        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
