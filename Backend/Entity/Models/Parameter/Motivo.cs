using Entity.Models.Operational;

namespace Entity.Models.Parameter
{
    public class Motivo : GenericModel
    {
        public string Descripcion { get; set; } = null!;
        public List<NotaCredito> NotasCreditos { get; set; } = new List<NotaCredito>();
    }
}
