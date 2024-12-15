namespace Entity.Models.Inventory
{
    public class InventarioDetalle : BaseModel
    {
        public decimal CantidadTotal { get; set; }
        public decimal CantidadUsada { get; set; }
        public decimal CantidadIngresada { get; set; }
        public decimal PrecioCosto { get; set; }
        public int InventarioId { get; set; }
        public int InsumoId { get; set; }
        public Inventario Inventario { get; set; } = new Inventario();
        public Insumo Insumo { get; set; } = new Insumo();
    }
}
