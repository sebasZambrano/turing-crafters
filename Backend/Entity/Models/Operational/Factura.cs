using Entity.Models.Parameter;

namespace Entity.Models.Operational
{
    public class Factura : BaseModel
    {
        public string NumeroFactura { get; set; } = null!;
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public decimal Descuento { get; set; }
        public decimal Iva { get; set; }
        public string? Observacion { get; set; }
        public bool Remision { get; set; } = false;
        public int ClienteId { get; set; }
        public int EstadoId { get; set; }
        public int EmpleadoId { get; set; }
        public int NumeracionFacturaId { get; set; }
        public int CajaId { get; set; }
        public int OrdenId { get; set; }
        public Cliente Cliente { get; set; } = new Cliente();
        public Estado Estado { get; set; } = new Estado();
        public Empleado Empleado { get; set; } = new Empleado();
        public NumeracionFactura NumeracionFactura { get; set; } = new NumeracionFactura();
        public Caja Caja { get; set; } = new Caja();
        public Orden Orden { get; set; } = new Orden();
        public List<FacturaDetalle> FacturasDetalles { get; set; } = new List<FacturaDetalle>();
        public List<FacturaDetallePago> FacturasDetallesPagos { get; set; } = new List<FacturaDetallePago>();
        public List<FacturaConvenio> FacturasConvenios { get; set; } = new List<FacturaConvenio>();
        public List<NotaCredito> NotasCreditos { get; set; } = new List<NotaCredito>();
        public List<BitacoraFactura> BitacorasFacturas { get; set; } = new List<BitacoraFactura>();
        public List<Propina> Propinas { get; set; } = new List<Propina>();
    }
}
