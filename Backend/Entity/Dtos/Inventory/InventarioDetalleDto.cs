namespace Entity.Dtos.Inventory
{
    public class InventarioDetalleDto : BaseDto
    {
        public decimal CantidadTotal { get; set; }
        public decimal CantidadUsada { get; set; }
        public decimal CantidadIngresada { get; set; }
        public decimal PrecioCosto { get; set; }
        public int InventarioId { get; set; }
        public string? Inventario { get; set; }
        public int InsumoId { get; set; }
        public string? Insumo { get; set; }
        public decimal CantidadPendienteAsignar { get; set; }
    }
}
