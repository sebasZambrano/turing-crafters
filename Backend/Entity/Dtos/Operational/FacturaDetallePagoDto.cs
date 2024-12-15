namespace Entity.Dtos.Operational
{
    public class FacturaDetallePagoDto : BaseDto
    {
        public decimal Valor { get; set; }
        public string? Observacion { get; set; }
        public int EmpleadoId { get; set; }
        public string? Empleado { get; set; }
        public int MedioPagoId { get; set; }
        public string? MedioPago { get; set; }
        public int FacturaId { get; set; }
        public string? Factura { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
    }
}
