using Entity.Models.Inventory;

namespace Entity.Models.Operational
{
    public class FacturaDetalle : BaseModel
    {
        public string Codigo { get; set; } = null!;
        public decimal Cantidad { get; set; }
        public decimal SubTotal { get; set; }
        public decimal PrecioProducto { get; set; }
        public decimal Descuento { get; set; }
        public decimal Iva { get; set; }
        public int FacturaId { get; set; }
        public int ProductoId { get; set; }
        public Factura Factura { get; set; } = new Factura();
        public Producto Producto { get; set; } = new Producto();
        public List<NotaCreditoDetalle> NotasCreditosDetalles { get; set; } = new List<NotaCreditoDetalle>();
    }
}
