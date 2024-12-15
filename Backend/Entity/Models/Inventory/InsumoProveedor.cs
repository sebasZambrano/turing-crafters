namespace Entity.Models.Inventory
{
    public class InsumoProveedor : BaseModel
    {
        public int ProveedorId { get; set; }
        public int InsumoId { get; set; }
        public Proveedor Proveedor { get; set; } = new Proveedor();
        public Insumo Insumo { get; set; } = new Insumo();

    }
}
