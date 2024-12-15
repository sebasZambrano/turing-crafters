namespace Entity.Dtos.Inventory
{
    public class BitacoraInventarioBodegaDto : BaseDto
    {
        public string Codigo { get; set; } = null!;
        public decimal Cantidad { get; set; }
        public string? Observacion { get; set; }
        public int DetalleInventarioBodegaId { get; set; }
        public int EmpleadoId { get; set; }
        public int? FacturaCompraId { get; set; }
        public string? DetalleInventarioBodega { get; set; } = null!;
        public string? Empleado { get; set; } = null!;
        public string? FacturaCompra { get; set; } = null!;
        public int? InsumoId { get; set; } = null!;
        public string? Insumo { get; set; } = null!;
    }
}
