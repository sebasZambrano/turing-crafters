namespace Entity.Dtos.Security
{
    public class UsuarioDto : BaseDto
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int PersonaId { get; set; }
        public string? Persona { get; set; }
    }
}
