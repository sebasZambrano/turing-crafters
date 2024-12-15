using Entity.Models.Inventory;
using Entity.Models.Parameter;

namespace Entity.Models.Operational
{
    public class OrdenDetalle : BaseModel
    {
        public string Codigo { get; set; } = null!;
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public string Observaciones { get; set; } = null!;
        public int OrdenId { get; set; }
        public int ProductoId { get; set; }
        public int EstadoId { get; set; }
        public Orden Orden { get; set; } = new Orden();
        public Producto Producto { get; set; } = new Producto();
        public Estado Estado { get; set; } = new Estado();
    }
}
