namespace Entity.Dtos.Parameter
{
    public class NotificacionDto : BaseDto
    {
        public string Titulo { get; set; } = null!;
        public string Mensaje { get; set; } = null!;
        public string Url { get; set; } = null!;
        public int UsuarioId { get; set; }
        public string? Usuario { get; set; }

    }
}
