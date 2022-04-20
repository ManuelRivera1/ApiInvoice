namespace ApiInvoice.Models
{
    public interface IinvoiceDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string InvoiceCollectionName { get; set; }
    }
}
