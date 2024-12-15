namespace Entity.Models.Security
{
    public class UsuarioRol: BaseModel
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = new Usuario();
        public int RolId { get; set; }
        public Rol Rol { get; set; } = new Rol();
    }
}
