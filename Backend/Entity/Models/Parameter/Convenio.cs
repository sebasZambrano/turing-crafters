namespace Entity.Models.Parameter
{
    public class Convenio : GenericModel
    {
        public decimal Descuento { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
