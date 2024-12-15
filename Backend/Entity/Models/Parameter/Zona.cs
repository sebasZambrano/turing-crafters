namespace Entity.Models.Parameter
{
    public class Zona : GenericModel
    {
        public List<Salon> Salones { get; set; } = new List<Salon>();
    }
}
