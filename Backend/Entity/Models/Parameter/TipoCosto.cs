using Entity.Models.Operational;

namespace Entity.Models.Parameter
{
    public class TipoCosto : GenericModel
    {
        public List<Costo> Costos { get; set; } = new List<Costo>();
    }
}
