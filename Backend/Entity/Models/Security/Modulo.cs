namespace Entity.Models.Security
{
    public class Modulo: GenericModel
    {
        public string Icono { get; set; } = null!;
        public List<Formulario> Formularios { get; set; } = new List<Formulario>();

    }
}
