using Entity.Models.Parameter;

namespace Entity.Models.Inventory
{
    public class BitacoraInventario : BaseModel
    {
        public string Codigo { get; set; } = null!;
        public decimal Cantidad { get; set; }
        public string? Observacion { get; set; }
        public int EmpleadoId { get; set; }
        public int InsumoId { get; set; }
        public Empleado Empleado { get; set; } = new Empleado();
        public Insumo Insumo { get; set; } = new Insumo();

    }
}
