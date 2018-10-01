using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment3.Controllers
{
    public class EmployeesController : ApiController
    {
        private Manager m = new Manager();
        // GET: api/Employees
        public IHttpActionResult Get()
        {
            return Ok(m.EmployeeGetAll());   
        }

        // GET: api/Employees/5
        public IHttpActionResult Get(int id)
        {
            var result = m.GetEmployee(id);
            if (result == null)
                return NotFound();
            else
                return Ok(result);

        }

        // POST: api/Employees
        public IHttpActionResult Post([FromBody]EmployeeAdd newItem )
        {
            if(newItem == null) { return null;}
            if (ModelState.IsValid)
            {
                var addedItem = m.EmployeeAdd(newItem);
                if (addedItem == null)
                {       
                    return BadRequest("Cannot add the object");
                }
                else
                {             
                    var uri = Url.Link("DefaultApi", new { id = addedItem.EmployeeId });
                    return Created<EmployeeBase>(uri, addedItem);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
            

        }

        // PUT: api/Employees/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Employees/5
        public void Delete(int id)
        {
        }
    }
}
