namespace Entity.Models.Security
{
    public class Usuario : BaseModel
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int PersonaId { get; set; }
        public Persona Persona { get; set; } = new Persona();
        public List<UsuarioRol> UsuariosRoles { get; set; } = new List<UsuarioRol>();
    }
}
