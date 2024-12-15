namespace Entity.Models.Parameter
{
    public class Departamento : GenericModel
    {
        public int PaisId { get; set; }
        public Pais Pais { get; set; } = new Pais();
        public List<Ciudad> Ciudades { get; set; } = new List<Ciudad>();

    }
}
