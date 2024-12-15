using Entity.Models.Parameter;

namespace Entity.Models.Operational
{
    public class FacturaConvenio : BaseModel
    {
        public int FacturaId { get; set; }
        public int ConvenioId { get; set; }
        public Factura Factura { get; set; } = new Factura();
        public Convenio Convenio { get; set; } = new Convenio();
    }
}
