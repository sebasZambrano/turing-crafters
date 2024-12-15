namespace Entity.Dtos.Parameter
{
    public class MesaDto : GenericDto
    {
        public string Descripcion { get; set; } = null!;
        public int Cupo { get; set; }
        public int SalonId { get; set; }
        public int? EstadoId { get; set; } = null!;
        public string? Salon { get; set; } = null!;
        public string? Estado { get; set; } = null!;
    }
}
