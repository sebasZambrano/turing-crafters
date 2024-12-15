namespace Entity.Dtos.Operational
{
    public class FacturaCompraDto : BaseDto
    {
        public string NumeroFactura { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public decimal Descuento { get; set; }
        public decimal Iva { get; set; }
        public bool PagoCaja { get; set; }
        public int ProveedorId { get; set; }
        public string? Proveedor { get; set; }
        public int EstadoId { get; set; }
        public string? Estado { get; set; }
        public int EmpleadoId { get; set; }
        public string? Empleado { get; set; }
        public int MedioPagoId { get; set; }
        public decimal Saldo { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
    }
}
