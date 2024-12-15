namespace Entity.Dtos.Operational
{
    public class CreditoDto : BaseDto
    {
        public decimal Valor { get; set; }
        public int FacturaId { get; set; }
        public decimal Interes { get; set; } = 0;
        public string NumeroFactura { get; set; } = null!;
    }
}
