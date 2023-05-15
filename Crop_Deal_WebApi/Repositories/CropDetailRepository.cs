using Crop_Deal_WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Crop_Deal_WebApi.Repositories
{
    public class CropDetailRepository
    {
        private readonly CropDealContext _dbContext;

        public CropDetailRepository(CropDealContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<CropDetail> GetAllCropDetails()
        {
            return _dbContext.CropDetails.ToList();
        }

        public CropDetail GetCropDetailById(int id)
        {
            return _dbContext.CropDetails.FirstOrDefault(u => u.CropDetails_id == id);
        }

        public void AddCropDetail(CropDetail cropdetail)
        {
            _dbContext.CropDetails.Add(cropdetail);
            _dbContext.SaveChanges();
        }

        public void UpdateCropDetail(CropDetail cropdetail)
        {
            _dbContext.Entry(cropdetail).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteCropDetail(CropDetail cropdetail)
        {
            _dbContext.CropDetails.Remove(cropdetail);
            _dbContext.SaveChanges();
        }
    }
}
