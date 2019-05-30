using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment.Models;
using assignment.Xml;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XmlController : Controller
    {
        BeachContext beachContext;
        public XmlController(BeachContext context)
        {
           beachContext = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<BeachXml> Get()
        {
            XmlOperations xml = new XmlOperations();
            return xml.Deserialization().ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public void Get(int id)
        {

        }

        // POST api/<controller>
        [HttpPost]
        public string Post([FromBody]string value)
        {
            try
            {
                XmlOperations xml = new XmlOperations();
                var list = xml.Deserialization().ToList();
                //beachContext.Beach.RemoveRange(beachContext.Beach.ToList());
                List<BeachEf> beachEfs = new List<BeachEf>();
                List<CoordinatesEf> coordinatesEfs = new List<CoordinatesEf>();
                foreach (var t in list)
                {

                    CoordinatesEf coordinatesEf = new CoordinatesEf()
                    {
                        X = t.Geometry.X,
                        Y = t.Geometry.Y
                    };
                    coordinatesEfs.Add(coordinatesEf);

                    BeachEf beachEf = new BeachEf()
                    {
                        Id = t.Id,
                        Name = t.Name,
                        NameFr = t.NameFr,
                        Address = t.Address,
                        AddressFr = t.AddressFr,
                        BeachType = t.BeachType,
                        Accessible = t.Accessible,
                        Open = t.Open,
                        Notes = t.Notes,
                        ModifiedDate = t.ModifiedDate,
                        CreatedDate = t.CreatedDate,
                        Link = t.Link,
                        LinkFr = t.LinkFr,
                        LinkLabel = t.LinkLabel,
                        LinkLab1 = t.LinkLab1,
                        LinkDescr = t.LinkDescr,
                        LinkDes1 = t.LinkDes1,
                        PostalCode = t.PostalCode,
                        Photo = t.Photo,
                        Geometry = coordinatesEf
                    };
                    beachEfs.Add(beachEf);
                }
                beachContext.Beach.AddRange(beachEfs);
                beachContext.Geometry.AddRange(coordinatesEfs);
                beachContext.SaveChanges();
                return "Info added to database";
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                if (ex.HResult == -2146233088)
                    return "These records are already in the database";
                else
                    return ex.Message + "\nInner:" + ex.InnerException;
            }
            catch (Exception ex)
            {
                return ex.Message + "\nInner:" + ex.InnerException;
            }
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
