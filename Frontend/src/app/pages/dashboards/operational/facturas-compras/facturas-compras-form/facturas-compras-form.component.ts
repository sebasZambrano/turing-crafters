import { Component, NgModule, OnInit, signal } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../../generic/general.service';
import { DatatableParameter } from '../../../../../admin/datatable.parameters';
import { DataSelectDto } from '../../../../../generic/dataSelectDto';
import { NgbNavModule } from '@ng-bootstrap/ng-bootstrap';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FacturasComprasDetallesComponent } from '../../facturas-compras-detalles/facturas-compras-detalles.component';
import { FacturasComprasDetallesPagosComponent } from '../../facturas-compras-detalles-pagos/facturas-compras-detalles-pagos.component';
import { ProveedoresFormComponent } from '../../../inventory/proveedores/proveedores-form/proveedores-form.component'
import { AutocompleteLibModule } from 'angular-ng-autocomplete';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-facturas-compras-form',
  standalone: false,
  templateUrl: './facturas-compras-form.component.html',
  styleUrl: './facturas-compras-form.component.css'
})
export class FacturasComprasFormComponent implements OnInit {
  frmFacturaCompra: FormGroup;
  statusForm: boolean = true;
  id!: number;
  botones = ['btn-guardar', 'btn-cancelar'];
  title = 'Crear Factura Compra';
  listProveedores = signal<DataSelectDto[]>([]);
  listEstados = signal<DataSelectDto[]>([]);
  listMediosPagos = signal<DataSelectDto[]>([]);
  Pagada: boolean = false;
  breadcrumb = [{ name: `Inicio`, icon: `fa-duotone fa-house` }, { name: 'Operativo', icon: 'fa-duotone fa-shop' }, { name: 'Facturas de Compra', icon: "fa-duotone fa-file-invoice-dollar" }, { name: 'Crear', icon: "fa-duotone fa-octagon-plus" }];

  constructor(
    public routerActive: ActivatedRoute,
    private service: GeneralParameterService,
    private helperService: HelperService,
    private datePipe: DatePipe,
    private modalService: NgbModal
  ) {
    var parseFecha = this.datePipe.transform(new Date(), 'yyyy-MM-dd');
    this.frmFacturaCompra = new FormGroup({
      NumeroFactura: new FormControl(""),
      Fecha: new FormControl(parseFecha, [Validators.required]),
      Total: new FormControl(null, [Validators.required]),
      Descuento: new FormControl(0, [Validators.required]),
      Iva: new FormControl(0, [Validators.required]),
      ProveedorId: new FormControl(null, [Validators.required]),
      EstadoId: new FormControl(null, [Validators.required]),
      EmpleadoId: new FormControl(null, [Validators.required]),
      PagoCaja: new FormControl(false, [Validators.required]),
      MedioPagoId: new FormControl(null, [Validators.required]),
    });
    this.routerActive.params.subscribe((l) => (this.id = l['id']));
  }

  ngOnInit(): void {
    this.validarEmpleado();
    this.cargarListas();

    if (this.id != undefined && this.id != null) {
      this.title = 'Editar Facturas Compras';
      this.breadcrumb = [{ name: `Inicio`, icon: `fa-duotone fa-house` }, { name: 'Operativo', icon: 'fa-duotone fa-shop' }, { name: 'Facturas de Compra', icon: "fa-duotone fa-file-invoice-dollar" }, { name: 'Editar', icon: "fa-duotone fa-pen-to-square" }];
      this.service.getById("FacturaCompra", this.id).subscribe((l) => {
        var parseFecha = this.datePipe.transform(l.data.fecha, 'yyyy-MM-dd');
        this.frmFacturaCompra.controls['NumeroFactura'].setValue(l.data.numeroFactura);
        this.frmFacturaCompra.controls['Fecha'].setValue(parseFecha);
        this.frmFacturaCompra.controls['Total'].setValue(l.data.total);
        this.frmFacturaCompra.controls['Descuento'].setValue(l.data.descuento);
        this.frmFacturaCompra.controls['Iva'].setValue(l.data.iva);
        this.frmFacturaCompra.controls['EstadoId'].setValue(l.data.estadoId);
        this.frmFacturaCompra.controls['EmpleadoId'].setValue(l.data.empleadoId);
        this.frmFacturaCompra.controls['ProveedorId'].setValue(l.data.proveedorId);
      });
    }
  }

