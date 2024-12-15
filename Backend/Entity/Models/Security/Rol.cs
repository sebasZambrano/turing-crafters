namespace Entity.Models.Security
{
    public class Rol : GenericModel
    {
        public List<FormularioRol> FormulariosRoles { get; set; } = new List<FormularioRol>();
        public List<UsuarioRol> UsuariosRoles { get; set; } = new List<UsuarioRol>();
    }
}
