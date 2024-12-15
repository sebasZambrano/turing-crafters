using Entity.Models.Inventory;
using Entity.Models.Operational;
using Entity.Models.Security;

namespace Entity.Models.Parameter
{
    public class Empleado : BaseModel
    {
        public string Codigo { get; set; } = null!;
        public int PersonaId { get; set; }
        public int EmpresaId { get; set; }
        public int CargoId { get; set; }
        public int  CajaId { get; set; }
        public Persona Persona { get; set; } = new Persona();
        public Empresa Empresa { get; set; } = new Empresa();
        public Cargo Cargo { get; set; } = new Cargo();
        public Caja Caja { get; set; } = new Caja();

        public List<Factura> Facturas { get; set; } = new List<Factura>();
        public List<Costo> Costos { get; set; } = new List<Costo>();
        public List<Cierre> Cierres { get; set; } = new List<Cierre>();
        public List<FacturaCompra> FacturasCompras { get; set; } = new List<FacturaCompra>();
        public List<BitacoraInventarioBodega> BitacorasInventariosBodegas { get; set; } = new List<BitacoraInventarioBodega>();
        public List<BitacoraFactura> BitacorasFacturas { get; set; } = new List<BitacoraFactura>();
        public List<Propina> Propinas { get; set; } = new List<Propina>();
        public List<Orden> Ordenes { get; set; } = new List<Orden>();
    }
}
