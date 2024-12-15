namespace Entity.Models.Operational
{
    public class Credito : BaseModel
    {
        public decimal Valor { get; set; }
        public int FacturaId { get; set; }
        public decimal Interes { get; set; } = 0;

        public Factura Factura { get; set; } = new Factura();
        public List<Abono> Abonos { get; set; } = new List<Abono>();
    }
}
