namespace Entity.Models.Security
{
    public class FormularioRol : BaseModel
    {
        public int FormularioId { get; set; }
        public Formulario Formulario { get; set; } = new Formulario();
        public int RolId { get; set; }
        public Rol Rol { get; set; } = new Rol();

    }
}
