namespace Entity.Dtos.Operational
{
    public class FacturaCompraDetalleDto : BaseDto
    {
        public string Codigo { get; set; } = null!;
        public decimal Cantidad { get; set; }
        public decimal SubTotal { get; set; }
        public decimal PrecioCosto { get; set; }
        public decimal Descuento { get; set; }
        public decimal Iva { get; set; }
        public int FacturaCompraId { get; set; }
        public string? FacturaCompra { get; set; }
        public int InsumoId { get; set; }
        public string? Insumo { get; set; }
        public int EmpleadoId { get; set; }

    }
}
