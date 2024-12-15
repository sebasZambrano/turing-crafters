namespace Entity.Dtos.Parameter
{
    public class ImpresoraCategoriaDto : BaseDto
    {
        public int CategoriaId { get; set; }
        public int ImpresoraId { get; set; }
        public int SalonId { get; set; }
        public string? Categoria { get; set; } = null!;
        public string? Impresora { get; set; } = null!;
        public string? Salon { get; set; } = null!;
    }
}
