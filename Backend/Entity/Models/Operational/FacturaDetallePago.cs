using Entity.Models.Parameter;

namespace Entity.Models.Operational
{
    public class FacturaDetallePago : BaseModel
    {
        public decimal Valor { get; set; }
        public string? Observacion { get; set; }
        public int EmpleadoId { get; set; }
        public int MedioPagoId { get; set; }
        public int FacturaId { get; set; }
        public Empleado Empleado { get; set; } = new Empleado();
        public MedioPago MedioPago { get; set; } = new MedioPago();
        public Factura Factura { get; set; } = new Factura();

    }
}
