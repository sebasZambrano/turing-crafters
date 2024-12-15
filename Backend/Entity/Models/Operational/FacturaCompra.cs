using Entity.Models.Inventory;
using Entity.Models.Parameter;

namespace Entity.Models.Operational
{
    public class FacturaCompra : BaseModel
    {
        public string NumeroFactura { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public decimal Descuento { get; set; }
        public decimal Iva { get; set; }
        public bool PagoCaja { get; set; }
        public int ProveedorId { get; set; }
        public int EstadoId { get; set; }
        public int EmpleadoId { get; set; }
        public decimal Saldo { get; set; }
        public Proveedor Proveedor { get; set; } = new Proveedor();
        public Estado Estado { get; set; } = new Estado();
        public Empleado Empleado { get; set; } = new Empleado();

        public List<FacturaCompraDetallePago> FacturasComprasDetallesPagos { get; set; } = new List<FacturaCompraDetallePago>();
    }
}
