namespace Entity.Models.Parameter
{
    public class Pais : GenericModel
    {
        public List<Departamento> Departamentos { get; set; } = new List<Departamento>();

    }
}
