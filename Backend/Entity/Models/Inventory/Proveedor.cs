using Entity.Models.Operational;
using Entity.Models.Parameter;

namespace Entity.Models.Inventory
{
    public class Proveedor : BaseModel
    {
        public string? NumeroCuenta { get; set; }
        public int EmpresaId { get; set; }
        public int BancoId { get; set; }
        public Banco Banco { get; set; } = new Banco();
        public Empresa Empresa { get; set; } = new Empresa();

        
        public List<Costo> Costos { get; set; } = new List<Costo>();
        public List<FacturaCompra> FacturasCompras { get; set; } = new List<FacturaCompra>();
    }
}
