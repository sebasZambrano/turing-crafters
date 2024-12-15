using AutoMapper;
using Entity.Dtos.Inventory;
using Entity.Dtos.Operational;
using Entity.Dtos.Parameter;
using Entity.Dtos.Security;
using Entity.Models.Inventory;
using Entity.Models.Operational;
using Entity.Models.Parameter;
using Entity.Models.Security;
using Utilities.Interfaces;

namespace Utilities.Implementations
{
    public class AutoMapperProfiles : Profile
    {
        private readonly IJwtAuthenticationService _jwtAuthenticationService;

        public AutoMapperProfiles(IJwtAuthenticationService jwtAuthenticationService) : base()
        {
            _jwtAuthenticationService = jwtAuthenticationService;
            //Inventory
            CreateMap<BitacoraInventarioDto, BitacoraInventario>().ReverseMap();
            CreateMap<BitacoraInventarioBodegaDto, BitacoraInventarioBodega>().ReverseMap();
            CreateMap<BodegaDto, Bodega>().ReverseMap();
            CreateMap<DetalleInventarioBodegaDto, DetalleInventarioBodega>().ReverseMap();
            CreateMap<InsumoDto, Insumo>().ReverseMap();
            CreateMap<InsumoProductoDto, InsumoProducto>().ReverseMap();
            CreateMap<InsumoProveedorDto, InsumoProveedor>().ReverseMap();
            CreateMap<InventarioDto, Inventario>().ReverseMap();
            CreateMap<InventarioDetalleDto, InventarioDetalle>().ReverseMap();
            CreateMap<ProductoDto, Producto>().ReverseMap();
            CreateMap<ProveedorDto, Proveedor>().ReverseMap();

            //Operational
            CreateMap<AbonoDto, Abono>().ReverseMap();
            CreateMap<BitacoraFacturaDto, BitacoraFactura>().ReverseMap();
            CreateMap<CreditoDto, Credito>().ReverseMap();
            CreateMap<CierreDto, Cierre>().ReverseMap();
            CreateMap<CierreMedioPagoDto, CierreMedioPago>().ReverseMap();
            CreateMap<CostoDto, Costo>().ReverseMap();
            CreateMap<FacturaDto, Factura>().ReverseMap();
            CreateMap<FacturaCompraDto, FacturaCompra>().ReverseMap();
            CreateMap<FacturaCompraDetalleDto, FacturaCompraDetalle>().ReverseMap();
            CreateMap<FacturaCompraDetallePagoDto, FacturaCompraDetallePago>().ReverseMap();
            CreateMap<FacturaConvenioDto, FacturaConvenio>().ReverseMap();
            CreateMap<FacturaDetalleDto, FacturaDetalle>().ReverseMap();
            CreateMap<FacturaDetallePagoDto, FacturaDetallePago>().ReverseMap();
            CreateMap<ModificacionProductoDto, ModificacionProducto>().ReverseMap();
            CreateMap<NotaCreditoDto, NotaCredito>().ReverseMap();
            CreateMap<NotaCreditoDetalleDto, NotaCreditoDetalle>().ReverseMap();
            CreateMap<OrdenDto, Orden>().ReverseMap();
            CreateMap<OrdenDetalleDto, OrdenDetalle>().ReverseMap();
            CreateMap<PropinaDto, Propina>().ReverseMap();

            //Parameter
            CreateMap<ArchivoDto, Archivo>().ReverseMap();
            CreateMap<BancoDto, Banco>().ReverseMap();
            CreateMap<CajaDto, Caja>().ReverseMap();
            CreateMap<CargoDto, Cargo>().ReverseMap();
            CreateMap<CategoriaDto, Categoria>().ReverseMap();
            CreateMap<ClienteDto, Cliente>().ReverseMap();
            CreateMap<ConfiguracionDto, Configuracion>().ReverseMap();
            CreateMap<ConvenioDto, Convenio>().ReverseMap();
            CreateMap<PaisDto, Pais>().ReverseMap();
            CreateMap<SalonDto, Salon>().ReverseMap();
            CreateMap<DepartamentoDto, Departamento>().ReverseMap();
            CreateMap<CiudadDto, Ciudad>().ReverseMap();
            CreateMap<EmpleadoDto, Empleado>().ReverseMap();
            CreateMap<EmpresaDto, Empresa>().ReverseMap();
            CreateMap<EstadoDto, Estado>().ReverseMap();
            CreateMap<ImpresoraCategoriaDto, ImpresoraCategoria>().ReverseMap();
            CreateMap<ImpresoraDto, Impresora>().ReverseMap();
            CreateMap<MacroCategoriaDto, MacroCategoria>().ReverseMap();
            CreateMap<MedioPagoDto, MedioPago>().ReverseMap();
            CreateMap<MesaDto, Mesa>().ReverseMap();
            CreateMap<MotivoDto, Motivo>().ReverseMap();
            CreateMap<NotificacionDto, Notificacion>().ReverseMap();
            CreateMap<NumeracionFacturaDto, NumeracionFactura>().ReverseMap();
            CreateMap<TipoCostoDto, TipoCosto>().ReverseMap();
            CreateMap<TipoEstadoDto, TipoEstado>().ReverseMap();
            CreateMap<UnidadMedidaDto, UnidadMedida>().ReverseMap();
            CreateMap<ZonaDto, Zona>().ReverseMap();

            //Security
            CreateMap<UsuarioDto, Usuario>()
              .ForMember(dest => dest.Password, opt => opt.MapFrom(src => _jwtAuthenticationService.EncryptMD5(src.Password)));
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<ModuloDto, Modulo>().ReverseMap();
            CreateMap<FormularioDto, Formulario>().ReverseMap();
            CreateMap<RolDto, Rol>().ReverseMap();
            CreateMap<FormularioRolDto, FormularioRol>().ReverseMap();
            CreateMap<PersonaDto, Persona>().ReverseMap();

            CreateMap<UsuarioRolDto, UsuarioRol>()
            .ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src.Usuario));

            CreateMap<UsuarioRol, UsuarioRolDto>()
                .ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src.Usuario));
        }
    }
}
