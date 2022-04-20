using ApiInvoice.Models;
using MongoDB.Driver;

namespace ApiInvoice.Services
{
    public class InvoiceService : IinvoiceService
    {
        private readonly IMongoCollection<Invoice> _invoices;
        public InvoiceService(IinvoiceDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _invoices = database.GetCollection<Invoice>(settings.InvoiceCollectionName);
        }
        public Invoice Create(Invoice invoice)
        {
            _invoices.InsertOne(invoice);
            return invoice;
        }

        public void Remove(string id)
        {
           _invoices.DeleteOne(invoice => invoice.Id == id);
        }

        public List<Invoice> Get()
        {
            return _invoices.Find(invoice => true).ToList();
            
        }

        public Invoice Get(string id)
        {
            try
            {
                return _invoices.Find(invoice => invoice.Id == id).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw new Exception("Error-" + ex);
            }
        }

        public void Update(string id, Invoice invoice)
        {
            try
            {
                _invoices.ReplaceOneAsync(invoice => invoice.Id == id, invoice);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
