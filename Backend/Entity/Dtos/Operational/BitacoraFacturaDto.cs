namespace Entity.Dtos.Operational
{
    public class BitacoraFacturaDto : BaseDto
    {
        public string Codigo { get; set; } = null!;
        public decimal Cantidad { get; set; }
        public string? Observacion { get; set; }
        public int EmpleadoId { get; set; }
        public int FacturaId { get; set; }
        public int InsumoId { get; set; }
        public string? Empleado { get; set; } = null!;
        public string? Factura { get; set; } = null!;
        public string? Insumo { get; set; } = null!;
    }
}
