using Crop_Deal_WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Crop_Deal_WebApi.Repositories
{
    public class CropRepository
    {

        private readonly CropDealContext _dbContext;

            public CropRepository(CropDealContext dbContext)
            {
                _dbContext = dbContext;
        }

            public List<Crop> GetAllCrops()
            {
                return _dbContext.Crops.ToList();
            }

            public Crop GetCropById(int id)
            {
                return _dbContext.Crops.FirstOrDefault(u => u.Crop_id == id);
            }

            public void AddCrop(Crop crop)
            {
                _dbContext.Crops.Add(crop);
                _dbContext.SaveChanges();
            }

            public void UpdateCrop(Crop crop)
            {
                _dbContext.Entry(crop).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }

            public void DeleteCrop(Crop crop)
            {
                _dbContext.Crops.Remove(crop);
                _dbContext.SaveChanges();
            }
        }
    }

