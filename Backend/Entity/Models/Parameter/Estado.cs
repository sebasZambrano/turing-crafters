using Entity.Models.Operational;

namespace Entity.Models.Parameter
{
    public class Estado: GenericModel
    {
        public int TipoEstadoId { get; set; }
        public TipoEstado TipoEstado { get; set; } = new TipoEstado();
        public List<FacturaCompra> FacturasCompras { get; set; } = new List<FacturaCompra>();
        public List<NotaCredito> NotasCreditos { get; set; } = new List<NotaCredito>();
        public List<Orden> Ordenes { get; set; } = new List<Orden>();
        public List<OrdenDetalle> OrdenesDetalles { get; set; } = new List<OrdenDetalle>();
        public List<Mesa> Mesas { get; set; } = new List<Mesa>();
    }
}
