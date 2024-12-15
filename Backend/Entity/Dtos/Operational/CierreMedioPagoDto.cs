namespace Entity.Dtos.Operational
{
    public class CierreMedioPagoDto: BaseDto
    {
        public decimal Total { get; set; }
        public bool Gasto { get; set; }
        public int CierreId { get; set; }
        public string? Cierre { get; set; }
        public int MedioPagoId { get; set; }
        public string? MedioPago { get; set; }
    }
}
