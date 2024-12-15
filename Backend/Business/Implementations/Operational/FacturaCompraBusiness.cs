using AutoMapper;
using Business.Interfaces.Operational;
using Data.Interfaces.Operational;
using Data.Interfaces.Parameter;
using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Models.Operational;
using Entity.Models.Parameter;

namespace Business.Implementations.Operational
{
    public class FacturaCompraBusiness : BaseModelBusiness<FacturaCompra, FacturaCompraDto>, IFacturaCompraBusiness
    {
        private readonly IFacturaCompraData _data;
        private readonly IEstadoData _dataEstado;
        private readonly IFacturaCompraDetallePagoBusiness _businessFacturaCompraDetallePago;
        private readonly IMapper _mapper;

        public FacturaCompraBusiness(IFacturaCompraData data,
            IEstadoData dataEstado,
            IFacturaCompraDetallePagoBusiness businessFacturaCompraDetallePago,
            IMapper mapper) : base(data, mapper)
        {
            _data = data;
            _dataEstado = dataEstado;
            _businessFacturaCompraDetallePago = businessFacturaCompraDetallePago;
            _mapper = mapper;
        }

        public async Task<List<FacturaCompraDto>> GetDebtsDate(QueryFilterDto filter, string parametro)
        {
            Estado estado = await _dataEstado.GetByCode("PP");
            return (List<FacturaCompraDto>)await _data.GetDebtsDate(filter, parametro, estado.Id);
        }

        public async Task<List<FacturaCompraDto>> GetDebtsCalendar(QueryFilterDto filter, string parametro)
        {
            Estado estado = await _dataEstado.GetByCode("PP");
            return (List<FacturaCompraDto>)await _data.GetDebtsCalendar(filter, parametro, estado.Id);
        }

        public override async Task<FacturaCompraDto> Save(FacturaCompraDto dto)
        {
            //Generar codigo
            IEnumerable<FacturaCompraDto> facturas = await _data.GetDataTable(new QueryFilterDto { Filter = "" });
            int cantidadFacturas = facturas.Count() + 1;
            string codigo = $"FC-{DateTime.UtcNow.AddHours(-5).Year}-{cantidadFacturas.ToString().PadLeft(4, '0')}";

            //Consulto el estado
            Estado estado = await _dataEstado.GetById(dto.EstadoId);

            //Actualizo el dto
            dto.NumeroFactura = codigo;
            dto.CreateAt = DateTime.UtcNow.AddHours(-5);
            dto.Saldo = dto.Total;

            FacturaCompra factura = _mapper.Map<FacturaCompra>(dto);
            factura = await _data.Save(factura);

            if (estado.Codigo == "P")
            {

                //Agregar un detallePago por el total de la factura de compra
                FacturaCompraDetallePagoDto detallePago = new FacturaCompraDetallePagoDto()
                {
                    Valor = factura.Total,
                    PagoCaja = factura.PagoCaja,
                    Observacion = $"Pago realizado a factura de compra # {factura.NumeroFactura}",
                    EmpleadoId = factura.EmpleadoId,
                    MedioPagoId = dto.MedioPagoId,
                    FacturaCompraId = factura.Id,
                };

                detallePago = await _businessFacturaCompraDetallePago.Save(detallePago);

                //Actualizo el saldo de la factura de compra
                factura.Saldo = 0;
                await _data.Update(factura);
            }

            return _mapper.Map<FacturaCompraDto>(factura);
        }
    }
}
