using Business.Interfaces;
using Business.Interfaces.Inventory;
using Entity.Dtos.Inventory;
using Entity.Models.Inventory;
using Web.Controllers.Interfaces.Inventory;

namespace Web.Controllers.Implementations.Inventory
{
    public class BitacoraInventarioBodegaController : BaseModelController<BitacoraInventarioBodega, BitacoraInventarioBodegaDto>, IBitacoraInventarioBodegaController
    {
        private readonly IBitacoraInventarioBodegaBusiness _business;

        public BitacoraInventarioBodegaController(IBaseModelBusiness<BitacoraInventarioBodega, BitacoraInventarioBodegaDto> baseBusiness, IBitacoraInventarioBodegaBusiness business) : base(baseBusiness)
        {
            _business = business;
        }
    }
}
