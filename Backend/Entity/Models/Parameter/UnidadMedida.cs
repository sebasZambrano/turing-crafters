using Entity.Models.Inventory;

namespace Entity.Models.Parameter
{
    public class UnidadMedida : GenericModel
    {
        public List<Insumo> Insumos { get; set; } = new List<Insumo>();
    }
}
