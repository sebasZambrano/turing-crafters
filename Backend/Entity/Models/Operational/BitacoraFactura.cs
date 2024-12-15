using Entity.Models.Inventory;
using Entity.Models.Parameter;

namespace Entity.Models.Operational
{
    public class BitacoraFactura : BaseModel
    {
        public string Codigo { get; set; } = null!;
        public decimal Cantidad { get; set; }
        public string? Observacion { get; set; }
        public int EmpleadoId { get; set; }
        public int FacturaId { get; set; }
        public int InsumoId { get; set; }
        public Empleado Empleado { get; set; } = new Empleado();
        public Factura Factura { get; set; } = new Factura();
        public Insumo Insumo { get; set; } = new Insumo();
    }
}
