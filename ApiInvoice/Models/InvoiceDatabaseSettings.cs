namespace ApiInvoice.Models
{
    public class InvoiceDatabaseSettings : IinvoiceDatabaseSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string InvoiceCollectionName { get; set; } = string.Empty;
    }
}
