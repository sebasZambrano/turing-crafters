using AutoMapper;
using Data.Interfaces;
using Entity.Dtos;
using Entity.Models;

namespace Business.Implementations
{
    public class BaseModelBusiness<T, D> : ABaseModelBusiness<T, D> where T : BaseModel where D : BaseDto
    {
        private readonly IBaseModelData<T,D> _data;
        private readonly IMapper _mapper;

        public BaseModelBusiness(IBaseModelData<T, D> data, IMapper mapper)
        {
            _data = data;
            _mapper = mapper;
        }

        public override async Task<int> Delete(int id)
        {
             return await _data.Delete(id);
        }

        public override async Task<List<D>> GetAllSelect()
        {
            IEnumerable<D> lstDto = await _data.GetAllSelect();
            return lstDto.ToList();
        }

        public override async Task<D> GetByCode(string code)
        {
            BaseModel entity = await _data.GetByCode(code);
            BaseDto dto = _mapper.Map<D>(entity);
            return (D)dto;
        }

        public override async Task<D> GetById(int id)
        {
            T entity = await _data.GetById(id); 
            D dto = _mapper.Map<D>(entity);
            return dto;
        }

        public override async Task<List<D>> GetDataTable(QueryFilterDto filters)
        {
            return (List<D>)await _data.GetDataTable(filters);
        }

        public override async Task<D> Save(D dto)
        {
            dto.CreateAt = DateTime.UtcNow.AddHours(-5);
            BaseModel entity = _mapper.Map<T>(dto);
            entity = await _data.Save((T)entity);
            return _mapper.Map<D>(entity); 
        }

        public override async Task Update(D dto)
        {
            BaseModel entity = _mapper.Map<T>(dto);
            entity.UpdateAt = DateTime.UtcNow.AddHours(-5);
            await _data.Update((T)entity);
        }

    }
}
