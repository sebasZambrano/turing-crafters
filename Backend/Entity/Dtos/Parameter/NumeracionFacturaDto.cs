namespace Entity.Dtos.Parameter
{
    public class NumeracionFacturaDto : GenericDto
    {
        public string Prefijo { get; set; } = null!;
        public int NumInicial { get; set; }
        public int NumFinal { get; set; }
        public int NumActual { get; set; }
        public string Resolucion { get; set; } = null!;
        public string Autorizacion { get; set; } = null!;
    }
}
