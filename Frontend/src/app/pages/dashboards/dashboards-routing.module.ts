import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

// Component Pages
import { DashboardComponent } from './dashboard/dashboard.component';
import { GeneralParameterIndexComponent } from './general-parameter/general-parameter-index/general-parameter-index.component';
import { GeneralParameterKeyIndexComponent } from './general-paremeter-key/general-parameter-key-index/general-parameter-key-index.component';
import { ModulosIndexComponent } from './security/modulos/modulos-index/modulos-index.component';
import { FormulariosIndexComponent } from './security/formularios/formularios-index/formularios-index.component';
import { RolesIndexComponent } from './security/roles/roles-index/roles-index.component';
import { RolesFormComponent } from './security/roles/roles-form/roles-form.component';
import { PersonasIndexComponent } from './security/personas/personas-index/personas-index.component';
import { UsuariosIndexComponent } from './security/usuarios/usuarios-index/usuarios-index.component';
import { UsuariosFormComponent } from './security/usuarios/usuarios-form/usuarios-form.component';
import { OrdenesFormComponent } from './operational/ordenes/ordenes-form/ordenes-form.component';
import { InventariosIndexComponent } from './inventory/inventarios/inventarios-index/inventarios-index.component';
import { InventariosFormComponent } from './inventory/inventarios/inventarios-form/inventarios-form.component';
import { ProductosIndexComponent } from './inventory/productos/productos-index/productos-index.component';
import { ProductosFormComponent } from './inventory/productos/productos-form/productos-form.component';
import { InsumosFormComponent } from './inventory/insumos/insumos-form/insumos-form.component';
import { InsumosIndexComponent } from './inventory/insumos/insumos-index/insumos-index.component';
import { BodegasIndexComponent } from './inventory/bodegas/bodegas-index/bodegas-index.component';
import { BodegasFormComponent } from './inventory/bodegas/bodegas-form/bodegas-form.component';
import { FacturasComprasIndexComponent } from './operational/facturas-compras/facturas-compras-index/facturas-compras-index.component';
import { FacturasComprasFormComponent } from './operational/facturas-compras/facturas-compras-form/facturas-compras-form.component';
import { ProveedoresIndexComponent } from './inventory/proveedores/proveedores-index/proveedores-index.component';
import { ProveedoresFormComponent } from './inventory/proveedores/proveedores-form/proveedores-form.component';
import { CostosIndexComponent } from './operational/costos/costos-index/costos-index.component';
import { CostosFormComponent } from './operational/costos/costos-form/costos-form.component';
import { CierresIndexComponent } from './operational/cierres/cierres-index/cierres-index.component';
import { CierresFormComponent } from './operational/cierres/cierres-form/cierres-form.component';
import { NumeracionFacturasIndexComponent } from './operational/numeracion-facturas/numeracion-facturas-index/numeracion-facturas-index.component';
import { NumeracionFacturasFormComponent } from './operational/numeracion-facturas/numeracion-facturas-form/numeracion-facturas-form.component';
import { EmpresaIndexComponent } from './operational/empresa/empresa-index/empresa-index.component';
import { EmpresaFormComponent } from './operational/empresa/empresa-form/empresa-form.component';
import { FacturasIndexComponent } from './operational/facturas/facturas-index/facturas-index.component';
import { EmpleadosFormComponent } from './parameters/empleados/empleados-form/empleados-form.component';
import { EmpleadosIndexComponent } from './parameters/empleados/empleados-index/empleados-index.component';
import { ClientesFormComponent } from './parameters/clientes/clientes-form/clientes-form.component';
import { ClientesIndexComponent } from './parameters/clientes/clientes-index/clientes-index.component';
import { ConfiguracionesFormComponent } from './parameters/configuraciones/configuraciones-form/configuraciones-form.component';
import { MotivosIndexComponent } from './parameters/motivos/motivos-index/motivos-index.component';
import { NotasCreditosIndexComponent } from './operational/nota-credito/nota-credito-index/nota-credito-index.component';
import { NotasCreditosFormComponent } from './operational/nota-credito/nota-credito-form/nota-credito-form.component';
import { NotasCreditosAprobarFormComponent } from './operational/nota-credito/nota-credito-aprobar-form/nota-credito-aprobar-form.component';
import { FacturasDetallesIndexComponent } from './operational/facturas-detalles/facturas-detalles-index/facturas-detalles-index.component';
import { SalonesIndexComponent } from './parameters/salones/salones-index/salones-index.component';
import { MesasIndexComponent } from './parameters/mesas/mesas-index/mesas-index.component';
import { ImpresorasIndexComponent } from './parameters/impresoras/impresoras-index/impresoras-index.component';
import { ImpresorasFormComponent } from './parameters/impresoras/impresoras-form/impresoras-form.component';
import { PropinasIndexComponent } from './operational/propinas/propinas-index/propinas-index.component';
import { CocinaFormComponent } from './operational/cocina/cocina.component';
import { OrdenesRestoFormComponent } from './operational/ordenes-resto/ordenes-resto-form/ordenes-resto-form.component';

