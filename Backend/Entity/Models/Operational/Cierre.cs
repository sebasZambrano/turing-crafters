using Entity.Models.Parameter;

namespace Entity.Models.Operational
{
    public class Cierre : BaseModel
    {
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public decimal TotalIngreso { get; set; }
        public decimal TotalEgreso { get; set; }
        public decimal SaldoCaja { get; set; }
        public decimal SaldoEmpleado { get; set; }
        public decimal Base { get; set; }
        public string? Observacion { get; set; }
        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; } = new Empleado();
        public List<CierreMedioPago> CierresMediosPagos { get; set; } = new List<CierreMedioPago>();
    }
}