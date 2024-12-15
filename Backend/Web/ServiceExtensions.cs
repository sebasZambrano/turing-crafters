using Business.Implementations;
using Business.Implementations.Inventory;
using Business.Implementations.Operational;
using Business.Implementations.Parameter;
using Business.Implementations.Security;
using Business.Interfaces;
using Business.Interfaces.Inventory;
using Business.Interfaces.Operational;
using Business.Interfaces.Parameter;
using Business.Interfaces.Security;
using Data.Implementations;
using Data.Implementations.Inventory;
using Data.Implementations.Operational;
using Data.Implementations.Paremeter;
using Data.Implementations.Security;
using Data.Interfaces;
using Data.Interfaces.Inventory;
using Data.Interfaces.Operational;
using Data.Interfaces.Parameter;
using Data.Interfaces.Security;
using Entity.Dtos.Inventory;
using Entity.Dtos.Operational;
using Entity.Dtos.Parameter;
using Entity.Dtos.Security;
using Entity.Models.Inventory;
using Entity.Models.Operational;
using Entity.Models.Parameter;
using Entity.Models.Security;

namespace Web
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(IServiceCollection services)
        {
            // BaseModel //
            //Inventory Producto
            services.AddScoped<IBaseModelBusiness<Producto, ProductoDto>, ProductoBusiness>();
            //Inventory BitacoraInventario
            services.AddScoped<IBaseModelBusiness<BitacoraInventario, BitacoraInventarioDto>, BitacoraInventarioBusiness>();
            //Inventory BitacoraInventarioBodega
            services.AddScoped<IBaseModelBusiness<BitacoraInventarioBodega, BitacoraInventarioBodegaDto>, BitacoraInventarioBodegaBusiness>();
            //Inventory Bodega
            services.AddScoped<IBaseModelBusiness<Bodega, BodegaDto>, BaseModelBusiness<Bodega, BodegaDto>>();
            services.AddScoped<IBaseModelData<Bodega, BodegaDto>, BaseModelData<Bodega, BodegaDto>>();
            //Inventory DetalleInventarioBodega
            services.AddScoped<IBaseModelBusiness<DetalleInventarioBodega, DetalleInventarioBodegaDto>, DetalleInventarioBodegaBusiness>();
            //Inventory Insumo
            services.AddScoped<IBaseModelBusiness<Insumo, InsumoDto>, InsumoBusiness>();
            //Inventory InsumoProducto
            services.AddScoped<IBaseModelBusiness<InsumoProducto, InsumoProductoDto>, InsumoProductoBusiness>();
            //Inventory InsumoProveedor
            services.AddScoped<IBaseModelBusiness<InsumoProveedor, InsumoProveedorDto>, BaseModelBusiness<InsumoProveedor, InsumoProveedorDto>>();
            services.AddScoped<IBaseModelData<InsumoProveedor, InsumoProveedorDto>, BaseModelData<InsumoProveedor, InsumoProveedorDto>>();
            //Inventory Inventario
            services.AddScoped<IBaseModelBusiness<Inventario, InventarioDto>, BaseModelBusiness<Inventario, InventarioDto>>();
            services.AddScoped<IBaseModelData<Inventario, InventarioDto>, BaseModelData<Inventario, InventarioDto>>();
            //Inventory InventarioDetalle
            services.AddScoped<IBaseModelBusiness<InventarioDetalle, InventarioDetalleDto>, InventarioDetalleBusiness>();
            //Inventory Proveedor
            services.AddScoped<IBaseModelBusiness<Proveedor, ProveedorDto>, ProveedorBusiness>();

            //Operational Abono
            services.AddScoped<IBaseModelBusiness<Abono, AbonoDto>, BaseModelBusiness<Abono, AbonoDto>>();
            services.AddScoped<IBaseModelData<Abono, AbonoDto>, BaseModelData<Abono, AbonoDto>>();
            //Operational BitacoraFactura
            services.AddScoped<IBaseModelBusiness<BitacoraFactura, BitacoraFacturaDto>, BitacoraFacturaBusiness>();
            //Operational Cierre
            services.AddScoped<IBaseModelBusiness<Cierre, CierreDto>, CierreBusiness>();
            //Operational CierreMedioPago
            services.AddScoped<IBaseModelBusiness<CierreMedioPago, CierreMedioPagoDto>, BaseModelBusiness<CierreMedioPago, CierreMedioPagoDto>>();
            services.AddScoped<IBaseModelData<CierreMedioPago, CierreMedioPagoDto>, BaseModelData<CierreMedioPago, CierreMedioPagoDto>>();
            //Operational Costo
            services.AddScoped<IBaseModelBusiness<Costo, CostoDto>, CostoBusiness>();
            //Operational Credito
            services.AddScoped<IBaseModelBusiness<Credito, CreditoDto>, BaseModelBusiness<Credito, CreditoDto>>();
            services.AddScoped<IBaseModelData<Credito, CreditoDto>, BaseModelData<Credito, CreditoDto>>();
            //Operational Factura
            services.AddScoped<IBaseModelBusiness<Factura, FacturaDto>, FacturaBusiness>();
            //Operational FacturaCompra
            services.AddScoped<IBaseModelBusiness<FacturaCompra, FacturaCompraDto>, FacturaCompraBusiness>();
            //Operational FacturaCompraDetalle
            services.AddScoped<IBaseModelBusiness<FacturaCompraDetalle, FacturaCompraDetalleDto>, FacturaCompraDetalleBusiness>();
            //Operational FacturaCompraDetallePago
            services.AddScoped<IBaseModelBusiness<FacturaCompraDetallePago, FacturaCompraDetallePagoDto>, FacturaCompraDetallePagoBusiness>();
            //Operational FacturaConvenio
            services.AddScoped<IBaseModelBusiness<FacturaConvenio, FacturaConvenioDto>, BaseModelBusiness<FacturaConvenio, FacturaConvenioDto>>();
            services.AddScoped<IBaseModelData<FacturaConvenio, FacturaConvenioDto>, BaseModelData<FacturaConvenio, FacturaConvenioDto>>();
            //Operational FacturaDetalle
            services.AddScoped<IBaseModelBusiness<FacturaDetalle, FacturaDetalleDto>, FacturaDetalleBusiness>();
            //Operational FacturaDetallePago
            services.AddScoped<IBaseModelBusiness<FacturaDetallePago, FacturaDetallePagoDto>, FacturaDetallePagoBusiness>();
            //Operational ModificacionProducto
            services.AddScoped<IBaseModelBusiness<ModificacionProducto, ModificacionProductoDto>, BaseModelBusiness<ModificacionProducto, ModificacionProductoDto>>();
            services.AddScoped<IBaseModelData<ModificacionProducto, ModificacionProductoDto>, BaseModelData<ModificacionProducto, ModificacionProductoDto>>();
            //Operational NotaCredito
            services.AddScoped<IBaseModelBusiness<NotaCredito, NotaCreditoDto>, NotaCreditoBusiness>();
            //Operational NotaCreditoDetalle
            services.AddScoped<IBaseModelBusiness<NotaCreditoDetalle, NotaCreditoDetalleDto>, NotaCreditoDetalleBusiness>();
            //Operational Orden
            services.AddScoped<IBaseModelBusiness<Orden, OrdenDto>, OrdenBusiness>();
            //Operational OrdenDetalle
            services.AddScoped<IBaseModelBusiness<OrdenDetalle, OrdenDetalleDto>, OrdenDetalleBusiness>();
            //Operational Propina
            services.AddScoped<IBaseModelBusiness<Propina, PropinaDto>, PropinaBusiness>();


            //Parameter Archivo
            services.AddScoped<IBaseModelBusiness<Archivo, ArchivoDto>, ArchivoBusiness>();
            //Parameter Banco
            services.AddScoped<IBaseModelBusiness<Banco, BancoDto>, BaseModelBusiness<Banco, BancoDto>>();
            services.AddScoped<IBaseModelData<Banco, BancoDto>, BaseModelData<Banco, BancoDto>>();
            //Parameter Caja
            services.AddScoped<IBaseModelBusiness<Caja, CajaDto>, CajaBusiness>();
            //Parameter Cargo
            services.AddScoped<IBaseModelBusiness<Cargo, CargoDto>, BaseModelBusiness<Cargo, CargoDto>>();
            services.AddScoped<IBaseModelData<Cargo, CargoDto>, BaseModelData<Cargo, CargoDto>>();
            //Parameter Categoria
            services.AddScoped<IBaseModelBusiness<Categoria, CategoriaDto>, CategoriaBusiness>();
            //Parameter Cliente
            services.AddScoped<IBaseModelBusiness<Cliente, ClienteDto>, ClienteBusiness>();
            services.AddScoped<IBaseModelData<Cliente, ClienteDto>, BaseModelData<Cliente, ClienteDto>>();
            //Parameter Configuracion
            services.AddScoped<IBaseModelBusiness<Configuracion, ConfiguracionDto>, BaseModelBusiness<Configuracion, ConfiguracionDto>>();
            services.AddScoped<IBaseModelData<Configuracion, ConfiguracionDto>, BaseModelData<Configuracion, ConfiguracionDto>>();
            //Parameter Convenio
            services.AddScoped<IBaseModelBusiness<Convenio, ConvenioDto>, BaseModelBusiness<Convenio, ConvenioDto>>();
            services.AddScoped<IBaseModelData<Convenio, ConvenioDto>, BaseModelData<Convenio, ConvenioDto>>();
            //Parameter Pais
            services.AddScoped<IBaseModelBusiness<Pais, PaisDto>, BaseModelBusiness<Pais, PaisDto>>();
            services.AddScoped<IBaseModelData<Pais, PaisDto>, BaseModelData<Pais, PaisDto>>();
            //Parameter Salon
            services.AddScoped<IBaseModelBusiness<Salon, SalonDto>, SalonBusiness>();
            //Parameter Departamento
            services.AddScoped<IBaseModelBusiness<Departamento, DepartamentoDto>, DepartamentoBusiness>();
            //Parameter Ciudad
            services.AddScoped<IBaseModelBusiness<Ciudad, CiudadDto>, CiudadBusiness>();
            //Parameter Empleado
            services.AddScoped<IBaseModelBusiness<Empleado, EmpleadoDto>, EmpleadoBusiness>();
            //Parameter Empresa
            services.AddScoped<IBaseModelBusiness<Empresa, EmpresaDto>, EmpresaBusiness>();
            //Parameter Estado
            services.AddScoped<IBaseModelBusiness<Estado, EstadoDto>, EstadoBusiness>();
            //Parameter ImpresoraCategoria
            services.AddScoped<IBaseModelBusiness<ImpresoraCategoria, ImpresoraCategoriaDto>, ImpresoraCategoriaBusiness>();
            //Parameter Impresora
            services.AddScoped<IBaseModelBusiness<Impresora, ImpresoraDto>, BaseModelBusiness<Impresora, ImpresoraDto>>();
            services.AddScoped<IBaseModelData<Impresora, ImpresoraDto>, BaseModelData<Impresora, ImpresoraDto>>();
            //Parameter MacroCategoria
            services.AddScoped<IBaseModelBusiness<MacroCategoria, MacroCategoriaDto>, BaseModelBusiness<MacroCategoria, MacroCategoriaDto>>();
            services.AddScoped<IBaseModelData<MacroCategoria, MacroCategoriaDto>, BaseModelData<MacroCategoria, MacroCategoriaDto>>();
            //Parameter MedioPago
            services.AddScoped<IBaseModelBusiness<MedioPago, MedioPagoDto>, BaseModelBusiness<MedioPago, MedioPagoDto>>();
            services.AddScoped<IBaseModelData<MedioPago, MedioPagoDto>, BaseModelData<MedioPago, MedioPagoDto>>();
            //Parameter Mesa
            services.AddScoped<IBaseModelBusiness<Mesa, MesaDto>, MesaBusiness>();
            //Parameter Motivo
            services.AddScoped<IBaseModelBusiness<Motivo, MotivoDto>, BaseModelBusiness<Motivo, MotivoDto>>();
            services.AddScoped<IBaseModelData<Motivo, MotivoDto>, BaseModelData<Motivo, MotivoDto>>();
            //Parameter Notificacion
            services.AddScoped<IBaseModelBusiness<Notificacion, NotificacionDto>, NotificacionBusiness>();
            //Parameter NumeracionFactura
            services.AddScoped<IBaseModelBusiness<NumeracionFactura, NumeracionFacturaDto>, NumeracionFacturaBusiness>();
            //Parameter TipoCosto
            services.AddScoped<IBaseModelBusiness<TipoCosto, TipoCostoDto>, BaseModelBusiness<TipoCosto, TipoCostoDto>>();
            services.AddScoped<IBaseModelData<TipoCosto, TipoCostoDto>, BaseModelData<TipoCosto, TipoCostoDto>>();
            //Parameter TipoEstado
            services.AddScoped<IBaseModelBusiness<TipoEstado, TipoEstadoDto>, BaseModelBusiness<TipoEstado, TipoEstadoDto>>();
            services.AddScoped<IBaseModelData<TipoEstado, TipoEstadoDto>, BaseModelData<TipoEstado, TipoEstadoDto>>();
            //Parameter UnidadMedida
            services.AddScoped<IBaseModelBusiness<UnidadMedida, UnidadMedidaDto>, BaseModelBusiness<UnidadMedida, UnidadMedidaDto>>();
            services.AddScoped<IBaseModelData<UnidadMedida, UnidadMedidaDto>, BaseModelData<UnidadMedida, UnidadMedidaDto>>();
            //Parameter Zona
            services.AddScoped<IBaseModelBusiness<Zona, ZonaDto>, BaseModelBusiness<Zona, ZonaDto>>();
            services.AddScoped<IBaseModelData<Zona, ZonaDto>, BaseModelData<Zona, ZonaDto>>();

            //Security Modulo
            services.AddScoped<IBaseModelBusiness<Modulo, ModuloDto>, BaseModelBusiness<Modulo, ModuloDto>>();
            services.AddScoped<IBaseModelData<Modulo, ModuloDto>, BaseModelData<Modulo, ModuloDto>>();
            //Security Formulario
            services.AddScoped<IBaseModelBusiness<Formulario, FormularioDto>, FormularioBusiness>();
            //Security Rol
            services.AddScoped<IBaseModelBusiness<Rol, RolDto>, BaseModelBusiness<Rol, RolDto>>();
            services.AddScoped<IBaseModelData<Rol, RolDto>, BaseModelData<Rol, RolDto>>();
            //Security FormularioRol
            services.AddScoped<IBaseModelBusiness<FormularioRol, FormularioRolDto>, FormularioRolBusiness>();
            //Security Persona
            services.AddScoped<IBaseModelBusiness<Persona, PersonaDto>, PersonaBusiness>();
            //Security Usuario
            services.AddScoped<IBaseModelBusiness<Usuario, UsuarioDto>, UsuarioBusiness>();
            //Security UsuarioRol
            services.AddScoped<IBaseModelBusiness<UsuarioRol, UsuarioRolDto>, UsuarioRolBusiness>();
            // BaseModel //


            // Agrega otros servicios especificos

            //Archivo
            services.AddScoped<IArchivoBusiness, ArchivoBusiness>();
            services.AddScoped<IArchivoData, ArchivoData>();

            //Proveedor
            services.AddScoped<IProveedorBusiness, ProveedorBusiness>();
            services.AddScoped<IProveedorData, ProveedorData>();

            //Persona
            services.AddScoped<IPersonaBusiness, PersonaBusiness>();
            services.AddScoped<IPersonaData, PersonaData>();

            //Formulario
            services.AddScoped<IFormularioBusiness, FormularioBusiness>();
            services.AddScoped<IFormularioData, FormularioData>();

            //FormularioRol
            services.AddScoped<IFormularioRolBusiness, FormularioRolBusiness>();
            services.AddScoped<IFormularioRolData, FormularioRolData>();

            //Usuario
            services.AddScoped<IUsuarioBusiness, UsuarioBusiness>();
            services.AddScoped<IUsuarioData, UsuarioData>();

            //Caja
            services.AddScoped<ICajaBusiness, CajaBusiness>();
            services.AddScoped<ICajaData, CajaData>();

            //Categoria
            services.AddScoped<ICategoriaBusiness, CategoriaBusiness>();
            services.AddScoped<ICategoriaData, CategoriaData>();

            //Ciudad
            services.AddScoped<ICiudadBusiness, CiudadBusiness>();
            services.AddScoped<ICiudadData, CiudadData>();

            //Departamento
            services.AddScoped<IDepartamentoBusiness, DepartamentoBusiness>();
            services.AddScoped<IDepartamentoData, DepartamentoData>();

            //Estado
            services.AddScoped<IEstadoBusiness, EstadoBusiness>();
            services.AddScoped<IEstadoData, EstadoData>();

            //BitacoraInventario
            services.AddScoped<IBitacoraInventarioBusiness, BitacoraInventarioBusiness>();
            services.AddScoped<IBitacoraInventarioData, BitacoraInventarioData>();

            //BitacoraInventarioBodega
            services.AddScoped<IBitacoraInventarioBodegaBusiness, BitacoraInventarioBodegaBusiness>();
            services.AddScoped<IBitacoraInventarioBodegaData, BitacoraInventarioBodegaData>();

            //Producto
            services.AddScoped<IProductoBusiness, ProductoBusiness>();
            services.AddScoped<IProductoData, ProductoData>();

            //Insumo
            services.AddScoped<IInsumoBusiness, InsumoBusiness>();
            services.AddScoped<IInsumoData, InsumoData>();

            //InsumoProducto
            services.AddScoped<IInsumoProductoBusiness, InsumoProductoBusiness>();
            services.AddScoped<IInsumoProductoData, InsumoProductoData>();

            //InventarioDetalle
            services.AddScoped<IInventarioDetalleBusiness, InventarioDetalleBusiness>();
            services.AddScoped<IInventarioDetalleData, InventarioDetalleData>();

            //DetalleInventarioBodega
            services.AddScoped<IDetalleInventarioBodegaBusiness, DetalleInventarioBodegaBusiness>();
            services.AddScoped<IDetalleInventarioBodegaData, DetalleInventarioBodegaData>();

            //Factura
            services.AddScoped<IFacturaBusiness, FacturaBusiness>();
            services.AddScoped<IFacturaData, FacturaData>();

            //FacturaDetalle
            services.AddScoped<IFacturaDetalleBusiness, FacturaDetalleBusiness>();
            services.AddScoped<IFacturaDetalleData, FacturaDetalleData>();

            //FacturaDetallePago
            services.AddScoped<IFacturaDetallePagoBusiness, FacturaDetallePagoBusiness>();
            services.AddScoped<IFacturaDetallePagoData, FacturaDetallePagoData>();

            //FacturaCompra
            services.AddScoped<IFacturaCompraBusiness, FacturaCompraBusiness>();
            services.AddScoped<IFacturaCompraData, FacturaCompraData>();

            //FacturaCompraDetalle
            services.AddScoped<IFacturaCompraDetalleBusiness, FacturaCompraDetalleBusiness>();
            services.AddScoped<IFacturaCompraDetalleData, FacturaCompraDetalleData>();

            //FacturaCompraDetallePago
            services.AddScoped<IFacturaCompraDetallePagoBusiness, FacturaCompraDetallePagoBusiness>();
            services.AddScoped<IFacturaCompraDetallePagoData, FacturaCompraDetallePagoData>();

            //Costo
            services.AddScoped<ICostoBusiness, CostoBusiness>();
            services.AddScoped<ICostoData, CostoData>();

            //Cierre
            services.AddScoped<ICierreBusiness, CierreBusiness>();
            services.AddScoped<ICierreData, CierreData>();

            //Empresa
            services.AddScoped<IEmpresaBusiness, EmpresaBusiness>();
            services.AddScoped<IEmpresaData, EmpresaData>();

            //Empleado
            services.AddScoped<IEmpleadoBusiness, EmpleadoBusiness>();
            services.AddScoped<IEmpleadoData, EmpleadoData>();

            //UsuarioRol
            services.AddScoped<IUsuarioRolBusiness, UsuarioRolBusiness>();
            services.AddScoped<IUsuarioRolData, UsuarioRolData>();

            //Notificacion
            services.AddScoped<INotificacionBusiness, NotificacionBusiness>();
            services.AddScoped<INotificacionData, NotificacionData>();

            //NumeracionFactura
            services.AddScoped<INumeracionFacturaBusiness, NumeracionFacturaBusiness>();
            services.AddScoped<INumeracionFacturaData, NumeracionFacturaData>();

            //NotaCredito
            services.AddScoped<INotaCreditoBusiness, NotaCreditoBusiness>();
            services.AddScoped<INotaCreditoData, NotaCreditoData>();

            //NotaCreditoDetalle
            services.AddScoped<INotaCreditoDetalleBusiness, NotaCreditoDetalleBusiness>();
            services.AddScoped<INotaCreditoDetalleData, NotaCreditoDetalleData>();

            //BitacoraFactura
            services.AddScoped<IBitacoraFacturaBusiness, BitacoraFacturaBusiness>();
            services.AddScoped<IBitacoraFacturaData, BitacoraFacturaData>();

            //Propina
            services.AddScoped<IPropinaBusiness, PropinaBusiness>();
            services.AddScoped<IPropinaData, PropinaData>();

            //ImpresoraCategoria
            services.AddScoped<IImpresoraCategoriaBusiness, ImpresoraCategoriaBusiness>();
            services.AddScoped<IImpresoraCategoriaData, ImpresoraCategoriaData>();

            //Salon
            services.AddScoped<ISalonBusiness, SalonBusiness>();
            services.AddScoped<ISalonData, SalonData>();

            //Mesa
            services.AddScoped<IMesaBusiness, MesaBusiness>();
            services.AddScoped<IMesaData, MesaData>();

            //Orden
            services.AddScoped<IOrdenBusiness, OrdenBusiness>();
            services.AddScoped<IOrdenData, OrdenData>();

            //OrdenDetalle
            services.AddScoped<IOrdenDetalleBusiness, OrdenDetalleBusiness>();
            services.AddScoped<IOrdenDetalleData, OrdenDetalleData>();

            //Cliente
            services.AddScoped<IClienteBusiness, ClienteBusiness>();
        }
    }
}