using ApiInvoice.Models;
using ApiInvoice.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiInvoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IinvoiceService invoiceService;

        public InvoiceController(IinvoiceService invoiceService)
        {
            this.invoiceService = invoiceService;
        }
        // GET: api/<InvoiceController>
        [HttpGet]
        public ActionResult<List<Invoice>> Get()
        {
            return invoiceService.Get();
        }

        // GET api/<InvoiceController>/cliente
        [HttpGet("{id}")]
        public ActionResult<Invoice> Get(string id)
        {
            var invoice = invoiceService.Get(id);
            if (invoice == null)
            {
                return NotFound($"El cliente con ID = {id} no se encuentra");
            }
            return invoice;
        }

        // POST api/<InvoiceController>
        [HttpPost]
        public ActionResult<Invoice> Post([FromBody] Invoice invoice)
        {
            invoiceService.Create(invoice);
            return CreatedAtAction(nameof(Get), new { id = invoice.Id }, invoice);
        }

        // PUT api/<InvoiceController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, Invoice invoice)
        {
            var existingInvoice = invoiceService.Get(id);
            if (existingInvoice == null) 
            {
                return NotFound($"El cliente con ID = {id} no se encuentra"); 
            }
            invoiceService.Update(id, invoice);
            //invoiceService.Update(existingInvoice.Id!, invoice);
            return NoContent();
        }

        // DELETE api/<InvoiceController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var invoice = invoiceService.Get(id);
            if (invoice == null) 
            { 
                return NotFound($"El cliente con ID = {id} no se encuentra"); 
            }
            invoiceService.Remove(invoice.Id);
            return Ok();
        }
    }
}
