using Entity.Models.Parameter;

namespace Entity.Models.Operational
{
    public class Orden : BaseModel
    {
        public string Codigo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int CantidadPersonas { get; set; }
        public decimal Total { get; set; }
        public int MesaId { get; set; }
        public int EmpleadoId { get; set; }
        public int EstadoId { get; set; }
        public Mesa Mesa { get; set; } = new Mesa();
        public Empleado Empleado { get; set; } = new Empleado();
        public Estado Estado { get; set; } = new Estado();
        public List<Factura> Facturas { get; set; } = new List<Factura>();
        public List<OrdenDetalle> OrdenesDetalles { get; set; } = new List<OrdenDetalle>();
    }
}