const routes: Routes = [
  {
    path: "",
    component: DashboardComponent
  },

  //Modulos
  {
    path: 'seguridad/modulos', component: ModulosIndexComponent
  },

  //Formularios
  {
    path: 'seguridad/formularios', component: FormulariosIndexComponent
  },

  //Roles
  {
    path: 'seguridad/roles', component: RolesIndexComponent
  },
  {
    path: 'seguridad/roles/crear', component: RolesFormComponent
  },
  {
    path: 'seguridad/roles/editar/:id', component: RolesFormComponent
  },

  //Personas
  {
    path: 'seguridad/personas', component: PersonasIndexComponent
  },

  //Usuarios
  {
    path: 'seguridad/usuarios', component: UsuariosIndexComponent
  },
  {
    path: 'seguridad/usuarios/crear', component: UsuariosFormComponent
  },
  {
    path: 'seguridad/usuarios/editar/:id', component: UsuariosFormComponent
  },

  //Inventario
  {
    path: 'inventario/inventarios',
    component: InventariosIndexComponent
  },
  {
    path: 'inventario/inventarios/crear',
    component: InventariosFormComponent
  },
  {
    path: 'inventario/inventarios/editar/:id',
    component: InventariosFormComponent,
  },

  //Producto
  {
    path: 'inventario/productos',
    component: ProductosIndexComponent
  },
  {
    path: 'inventario/productos/crear',
    component: ProductosFormComponent
  },
  {
    path: 'inventario/productos/editar/:id',
    component: ProductosFormComponent,
  },

  //Insumos
  {
    path: 'inventario/insumos',
    component: InsumosIndexComponent
  },
  {
    path: 'inventario/insumos/crear',
    component: InsumosFormComponent
  },
  {
    path: 'inventario/insumos/editar/:id',
    component: InsumosFormComponent
  },

  //Bodegas
  {
    path: 'inventario/bodegas',
    component: BodegasIndexComponent
  },
  {
    path: 'inventario/bodegas/crear',
    component: BodegasFormComponent
  },
  {
    path: 'inventario/bodegas/editar/:id',
    component: BodegasFormComponent
  },

  //Proveedores
  {
    path: 'inventario/proveedores',
    component: ProveedoresIndexComponent
  },
  {
    path: 'inventario/proveedores/crear',
    component: ProveedoresFormComponent
  },
  {
    path: 'inventario/proveedores/editar/:id',
    component: ProveedoresFormComponent
  },

  //Operativo especificos
  {
    path: 'operativo/ordenes',
    component: OrdenesFormComponent
  },
  {
    path: 'operativo/ordenes-resto',
    component: OrdenesRestoFormComponent
  },
  {
    path: 'operativo/propinas',
    component: PropinasIndexComponent
  },
  {
    path: 'operativo/cocina',
    component: CocinaFormComponent
  },

  //Facturas Compras
  {
    path: 'operativo/facturas-compras',
    component: FacturasComprasIndexComponent,
  },
  {
    path: 'operativo/facturas-compras/crear',
    component: FacturasComprasFormComponent,
  },
  {
    path: 'operativo/facturas-compras/editar/:id',
    component: FacturasComprasFormComponent,
  },

  //Costos
  {
    path: 'operativo/costos',
    component: CostosIndexComponent
  },
  {
    path: 'operativo/costos/crear',
    component: CostosFormComponent
  },
  {
    path: 'operativo/costos/editar/:id',
    component: CostosFormComponent
  },

  //Facturas
  {
    path: 'operativo/facturas',
    component: FacturasIndexComponent
  },

  //Cierres
  {
    path: 'operativo/cierres',
    component: CierresIndexComponent
  },
  {
    path: 'operativo/cierres/crear',
    component: CierresFormComponent
  },
  {
    path: 'operativo/cierres/editar/:id',
    component: CierresFormComponent
  },

  //Cliente
  {
    path: 'parametros/clientes',
    component: ClientesIndexComponent
  },
  {
    path: 'parametros/clientes/crear',
    component: ClientesFormComponent
  },
  {
    path: 'parametros/clientes/editar/:id',
    component: ClientesFormComponent
  },

  //Configuracion
  {
    path: 'parametros/configuraciones/editar/:id',
    component: ConfiguracionesFormComponent
  },

  //Motivo
  {
    path: 'parametros/motivos',
    component: MotivosIndexComponent
  },

  //Empleados
  {
    path: 'parametros/empleados',
    component: EmpleadosIndexComponent
  },
  {
    path: 'parametros/empleados/crear',
    component: EmpleadosFormComponent
  },
  {
    path: 'parametros/empleados/editar/:id',
    component: EmpleadosFormComponent
  },

  //Empresa
  {
    path: 'operativo/empresa',
    component: EmpresaIndexComponent,
  },
  {
    path: 'operativo/empresa/crear',
    component: EmpresaFormComponent,
  },
  {
    path: 'operativo/empresa/editar/:id',
    component: EmpresaFormComponent,
  },

  //NumeracionFacturas
  {
    path: 'operativo/numeracion-facturas',
    component: NumeracionFacturasIndexComponent,
  },
  {
    path: 'operativo/numeracion-facturas/crear',
    component: NumeracionFacturasFormComponent,
  },
  {
    path: 'operativo/numeracion-facturas/editar/:id',
    component: NumeracionFacturasFormComponent,
  },

  //Nota Credito
  {
    path: 'operativo/notas-credito',
    component: NotasCreditosIndexComponent
  },
  {
    path: 'operativo/notas-credito/editar/:id',
    component: NotasCreditosFormComponent
  },
  {
    path: 'operativo/notas-credito/aprobar/:id',
    component: NotasCreditosAprobarFormComponent
  },

  //FacturaDetalles
  {
    path: 'operativo/facturas-detalles',
    component: FacturasDetallesIndexComponent
  },

  //Salon
  {
    path: 'parametros/salones',
    component: SalonesIndexComponent
  },

  //Mesa
  {
    path: 'parametros/mesas',
    component: MesasIndexComponent
  },

  //Impresora
  {
    path: 'parametros/impresoras',
    component: ImpresorasIndexComponent,
  },
  {
    path: 'parametros/impresoras/crear',
    component: ImpresorasFormComponent,
  },
  {
    path: 'parametros/impresoras/editar/:id',
    component: ImpresorasFormComponent,
  },

  //General
  {
    path: 'parametros/cargos',
    component: GeneralParameterIndexComponent,
    data: {
      ruta: 'Cargos',
      titulo: 'Cargo',
      modulo: 'Parametros',
      iconModule: 'fa-duotone fa-gears',
      iconForm: 'fa-duotone fa-users-gear',
    },
  },
  {
    path: 'parametros/modificaciones-producto',
    component: GeneralParameterIndexComponent,
    data: {
      ruta: 'Modificaciones Producto',
      titulo: 'ModificacionProducto',
      modulo: 'Parametros',
      iconModule: 'fa-duotone fa-gears',
      iconForm: 'fa-duotone fa-message-pen',
    },
  },
  {
    path: 'parametros/bancos',
    component: GeneralParameterIndexComponent,
    data: {
      ruta: 'Bancos',
      titulo: 'Banco',
      modulo: 'Parametros',
      iconModule: 'fa-duotone fa-gears',
      iconForm: 'fa-duotone fa-building-columns',
    },
  },
  {
    path: 'parametros/paises',
    component: GeneralParameterIndexComponent,
    data: {
      ruta: 'Paises',
      titulo: 'Pais',
      modulo: 'Parametros',
      iconModule: 'fa-duotone fa-gears',
      iconForm: 'fa-duotone fa-earth-americas',
    },
  },
  {
    path: 'parametros/macroCategorias',
    component: GeneralParameterIndexComponent,
    data: {
      ruta: 'MacroCategorias',
      titulo: 'MacroCategoria',
      modulo: 'Parametros',
      iconModule: 'fa-duotone fa-gears',
      iconForm: 'fa-duotone fa-tags',
    },
  },
  {
    path: 'parametros/mediosPagos',
    component: GeneralParameterIndexComponent,
    data: {
      ruta: 'MediosPagos',
      titulo: 'MedioPago',
      modulo: 'Parametros',
      iconModule: 'fa-duotone fa-gears',
      iconForm: 'fa-duotone fa-money-bills',
    },
  },
  {
    path: 'parametros/tiposCostos',
    component: GeneralParameterIndexComponent,
    data: {
      ruta: 'TiposCostos',
      titulo: 'TipoCosto',
      modulo: 'Parametros',
      iconModule: 'fa-duotone fa-gears',
      iconForm: 'fa-duotone fa-money-bill-transfer',
    },
  },
  {
    path: 'parametros/tiposEstados',
    component: GeneralParameterIndexComponent,
    data: {
      ruta: 'TiposEstados',
      titulo: 'TipoEstado',
      modulo: 'Parametros',
      iconModule: 'fa-duotone fa-gears',
      iconForm: 'fa-duotone fa-bars',
    },
  },
  {
    path: 'parametros/unidadesMedidas',
    component: GeneralParameterIndexComponent,
    data: {
      ruta: 'UnidadesMedidas',
      titulo: 'UnidadMedida',
      modulo: 'Parametros',
      iconModule: 'fa-duotone fa-gears',
      iconForm: 'fa-duotone fa-ruler-vertical',
    },
  },
  {
    path: 'parametros/zonas',
    component: GeneralParameterIndexComponent,
    data: {
      ruta: 'Zonas',
      titulo: 'Zona',
      modulo: 'Parametros',
      iconModule: 'fa-duotone fa-gears',
      iconForm: 'fa-duotone fa-store',
    },
  },

  //General key
  {
    path: 'parametros/ciudades',
    component: GeneralParameterKeyIndexComponent,
    data: {
      ruta: 'Ciudades',
      titulo: 'Ciudad',
      modulo: 'Parametros',
      iconModule: 'fa-duotone fa-gears',
      iconForm: 'fa-duotone fa-city',
      key: 'Departamento',
    },
  },
  {
    path: 'parametros/departamentos',
    component: GeneralParameterKeyIndexComponent,
    data: {
      ruta: 'Departamentos',
      titulo: 'Departamento',
      modulo: 'Parametros',
      iconModule: 'fa-duotone fa-gears',
      iconForm: 'fa-duotone fa-map-location-dot',
      key: 'Pais',
    },
  },
  {
    path: 'parametros/cajas',
    component: GeneralParameterKeyIndexComponent,
    data: {
      ruta: 'Cajas',
      titulo: 'Caja',
      modulo: 'Parametros',
      iconModule: 'fa-duotone fa-gears',
      iconForm: 'fa-duotone fa-cash-register',
      key: 'Bodega',
    },
  },
  {
    path: 'parametros/categorias',
    component: GeneralParameterKeyIndexComponent,
    data: {
      ruta: 'Categorias',
      titulo: 'Categoria',
      modulo: 'Parametros',
      iconModule: 'fa-duotone fa-gears',
      iconForm: 'fa-duotone fa-tag',
      key: 'MacroCategoria',
    },
  },
  {
    path: 'parametros/estados',
    component: GeneralParameterKeyIndexComponent,
    data: {
      ruta: 'Estados',
      titulo: 'Estado',
      modulo: 'Parametros',
      iconModule: 'fa-duotone fa-gears',
      iconForm: 'fa-duotone fa-sliders',
      key: 'TipoEstado',
    },
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class DashboardsRoutingModule { }