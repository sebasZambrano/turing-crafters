namespace Entity.Dtos.Parameter
{
    public class ConvenioDto : GenericDto
    {
        public decimal Descuento { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
