using Entity.Models.Operational;
using Entity.Models.Parameter;

namespace Entity.Models.Inventory
{
    public class BitacoraInventarioBodega : BaseModel
    {
        public string Codigo { get; set; } = null!;
        public decimal Cantidad { get; set; }
        public string? Observacion { get; set; }
        public int DetalleInventarioBodegaId { get; set; }
        public int EmpleadoId { get; set; }
        public int? FacturaCompraId { get; set; }
        public DetalleInventarioBodega DetalleInventarioBodega { get; set; } = new DetalleInventarioBodega();
        public Empleado Empleado { get; set; } = new Empleado();
        public FacturaCompra? FacturaCompra { get; set; } = new FacturaCompra();
    }
}
