using Entity.Models;

namespace Entity.Dtos.Inventory
{
    public class InsumoProveedorDto : BaseDto
    {
        public int ProveedorId { get; set; }
        public string? Proveedor { get; set; }
        public int InsumoId { get; set; }
        public string? Insumo { get; set; }
    }
}
