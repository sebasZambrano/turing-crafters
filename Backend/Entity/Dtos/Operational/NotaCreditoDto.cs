namespace Entity.Dtos.Operational
{
    public class NotaCreditoDto : BaseDto
    {
        public string Codigo { get; set; } = null!;
        public string Concepto { get; set; } = null!;
        public string MetodoCredito { get; set; } = null!;
        public decimal Total { get; set; }
        public bool PagoCaja { get; set; }
        public int MotivoId { get; set; }
        public int EstadoId { get; set; }
        public int FacturaId { get; set; }
        public int EmpleadoId { get; set; }
        public int MedioPagoId { get; set; }
        public string? Estado { get; set; } = null!;
        public string? Motivo { get; set; } = null!;
        public string? Factura { get; set; } = null!;
        public string? Empleado { get; set; } = null!;
        public string? MedioPago { get; set; } = null!;
        public List<FacturaDetalleDto> FacturaDetalles { get; set; } = new List<FacturaDetalleDto>();
    }
}
