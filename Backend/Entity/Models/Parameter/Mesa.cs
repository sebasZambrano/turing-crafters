using Entity.Models.Operational;

namespace Entity.Models.Parameter
{
    public class Mesa : GenericModel
    {
        public string Descripcion { get; set; } = null!;
        public int Cupo { get; set; }
        public int SalonId { get; set; }
        public int EstadoId { get; set; }
        public Salon Salon { get; set; } = new Salon();
        public Estado Estado { get; set; } = new Estado();
        public List<Orden> Ordenes { get; set; } = new List<Orden>();
    }
}
