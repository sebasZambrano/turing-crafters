﻿using Entity.Dtos.Inventory;
using Entity.Models.Inventory;

namespace Web.Controllers.Interfaces.Inventory
{
    public interface IProductoController : IBaseModelController<Producto, ProductoDto>
    {
    }
}