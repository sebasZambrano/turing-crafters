using Entity.Models.Parameter;

namespace Entity.Models.Inventory
{
    public class InsumoProducto : BaseModel
    {
        public bool Adicional { get; set; }
        public decimal Cantidad { get; set; }
        public int InsumoId { get; set; }
        public int ProductoId { get; set; }
        public int UnidadMedidaId { get; set; }
        public Insumo Insumo { get; set; } = new Insumo();
        public Producto Producto { get; set; } = new Producto();
        public UnidadMedida UnidadMedida { get; set; } = new UnidadMedida();
    }
}
