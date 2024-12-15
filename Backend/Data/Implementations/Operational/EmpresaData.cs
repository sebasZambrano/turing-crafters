using AutoMapper;
using Data.Interfaces.Operational;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Operational
{
    public class EmpresaData : BaseModelData<Empresa, EmpresaDto>, IEmpresaData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public EmpresaData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<EmpresaDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            emp.Id,
                            emp.Nit,
                            emp.RazonSocial,
                            emp.Activo,
                            emp.Direccion,
                            emp.Telefono,
                            emp.Email,
                            emp.Web,
                            emp.CiudadId,
                            emp.createAt,
                            ciu.Nombre AS Ciudad
                        FROM
                            Empresas AS emp
                            INNER JOIN Ciudades ciu ON emp.CiudadId = ciu.Id
                        WHERE emp.DeleteAt IS NULL ";

            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND emp." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(emp.Nit,emp.RazonSocial,emp.Activo,emp.Direccion,emp.Telefono,emp.Email,emp.Web,ciu.Nombre,)) " +
                    "LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "emp.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            IEnumerable<EmpresaDto> items = await _applicationContext.QueryAsync<EmpresaDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

            return items;
        }
    }
}
