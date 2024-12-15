namespace Entity.Dtos.Operational
{
    public class FacturaConvenioDto : BaseDto
    {
        public int FacturaId { get; set; }
        public string? Factura { get; set; }
        public int ConvenioId { get; set; }
        public string? Convenio { get; set; }
    }
}
