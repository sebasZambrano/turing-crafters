using Entity.Models.Inventory;
using Entity.Models.Operational;

namespace Entity.Models.Parameter
{
    public class Caja : GenericModel
    {
        public int BodegaId { get; set; }
        public Bodega Bodega { get; set; } = new Bodega();
        public List<Empleado> Empleados { get; set; } = new List<Empleado>();
        public List<Costo> Costos { get; set; } = new List<Costo>();
        public List<Factura> Facturas { get; set; } = new List<Factura>();
    } 
}
