using Entity.Models.Parameter;

namespace Entity.Models.Operational
{
    public class FacturaCompraDetallePago : BaseModel
    {
        public decimal Valor { get; set; }
        public bool PagoCaja { get; set; }
        public string? Observacion { get; set; }
        public int EmpleadoId { get; set; }
        public int MedioPagoId { get; set; }
        public int FacturaCompraId { get; set; }
        public Empleado Empleado { get; set; } = new Empleado();
        public MedioPago MedioPago { get; set; } = new MedioPago();
        public FacturaCompra FacturaCompra { get; set; } = new FacturaCompra();

    }
}
