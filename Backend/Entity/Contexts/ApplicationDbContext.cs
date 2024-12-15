using Dapper;
using Entity.Models.Inventory;
using Entity.Models.Parameter;
using Entity.Models.Operational;
using Entity.Models.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Reflection;

namespace Entity.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
        : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            DataInicial.Data(modelBuilder);
            base.OnModelCreating(modelBuilder);

        }

        /// <summary>
        ///es una opción en Entity Framework Core que controla si se deben registrar o no datos sensibles (como valores de parámetros de consulta)
        ///durante la ejecución de consultas y operaciones en la base de datos.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            // otras configuraciones...
        }

        //Defino que todos los decimales usados tengan la precición (18, 2)
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
        }
        public override int SaveChanges()
        {
            EnsureAudit();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            EnsureAudit();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public async Task<IEnumerable<T>> QueryAsync<T>(string text, object parameters = null, int? timeout = null, CommandType? type = null)
        {
            using var command = new DapperEFCoreCommand(this, text, parameters, timeout, type, CancellationToken.None);
            var connection = this.Database.GetDbConnection();
            return await connection.QueryAsync<T>(command.Definition);
        }
        public async Task<T> QueryFirstOrDefaultAsync<T>(string text, object parameters = null, int? timeout = null, CommandType? type = null)
        {
            using var command = new DapperEFCoreCommand(this, text, parameters, timeout, type, CancellationToken.None);
            var connection = this.Database.GetDbConnection();
            return await connection.QueryFirstOrDefaultAsync<T>(command.Definition);
        }
        private void EnsureAudit()
        {
            ChangeTracker.DetectChanges();
        }

        //Inventory
        public DbSet<BitacoraInventario> BitacorasInventarios => Set<BitacoraInventario>();
        public DbSet<BitacoraInventarioBodega> BitacorasInventariosBodegas => Set<BitacoraInventarioBodega>();
        public DbSet<Bodega> Bodegas => Set<Bodega>();
        public DbSet<DetalleInventarioBodega> DetallesInventariosBodegas => Set<DetalleInventarioBodega>();
        public DbSet<Insumo> Insumos => Set<Insumo>();
        public DbSet<InsumoProducto> InsumosProductos => Set<InsumoProducto>();
        public DbSet<InsumoProveedor> InsumosProveedores => Set<InsumoProveedor>();
        public DbSet<Inventario> Inventarios => Set<Inventario>();
        public DbSet<InventarioDetalle> InventariosDetalles => Set<InventarioDetalle>();
        public DbSet<Producto> Productos => Set<Producto>();
        public DbSet<Proveedor> Proveedores => Set<Proveedor>();

        //Operational
        public DbSet<Abono> Abonos => Set<Abono>();
        public DbSet<BitacoraFactura> BitacorasFacturas => Set<BitacoraFactura>();
        public DbSet<Cierre> Cierres => Set<Cierre>();
        public DbSet<CierreMedioPago> CierresMediosPagos => Set<CierreMedioPago>();
        public DbSet<Costo> Costos => Set<Costo>();
        public DbSet<Credito> Creditos => Set<Credito>();
        public DbSet<Factura> Facturas => Set<Factura>();
        public DbSet<FacturaCompra> FacturasCompras => Set<FacturaCompra>();
        public DbSet<FacturaCompraDetalle> FacturasComprasDetalles => Set<FacturaCompraDetalle>();
        public DbSet<FacturaCompraDetallePago> FacturasComprasDetallesPagos => Set<FacturaCompraDetallePago>();
        public DbSet<FacturaConvenio> FacturasConvenios => Set<FacturaConvenio>();
        public DbSet<FacturaDetalle> FacturasDetalles => Set<FacturaDetalle>();
        public DbSet<FacturaDetallePago> FacturasDetallesPago => Set<FacturaDetallePago>();
        public DbSet<ModificacionProducto> ModificacionesProductos => Set<ModificacionProducto>();
        public DbSet<NotaCredito> NotasCreditos => Set<NotaCredito>();
        public DbSet<NotaCreditoDetalle> NotasCreditosDetalles => Set<NotaCreditoDetalle>();
        public DbSet<Orden> Ordenes => Set<Orden>();
        public DbSet<OrdenDetalle> OrdenesDetalles => Set<OrdenDetalle>();
        public DbSet<Propina> Propinas => Set<Propina>();

        //Parameter
        public DbSet<Archivo> Archivos => Set<Archivo>();
        public DbSet<Banco> Bancos => Set<Banco>();
        public DbSet<Caja> Cajas => Set<Caja>();
        public DbSet<Cargo> Cargos => Set<Cargo>();
        public DbSet<Categoria> Categorias => Set<Categoria>();
        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Configuracion> Configuraciones => Set<Configuracion>();
        public DbSet<Convenio> Convenios => Set<Convenio>();
        public DbSet<Pais> Paises => Set<Pais>();
        public DbSet<Salon> Salones => Set<Salon>();
        public DbSet<Departamento> Departamentos => Set<Departamento>();
        public DbSet<Ciudad> Ciudades => Set<Ciudad>();
        public DbSet<Empleado> Empleados => Set<Empleado>();
        public DbSet<Empresa> Empresas => Set<Empresa>();
        public DbSet<Estado> Estados => Set<Estado>();
        public DbSet<ImpresoraCategoria> ImpresorasCategorias => Set<ImpresoraCategoria>();
        public DbSet<Impresora> Impresoras => Set<Impresora>();
        public DbSet<MacroCategoria> MacroCategorias => Set<MacroCategoria>();
        public DbSet<MedioPago> MediosPagos => Set<MedioPago>();
        public DbSet<Mesa> Mesas => Set<Mesa>();
        public DbSet<Motivo> Motivos => Set<Motivo>();
        public DbSet<Notificacion> Notificaciones => Set<Notificacion>();
        public DbSet<NumeracionFactura> NumeracionesFacturas => Set<NumeracionFactura>();
        public DbSet<TipoCosto> TiposCostos => Set<TipoCosto>();
        public DbSet<TipoEstado> TiposEstados => Set<TipoEstado>();
        public DbSet<UnidadMedida> UnidadesMedidas => Set<UnidadMedida>();
        public DbSet<Zona> Zonas => Set<Zona>();

        //Security
        public DbSet<Rol> Roles => Set<Rol>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Persona> Personas => Set<Persona>();
        public DbSet<UsuarioRol> UsuariosRoles => Set<UsuarioRol>();
        public DbSet<Formulario> Formularios => Set<Formulario>();
        public DbSet<FormularioRol> FormulariosRoles => Set<FormularioRol>();
        public DbSet<Modulo> Modulos => Set<Modulo>();


        public readonly struct DapperEFCoreCommand : IDisposable
        {
            public DapperEFCoreCommand(DbContext context, string text, object parameters, int? timeout, CommandType? type, CancellationToken ct)
            {
                var transaction = context.Database.CurrentTransaction?.GetDbTransaction();
                var commandType = type ?? CommandType.Text;
                var commandTimeout = timeout ?? context.Database.GetCommandTimeout() ?? 30;

                Definition = new CommandDefinition(
                    text,
                    parameters,
                    transaction,
                    commandTimeout,
                    commandType,
                    cancellationToken: ct
                );
            }

            public CommandDefinition Definition { get; }

            public void Dispose()
            {
            }
        }
    }
}
