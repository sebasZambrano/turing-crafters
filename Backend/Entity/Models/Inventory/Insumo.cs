using Entity.Models.Operational;
using Entity.Models.Parameter;

namespace Entity.Models.Inventory
{
    public class Insumo : GenericModel
    {
        public string? Descripcion { get; set; }
        public int UnidadMedidaId { get; set; }
        public UnidadMedida UnidadMedida { get; set; } = new UnidadMedida();
        public List<InsumoProducto> InsumoProductos { get; set; } = new List<InsumoProducto>();
        public List<BitacoraFactura> BitacorasFacturas { get; set; } = new List<BitacoraFactura>();
    }
}
