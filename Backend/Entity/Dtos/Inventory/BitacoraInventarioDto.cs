using Entity.Models;

namespace Entity.Dtos.Inventory
{
    public class BitacoraInventarioDto : BaseDto
    {
        public string Codigo { get; set; } = null!;
        public decimal Cantidad { get; set; }
        public string? Observacion { get; set; }
        public int EmpleadoId { get; set; }
        public string? Empleado { get; set; }
        public int InsumoId { get; set; }
        public string? Insumo { get; set; }
    }
}
