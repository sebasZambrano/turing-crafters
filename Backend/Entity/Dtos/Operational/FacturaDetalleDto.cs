using Entity.Dtos.Inventory;

namespace Entity.Dtos.Operational
{
    public class FacturaDetalleDto : BaseDto
    {
        public string Codigo { get; set; } = null!;
        public decimal Cantidad { get; set; }
        public decimal SubTotal { get; set; }
        public decimal PrecioProducto { get; set; }
        public decimal Descuento { get; set; }
        public decimal Iva { get; set; }
        public int FacturaId { get; set; }
        public string? Factura { get; set; }
        public int ProductoId { get; set; }
        public string? Producto { get; set; }
        public int EmpleadoId { get; set; }
        public List<DetalleInventarioBodegaDto> DetallesInventariosBodegas { get; set; } = null!;

    }
}
