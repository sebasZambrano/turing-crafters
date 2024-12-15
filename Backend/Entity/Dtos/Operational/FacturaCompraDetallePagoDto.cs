namespace Entity.Dtos.Operational
{
    public class FacturaCompraDetallePagoDto : BaseDto
    {
        public decimal Valor { get; set; }
        public bool PagoCaja { get; set; }
        public string? Observacion { get; set; }
        public int EmpleadoId { get; set; }
        public string? Empleado { get; set; }
        public int MedioPagoId { get; set; }
        public string? MedioPago { get; set; }
        public int FacturaCompraId { get; set; }
        public string? FacturaCompra { get; set; }
    }
}
