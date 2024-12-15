using Entity.Models.Operational;

namespace Entity.Models.Parameter
{
    public class MedioPago : GenericModel
    {
        public List<Abono> Abonos { get; set; } = new List<Abono>();
        public List<CierreMedioPago> CierresMediosPagos { get; set; } = new List<CierreMedioPago>();
        public List<FacturaCompraDetallePago> FacturasComprasDetallesPagos { get; set; } = new List<FacturaCompraDetallePago>();
        public List<FacturaDetallePago> FacturasDetallesPagos { get; set; } = new List<FacturaDetallePago>();
        public List<NotaCredito> NotasCreditos { get; set; } = new List<NotaCredito>();
        public List<Propina> Propinas { get; set; } = new List<Propina>();
    }
}