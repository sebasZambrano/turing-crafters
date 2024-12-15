namespace Entity.Dtos.Operational
{
    public class OrdenDto : BaseDto
    {
        public string Codigo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int CantidadPersonas { get; set; }
        public decimal Total { get; set; }
        public int MesaId { get; set; }
        public int EmpleadoId { get; set; }
        public int EstadoId { get; set; }
        public string? Mesa { get; set; } = null!;
        public string? Empleado { get; set; } = null!;
        public string? Estado { get; set; } = null!;
    }
}
