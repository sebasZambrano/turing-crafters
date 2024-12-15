namespace Entity.Dtos.Inventory
{
    public class TrasladoBodegaDto
    {
        public int BodegaId { get; set; }
        public string? Bodega { get; set; }
        public decimal Cantidad { get; set; }
        public int BodegaDestinoId { get; set; }
        public string? BodegaDestino { get; set; }
        public int InventarioDetalleId { get; set; }
        public string? InventarioDetalle { get; set; }
        public int Existencias { get; set; }
        public int EmpleadoId { get; set; }
    }
}