  validarEmpleado() {
    var personaId = localStorage.getItem("persona_Id");
    if (personaId != null) {
      var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = personaId; data.nameForeignKey = "PersonaId";
      this.service.datatableKey("Empleado", data).subscribe((empleado) => {
        if (empleado.data.length == 1) {
          this.frmFacturaCompra.controls['EmpleadoId'].setValue(empleado.data[0].id);
        } else {
          Swal.fire({
            title: '¡No existe un empleado con este usuario!',
            icon: 'warning',
          }).then(() => {
            this.helperService.redirectApp("/login");
          });
        }
      })
    }
  }

  cargarListas() {
    this.cargarProveedores(false);
    this.cargarEstados();
    this.cargarMediosPagos();
  }

  cargarProveedores(nuevo: boolean) {
    this.service.getAll('Proveedor').subscribe((res) => {
      res.data.forEach((item: any) => {
        this.listProveedores.update(listProveedores => {
          const DataSelectDto: DataSelectDto = {
            id: item.id,
            activo: item.activo,
            textoMostrar: `${item.numeroCuenta} - ${item.empresa}`,
          };

          return [...listProveedores, DataSelectDto];
        });

        if (nuevo) {
          this.frmFacturaCompra.controls['ProveedorId'].setValue(item.id);
        }
      });
    });
  }

  cargarEstados() {
    this.service.getAll('TipoEstado').subscribe((res) => {
      res.data.forEach((item: any) => {
        if (item.nombre == "FACTURAS DE COMPRA") {
          var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = item.id; data.nameForeignKey = "TipoEstadoId";
          this.service.datatableKey("Estado", data).subscribe((estados) => {
            if (estados.data.length > 0) {
              estados.data.forEach((element: any) => {
                this.listEstados.update(listEstados => {
                  const DataSelectDto: DataSelectDto = {
                    id: element.id,
                    activo: element.activo,
                    textoMostrar: `${element.codigo} - ${element.nombre}`,
                  };

                  return [...listEstados, DataSelectDto];
                });
              });
            }
          });
        }
      });
    });
  }

  cargarMediosPagos() {
    this.service.getAll('MedioPago').subscribe((res) => {
      res.data.forEach((item: any) => {
        this.listMediosPagos.update(listMediosPagos => {
          const DataSelectDto: DataSelectDto = {
            id: item.id,
            activo: item.activo,
            textoMostrar: `${item.codigo} - ${item.nombre}`,
          };

          return [...listMediosPagos, DataSelectDto];
        });
        if (item.codigo == "EFECTIVO") {
          this.frmFacturaCompra.controls['MedioPagoId'].setValue(item.id);
        }
      });
    });
  }

  onSelectChangeEstado(estadoId: string) {
    if (estadoId != null) {
      this.service.getById("Estado", estadoId).subscribe(r => {
        if (r.data.codigo == 'P') {
          this.Pagada = true;
        } else {
          this.Pagada = false;
        }
      })
    } else {
      this.Pagada = false;
    }
  }

  nuevoProveedor() {
    let modal = this.modalService.open(ProveedoresFormComponent, { size: 'lg', keyboard: false, backdrop: false, centered: true });
    modal.result.finally(() => {
      this.listProveedores = signal<DataSelectDto[]>([]);

      setTimeout(() => {
        this.cargarProveedores(true);
      }, 200);
    });
  }

  save() {
    if (this.frmFacturaCompra.invalid) {
      this.statusForm = false
      this.helperService.showMessage(MessageType.WARNING, Messages.EMPTYFIELD);
      return;
    }
    this.helperService.showLoading();
    let data = {
      id: this.id ?? 0,
      ...this.frmFacturaCompra.value
    };

    if (this.id != undefined && this.id != null) {
      this.helperService.confirmUpdate(this.saveRegister(data));
    } else {
      this.saveRegister(data)
    }
  }

  saveRegister(data: any) {
    setTimeout(() => {
      this.service.save("FacturaCompra", this.id, data).subscribe(l => {
        if (!l.status) {
          this.helperService.showMessage(MessageType.ERROR, Messages.SAVEERROR)
        } else {
          this.helperService.redirectApp(`/dashboard/operativo/facturas-compras/editar/${l.data.id}`);
          this.helperService.showMessage(MessageType.SUCCESS, Messages.SAVESUCCESS);
          setTimeout(() => {
            this.helperService.hideLoading();
          }, 200);
        }
      })
    }, 800);
  }

  cancel() {
    this.helperService.redirectApp('/dashboard/operativo/facturas-compras');
  }
}
@NgModule({
  declarations: [
    FacturasComprasFormComponent,
    FacturasComprasDetallesComponent,
    FacturasComprasDetallesPagosComponent
  ],
  imports: [
    CommonModule,
    GeneralModule,
    AutocompleteLibModule,
    NgbNavModule
  ]
})
export class FacturasComprasFormModule { }