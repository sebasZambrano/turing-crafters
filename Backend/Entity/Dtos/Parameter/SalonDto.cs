using Entity.Models.Parameter;

namespace Entity.Dtos.Parameter
{
    public class SalonDto : GenericDto
    {
        public int ZonaId { get; set; }
        public string Descripcion { get; set; } = null!;
        public string? Zona { get; set; } = null!;
    }
}
