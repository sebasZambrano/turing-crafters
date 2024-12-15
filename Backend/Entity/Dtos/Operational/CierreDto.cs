namespace Entity.Dtos.Operational
{
    public class CierreDto: BaseDto
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
        public string? Empleado { get; set; }
        public int CajaId { get; set; }
    }
}
