using Crop_Deal_WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Crop_Deal_WebApi.Repositories
{
    public class BankRepository
    {
        
            private readonly CropDealContext _dbContext;

            public BankRepository(CropDealContext dbContext)
            {
                _dbContext = dbContext;
            }

            public List<Bank> GetAllBanks()
            {
                return _dbContext.Banks.ToList();
            }

            public Bank GetBankById(int id)
            {
            return _dbContext.Banks.FirstOrDefault(u => u.BankDetail_id == id);
            }

            public void AddBank(Bank bank)
            {
                _dbContext.Banks.Add(bank);
                _dbContext.SaveChanges();
            }

            public void UpdateBank(Bank bank)
            {
                _dbContext.Entry(bank).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }

            public void DeleteBank(Bank bank)
            {
                _dbContext.Banks.Remove(bank);
                _dbContext.SaveChanges();
            }

        
    }
    }

