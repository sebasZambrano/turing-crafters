namespace Entity.Models.Security
{
    public class Formulario : GenericModel
    {
        public string Url { get; set; } = null!;
        public string Icono { get; set; } = null!;
        public int ModuloId { get; set; }
        public bool SuperAdmin { get; set; }
        public Modulo Modulo { get; set; } = new Modulo();
        public List<FormularioRol> FormulariosRoles { get; set; } = new List<FormularioRol>();
    }
}
