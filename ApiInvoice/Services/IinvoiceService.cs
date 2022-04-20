using ApiInvoice.Models;

namespace ApiInvoice.Services
{
    public interface IinvoiceService
    {
        List<Invoice> Get();
        Invoice Get(string id);
        Invoice Create(Invoice invoice);
        void Update(string id,Invoice invoice);
        void Remove(string id);
    }
}
