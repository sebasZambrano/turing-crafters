using Entity.Models.Operational;

namespace Entity.Models.Parameter
{
    public class NumeracionFactura : GenericModel
    {
        public string Prefijo {  get; set; } = null!;
        public int NumInicial { get; set; }
        public int NumFinal { get; set; }
        public int NumActual { get; set; }
        public string Resolucion { get; set; } = null!;
        public string Autorizacion { get; set; } = null!;

        public List<Factura> Facturas { get; set;} = new List<Factura>();
    }
}
