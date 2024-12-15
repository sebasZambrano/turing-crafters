using Entity.Models.Parameter;

namespace Entity.Models.Operational
{
    public class Abono : BaseModel
    {
        public decimal Valor { get; set; }
        public int CreditoId { get; set; }
        public int MedioPagoId { get; set; }
        public string? Observacion { get; set; }

        public Credito Credito { get; set; } = new Credito();
        public MedioPago MedioPago { get; set; } = new MedioPago();
    }
}
