namespace Entity.Dtos.Operational
{
    public class PropinaDto : BaseDto
    {
        public decimal Valor { get; set; }
        public decimal Procentaje { get; set; }
        public bool Liquidado { get; set; }
        public int EmpleadoId { get; set; }
        public int FacturaId { get; set; }
        public int MedioPagoId { get; set; }
        public string? Empleado { get; set; } = null!;
        public string? Factura { get; set; } = null!;
        public string? MedioPago { get; set; } = null!;
    }
}
