using Entity.Models.Parameter;

namespace Entity.Models.Operational
{
    public class CierreMedioPago : BaseModel
    {
        public decimal Total { get; set; }
        public bool Gasto { get; set; }
        public int CierreId { get; set; }
        public int MedioPagoId { get; set; }
        public Cierre Cierre { get; set; } = new Cierre();
        public MedioPago MedioPago { get; set; } = new MedioPago();

    }
}
