using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment3.Controllers
{
    public class InvoiceController : ApiController
    {
        private Manager m = new Manager();
        // GET: api/Invoice
        public IHttpActionResult Get()
        {
            return Ok(m.InvoiceGetAll());
        }

        // GET: api/Invoice/5
        public IHttpActionResult Get(int id)
        {
            return Ok(m.GetInvoice(id));
        }

        // POST: api/Invoice
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Invoice/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Invoice/5
        public void Delete(int id)
        {
        }
    }
}
