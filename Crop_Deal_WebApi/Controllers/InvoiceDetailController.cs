using Crop_Deal_WebApi.Models;
using Crop_Deal_WebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crop_Deal_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceDetailController : ControllerBase
    {
        private readonly CropDealContext _dbContext;

        public InvoiceDetailController(CropDealContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceDetail>>> GetInvoiceDetails()
        {
            if (_dbContext.InvoiceDetails == null)
            {
                return NotFound();
            }
            return await _dbContext.InvoiceDetails.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceDetail>> GetInvoiceDetail(int id)
        {
            if (_dbContext.InvoiceDetails == null)
            {
                return NotFound();
            }
            var invoice = await _dbContext.InvoiceDetails.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            return invoice;
        }

        [HttpPost]

        public async Task<ActionResult<InvoiceDetail>> PostInvoiceDetail(InvoiceDetail invoicedetail)
        {
            _dbContext.InvoiceDetails.Add(invoicedetail);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInvoiceDetail), new { id = invoicedetail.Invoice_id }, invoicedetail);
        }
        [HttpPut]
        public async Task<IActionResult> PutInvoiceDetail(int id, InvoiceDetail invoicedetail)
        {
            if (id != invoicedetail.Invoice_id)
            {
                return BadRequest();
            }
            _dbContext.Entry(invoicedetail).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceDetailAvailable(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }
            return Ok();
        }
        private bool InvoiceDetailAvailable(int id)
        {
            return (_dbContext.InvoiceDetails?.Any(x => x.Invoice_id == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoiceDetail(int id)
        {
            if (_dbContext.InvoiceDetails == null)
            {
                return NotFound();
            }
            var invoice = await _dbContext.InvoiceDetails.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            _dbContext.InvoiceDetails.Remove(invoice);

            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }

}
