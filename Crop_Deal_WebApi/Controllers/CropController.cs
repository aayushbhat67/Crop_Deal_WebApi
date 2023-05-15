using Crop_Deal_WebApi.Models;
using Crop_Deal_WebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crop_Deal_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CropController : ControllerBase
    {
        private readonly CropDealContext _dbContext;

        public CropController(CropDealContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Crop>>> GetCrops()
        {
            if (_dbContext.Crops == null)
            {
                return NotFound();
            }
            return await _dbContext.Crops.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Crop>> GetCrop(int id)
        {
            if (_dbContext.Crops == null)
            {
                return NotFound();
            }
            var crop = await _dbContext.Crops.FindAsync(id);
            if (crop == null)
            {
                return NotFound();
            }
            return crop;
        }

        [HttpPost]

        public async Task<ActionResult<Crop>> PostCrop(Crop crop)
        {
            _dbContext.Crops.Add(crop);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCrop), new { id = crop.Crop_id }, crop);
        }
        [HttpPut]
        public async Task<IActionResult> PutCrop(int id, Crop crop)
        {
            if (id != crop.Crop_id)
            {
                return BadRequest();
            }
            _dbContext.Entry(crop).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CropAvailable(id))
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
        private bool CropAvailable(int id)
        {
            return (_dbContext.Crops?.Any(x => x.Crop_id == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCrop(int id)
        {
            if (_dbContext.Crops == null)
            {
                return NotFound();
            }
            var crop = await _dbContext.Crops.FindAsync(id);
            if (crop == null)
            {
                return NotFound();
            }
            _dbContext.Crops.Remove(crop);

            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
