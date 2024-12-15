using Entity.Models.Inventory;

namespace Entity.Models.Parameter
{
    public class Banco : GenericModel
    {
        public List<Proveedor> Proveedores { get; set; } = new List<Proveedor>();

    }
}
