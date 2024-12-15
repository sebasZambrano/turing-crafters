using Entity.Models.Inventory;
using Entity.Models.Parameter;

namespace Entity.Models.Operational
{
    public class Costo : BaseModel
    {
        public string? Descripcion { get; set; }
        public DateTime FechaCosto { get; set; }
        public decimal Valor { get; set; }
        public bool PagoCaja { get; set; }
        public string? NumeroFactura { get; set; }
        public int TipoCostoId { get; set; }
        public int EmpleadoId { get; set; }
        public int ProveedorId { get; set; }
        public int CajaId { get; set; }
        public TipoCosto TipoCosto { get; set; } = new TipoCosto();
        public Proveedor Proveedor { get; set; } = new Proveedor();
        public Empleado Empleado { get; set; } = new Empleado();
        public Caja Caja { get; set; } = new Caja();
    }
}
