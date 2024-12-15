using Entity.Dtos;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IBaseModelController<T, D> where T : BaseModel where D : BaseDto
    {
        Task<ActionResult<IEnumerable<D>>> GetAllSelect();

        Task<ActionResult<D>> GetById(int id);

        Task<ActionResult<D>> GetByCode(string code);

        Task<ActionResult<IEnumerable<D>>> GetDataTable([FromQuery] QueryFilterDto filters);

        Task<ActionResult<D>> Save(D dto);

        Task<ActionResult> Update(D dto);

        Task<ActionResult> Delete(int id);
    }
}