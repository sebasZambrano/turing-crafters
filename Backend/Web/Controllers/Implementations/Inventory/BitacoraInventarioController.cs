using Business.Interfaces;
using Business.Interfaces.Inventory;
using Entity.Dtos.Inventory;
using Entity.Models.Inventory;
using Web.Controllers.Interfaces.Inventory;

namespace Web.Controllers.Implementations.Inventory
{
    public class BitacoraInventarioController : BaseModelController<BitacoraInventario, BitacoraInventarioDto>, IBitacoraInventarioController
    {
        private readonly IBitacoraInventarioBusiness _business;

        public BitacoraInventarioController(IBaseModelBusiness<BitacoraInventario, BitacoraInventarioDto> baseBusiness, IBitacoraInventarioBusiness business) : base(baseBusiness)
        {
            _business = business;
        }
    }
}
