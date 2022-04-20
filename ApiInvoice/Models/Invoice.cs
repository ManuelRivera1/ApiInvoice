using MongoDB.Bson.Serialization.Attributes;

namespace ApiInvoice.Models
{
    [BsonIgnoreExtraElements]
    public class Invoice
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? codigofactura { get; set; }
        public string? cliente { get; set; }
        public string? ciudad { get; set; }
        public string? nit { get; set; }
        public Int64? totalfactura { get; set; }
        public Int64? subtotal { get; set; }
        public Int64? iva { get; set; }
        public Int64? retencion { get; set; }
        public string? fechacreacion { get; set; }
        public string? estado { get; set; }
        public bool pagado { get; set; }
        public string? fechapago { get; set; }
        public string? correo { get; set; }
    }
}
