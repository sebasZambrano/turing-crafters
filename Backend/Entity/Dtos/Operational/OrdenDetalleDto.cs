namespace Entity.Dtos.Operational
{
    public class OrdenDetalleDto : BaseDto
    {
        public string Codigo { get; set; } = null!;
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public string Observaciones { get; set; } = null!;
        public int OrdenId { get; set; }
        public int ProductoId { get; set; }
        public int EstadoId { get; set; }
        public string? Orden { get; set; } = null!;
        public string? Producto { get; set; } = null!;
        public string? Estado { get; set; } = null!;
    }
}
