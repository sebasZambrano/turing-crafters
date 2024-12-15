using Business.Interfaces;
using Entity.Dtos;
using Entity.Models;

namespace Business.Implementations
{
    public abstract class ABaseModelBusiness<T, D> : IBaseModelBusiness<T, D> where T : BaseModel where D : BaseDto
    {
        public abstract Task<int> Delete(int id);

        public abstract Task<List<D>> GetAllSelect();

        public abstract Task<D> GetByCode(string code);

        public abstract Task<D> GetById(int id);

        public abstract Task<List<D>> GetDataTable(QueryFilterDto filters);

        public abstract Task<D> Save(D entityDto);

        public abstract Task Update(D entityDto);
    }
}
