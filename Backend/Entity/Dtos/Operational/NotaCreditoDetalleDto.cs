namespace Entity.Dtos.Operational
{
    public class NotaCreditoDetalleDto : BaseDto
    {
        public int NotaCreditoId { get; set; }
        public int FacturaDetalleId { get; set; }
        public decimal Cantidad { get; set; }
        public string? NotaCredito { get; set; } = null!;
        public string? FacturaDetalle { get; set; } = null!;

        //Producto
        public string? Codigo { get; set; } = null!;
        public string? Producto { get; set; } = null!;
        public int? ProductoId { get; set; }
        public decimal? PrecioProducto { get; set; }

    }
}
