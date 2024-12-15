namespace Entity.Models.Inventory
{
    public class DetalleInventarioBodega : BaseModel
    {
        public decimal Cantidad { get; set; }
        public int BodegaId { get; set; }
        public int InventarioDetalleId { get; set; }
        public Bodega Bodega { get; set; } = new Bodega();
        public InventarioDetalle InventarioDetalle { get; set; } = new InventarioDetalle();
        public List<BitacoraInventarioBodega> BitacorasInventariosBodegas { get; set; } = new List<BitacoraInventarioBodega>();

    }
}
