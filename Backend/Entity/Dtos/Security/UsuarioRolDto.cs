namespace Entity.Dtos.Security
{
    public class UsuarioRolDto : BaseDto
    {
        public int UsuarioId { get; set; }
        public string? Usuario { get; set; }
        public int RolId { get; set; }
        public string? Rol { get; set; }

    }
}
