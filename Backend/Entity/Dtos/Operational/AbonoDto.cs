namespace Entity.Dtos.Operational
{
    public class AbonoDto : BaseDto
    {
        public decimal Valor { get; set; }
        public int CreditoId { get; set; }
        public string? Credito { get; set; }
        public int MedioPagoId { get; set; }
        public string? MedioPago { get; set; }
        public string? Observacion { get; set; }
    }
}
