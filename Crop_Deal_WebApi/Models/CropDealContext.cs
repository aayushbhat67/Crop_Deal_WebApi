using Microsoft.EntityFrameworkCore;

namespace Crop_Deal_WebApi.Models
{ 

    public class CropDealContext : DbContext
    {
        public CropDealContext(DbContextOptions<CropDealContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Crop> Crops { get; set; }

        public DbSet<CropDetail> CropDetails { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
