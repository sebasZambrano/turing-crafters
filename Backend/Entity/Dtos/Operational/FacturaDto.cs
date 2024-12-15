namespace Entity.Dtos.Operational
{
    public class FacturaDto : BaseDto
    {
        public string NumeroFactura { get; set; } = null!;
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public decimal Descuento { get; set; }
        public decimal Iva { get; set; }
        public string? Observacion { get; set; }
        public bool Remision { get; set; } = false;
        public int ClienteId { get; set; }
        public string? Cliente { get; set; }
        public int EstadoId { get; set; }
        public string? Estado { get; set; }
        public int EmpleadoId { get; set; }
        public string? Empleado { get; set; }
        public int NumeracionFacturaId { get; set; }
        public string? NumeracionFactura { get; set; }
        public int CajaId { get; set; }
        public int OrdenId { get; set; }
        public string? Caja { get; set; }
        public string? Pagos { get; set; }
    }
}
