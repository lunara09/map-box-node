using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace assignment.Controllers
{
    [Route("api/[controller]")]
    public class DistanceController : Controller
    {
        private readonly BeachContext _context;

        public DistanceController(BeachContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        public class Req
        {
            public long first;
            public long second;
        }

        // POST api/<controller>
        [HttpPost]
        public double Post([FromBody]Req value)
        {
            var t = _context.Beach.Include(l => l.Geometry);
            var g1 = t.Where(l => l.Id == value.first).First().Geometry;
            var g2 = t.Where(l => l.Id == value.second).First().Geometry;

            double dx = g1.X - g2.X;
            double dy = g1.Y - g2.Y;
            var res = Math.Sqrt(dx * dx + dy * dy);

            return res;
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
