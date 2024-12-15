namespace Entity.Dtos.Inventory
{
    public class DetalleInventarioBodegaDto : BaseDto
    {
        public decimal Cantidad { get; set; }
        public decimal CantidadFacturar { get; set; }
        public int BodegaId { get; set; }
        public string? Bodega { get; set; }
        public int InventarioDetalleId { get; set; }
        public string? InventarioDetalle { get; set; }
        public string? Insumo { get; set; }
        public int FacturaCompraId { get; set; }
        public int EmpleadoId { get; set; }

    }
}
