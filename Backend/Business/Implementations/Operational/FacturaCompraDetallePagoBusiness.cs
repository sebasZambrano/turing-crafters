using AutoMapper;
using Business.Interfaces.Operational;
using Data.Interfaces;
using Data.Interfaces.Operational;
using Data.Interfaces.Parameter;
using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Dtos.Parameter;
using Entity.Models.Operational;
using Entity.Models.Parameter;

namespace Business.Implementations.Operational
{
    public class FacturaCompraDetallePagoBusiness : BaseModelBusiness<FacturaCompraDetallePago, FacturaCompraDetallePagoDto>, IFacturaCompraDetallePagoBusiness
    {
        private readonly IFacturaCompraDetallePagoData _data;
        private readonly IFacturaCompraData _dataFacturaCompra;
        private readonly IEstadoData _dataEstado;
        private readonly IEmpleadoData _dataEmpleado;
        private readonly IBaseModelData<TipoCosto, TipoCostoDto> _dataTipoCosto;
        private readonly ICostoBusiness _businessCosto;
        private readonly IMapper _mapper;

        public FacturaCompraDetallePagoBusiness(IFacturaCompraDetallePagoData data,
            IFacturaCompraData dataFacturaCompra,
            IEstadoData dataEstado,
            IEmpleadoData dataEmpleado,
            ICostoBusiness businessCosto,
            IBaseModelData<TipoCosto, TipoCostoDto> dataTipoCosto,
            IMapper mapper) : base(data, mapper)
        {
            _data = data;
            _dataFacturaCompra = dataFacturaCompra;
            _dataEstado = dataEstado;
            _dataTipoCosto = dataTipoCosto;
            _dataEmpleado = dataEmpleado;
            _businessCosto = businessCosto;
            _mapper = mapper;
        }

        public override async Task<FacturaCompraDetallePagoDto> Save(FacturaCompraDetallePagoDto dto)
        {
            //Consulto los detallespagos de la factura de compra
            IEnumerable<FacturaCompraDetallePagoDto> lstFacturaCompraDetallePagos = await _data.GetDataTable(new QueryFilterDto() { ForeignKey = dto.FacturaCompraId, NameForeignKey = "FacturaCompraId" });
            decimal ValorTotalPagos = lstFacturaCompraDetallePagos.Sum(i => i.Valor);

            //Consulto la factura de compra
            FacturaCompra facturaCompra = await _dataFacturaCompra.GetById(dto.FacturaCompraId);


            decimal saldo = facturaCompra.Total - ValorTotalPagos;
            FacturaCompraDetallePago detallePago = new FacturaCompraDetallePago();

            if (saldo > 0)
            {
                if (dto.Valor > saldo)
                {
                    throw new Exception("El abono es mayor al saldo pendiente.");
                }

                dto.CreateAt = DateTime.UtcNow.AddHours(-5);

                if (String.IsNullOrEmpty(detallePago.Observacion))
                {
                    detallePago.Observacion = $"Pago realizado a factura de compra # {facturaCompra.NumeroFactura}";
                }

                detallePago = _mapper.Map<FacturaCompraDetallePago>(dto);
                detallePago = await _data.Save(detallePago);

                facturaCompra.Saldo = saldo - detallePago.Valor;

                //Consulto el tipo costo
                TipoCosto tipoCosto = await _dataTipoCosto.GetByCode("COMPRAS");

                //Consulto el empleado
                Empleado empleado = await _dataEmpleado.GetById(detallePago.EmpleadoId);

                //Agrego un costo
                CostoDto costo = new CostoDto()
                {
                    Descripcion = $"Costo asociado a la factura de compra # {facturaCompra.NumeroFactura}",
                    FechaCosto = DateTime.UtcNow.AddHours(-5),
                    Valor = detallePago.Valor,
                    PagoCaja = detallePago.PagoCaja,
                    NumeroFactura = facturaCompra.NumeroFactura,
                    EmpleadoId = empleado.Id,
                    CajaId = empleado.CajaId,
                    TipoCostoId = tipoCosto.Id,
                    ProveedorId = facturaCompra.ProveedorId,
                    Activo = true,
                };

                costo = await _businessCosto.Save(costo);

                if (saldo == dto.Valor)
                {
                    //Actualizo el estado Pagada a la factura de compra
                    Estado estado = await _dataEstado.GetByCode("P");
                    if (facturaCompra.EstadoId != estado.Id)
                    {
                        facturaCompra.EstadoId = estado.Id;
                        await this._dataFacturaCompra.Update(facturaCompra);
                    }
                }

                await _dataFacturaCompra.Update(facturaCompra);
            }
            else
            {
                throw new Exception("No se realizo el abono, no hay un saldo pendiente.");
            }

            return _mapper.Map<FacturaCompraDetallePagoDto>(detallePago);
        }
    }
}
