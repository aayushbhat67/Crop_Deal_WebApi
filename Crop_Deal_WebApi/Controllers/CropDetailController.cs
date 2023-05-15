using Crop_Deal_WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crop_Deal_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CropDetailController : ControllerBase
    {
        private readonly CropDealContext _dbContext;

        public CropDetailController(CropDealContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CropDetail>>> GetCropDetails()
        {
            if (_dbContext.CropDetails == null)
            {
                return NotFound();
            }
            return await _dbContext.CropDetails.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CropDetail>> GetCropDetail(int id)
        {
            if (_dbContext.CropDetails == null)
            {
                return NotFound();
            }
            var cropdetail = await _dbContext.CropDetails.FindAsync(id);
            if (cropdetail == null)
            {
                return NotFound();
            }
            return cropdetail;
        }

        [HttpPost]

        public async Task<ActionResult<CropDetail>> PostCropDetail(CropDetail cropdetail)
        {
            _dbContext.CropDetails.Add(cropdetail);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCropDetail), new { id = cropdetail.CropDetails_id }, cropdetail);
        }
        [HttpPut]
        public async Task<IActionResult> PutCropDetail(int id, CropDetail cropdetail)
        {
            if (id != cropdetail.CropDetails_id)
            {
                return BadRequest();
            }
            _dbContext.Entry(cropdetail).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CropDetailAvailable(id))
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
        private bool CropDetailAvailable(int id)
        {
            return (_dbContext.CropDetails?.Any(x => x.CropDetails_id == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCropDetail(int id)
        {
            if (_dbContext.CropDetails == null)
            {
                return NotFound();
            }
            var cropdetail = await _dbContext.CropDetails.FindAsync(id);
            if (cropdetail == null)
            {
                return NotFound();
            }
            _dbContext.CropDetails.Remove(cropdetail);

            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
