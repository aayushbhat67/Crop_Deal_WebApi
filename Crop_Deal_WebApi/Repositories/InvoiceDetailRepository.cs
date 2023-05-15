using Crop_Deal_WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Crop_Deal_WebApi.Repositories
{
    public class InvoiceDetailRepository
    {
        private readonly CropDealContext _dbContext;

        public InvoiceDetailRepository(CropDealContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<InvoiceDetail> GetAllInvoiceDetails()
        {
            return _dbContext.InvoiceDetails.ToList();
        }

        public InvoiceDetail GetInvoiceDetailById(int id)
        {
            return _dbContext.InvoiceDetails.FirstOrDefault(u => u.Invoice_id == id);
        }

        public void AddInvoiceDetail(InvoiceDetail invoicedetail)
        {
            _dbContext.InvoiceDetails.Add(invoicedetail);
            _dbContext.SaveChanges();
        }

        public void UpdateInvoiceDetail(InvoiceDetail invoicedetail)
        {
            _dbContext.Entry(invoicedetail).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteInvoiceDetail(InvoiceDetail invoicedetail)
        {
            _dbContext.InvoiceDetails.Remove(invoicedetail);
            _dbContext.SaveChanges();
        }

        internal void DeleteInvoiceDetail(object invoicedetail)
        {
            throw new NotImplementedException();
        }
    }
}
