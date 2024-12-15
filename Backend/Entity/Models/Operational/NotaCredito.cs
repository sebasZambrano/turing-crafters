using Entity.Models.Parameter;

namespace Entity.Models.Operational
{
    public class NotaCredito : BaseModel
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
        public Estado Estado { get; set; } = new Estado();
        public Motivo Motivo { get; set; } = new Motivo();
        public Factura Factura { get; set; } = new Factura();
        public Empleado Empleado { get; set; } = new Empleado();
        public MedioPago MedioPago { get; set; } = new MedioPago();
        public List<NotaCreditoDetalle> NotasCreditosDetalles { get; set; } = new List<NotaCreditoDetalle>();

    }
}
