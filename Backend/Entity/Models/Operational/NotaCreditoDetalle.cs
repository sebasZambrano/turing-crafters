namespace Entity.Models.Operational
{
    public class NotaCreditoDetalle : BaseModel
    {
        public int NotaCreditoId { get; set; }
        public int FacturaDetalleId { get; set; }
        public decimal Cantidad { get; set; }
        public NotaCredito NotaCredito { get; set; } = new NotaCredito();
        public FacturaDetalle FacturaDetalle { get; set; } = new FacturaDetalle();
    }
}
