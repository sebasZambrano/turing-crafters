using Entity.Models.Inventory;

namespace Entity.Models.Operational
{
    public class FacturaCompraDetalle : BaseModel
    {
        public string Codigo { get; set; } = null!;
        public decimal Cantidad { get; set; }
        public decimal SubTotal { get; set; }
        public decimal PrecioCosto { get; set; }
        public decimal Descuento { get; set; }
        public decimal Iva { get; set; }
        public int FacturaCompraId { get; set; }
        public int InsumoId { get; set; }
        public FacturaCompra FacturaCompra { get; set; } = new FacturaCompra();
        public Insumo Insumo { get; set; } = new Insumo();

    }
}
