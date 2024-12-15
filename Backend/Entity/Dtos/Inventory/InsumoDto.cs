using Entity.Models;

namespace Entity.Dtos.Inventory
{
    public class InsumoDto : GenericDto
    {
        public string? Descripcion { get; set; }
        public int UnidadMedidaId { get; set; }
        public string? UnidadMedida { get; set; }
    }
}
