using Crop_Deal_WebApi.Models;
using Crop_Deal_WebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crop_Deal_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly CropDealContext _dbContext;

        public BankController(CropDealContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bank>>> GetBanks()
        {
            if (_dbContext.Banks == null)
            {
                return NotFound();
            }
            return await _dbContext.Banks.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bank>> GetBank(int id)
        {
            if (_dbContext.Banks == null)
            {
                return NotFound();
            }
            var bank = await _dbContext.Banks.FindAsync(id);
            if (bank == null)
            {
                return NotFound();
            }
            return bank;
        }

        [HttpPost]

        public async Task<ActionResult<Bank>> PostBank(Bank bank)
        {
            _dbContext.Banks.Add(bank);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBank), new { id = bank.BankDetail_id }, bank);
        }
        [HttpPut]
        public async Task<IActionResult> PutBank(int id, Bank bank)
        {
            if (id != bank.BankDetail_id)
            {
                return BadRequest();
            }
            _dbContext.Entry(bank).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankAvailable(id))
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
        private bool BankAvailable(int id)
        {
            return (_dbContext.Banks?.Any(x => x.BankDetail_id == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBank(int id)
        {
            if (_dbContext.Banks == null)
            {
                return NotFound();
            }
            var bank = await _dbContext.Banks.FindAsync(id);
            if (bank == null)
            {
                return NotFound();
            }
            _dbContext.Banks.Remove(bank);

            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}


