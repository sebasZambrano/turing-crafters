using Entity.Models.Operational;
using Entity.Models.Parameter;

namespace Entity.Models.Inventory
{
    public class Producto : GenericModel
    {
        public string DescripcionCorta { get; set; } = null!;
        public string DescripcionLarga { get; set; } = null!;
        public decimal Precio { get; set; }
        public decimal PrecioCosto { get; set; }
        public decimal Descuento { get; set; }
        public decimal Iva { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; } = new Categoria();
        public List<InsumoProducto> InsumoProductos { get; set; } = new List<InsumoProducto>();
        public List<OrdenDetalle> OrdenesDetalles { get; set; } = new List<OrdenDetalle>();
    }
}
