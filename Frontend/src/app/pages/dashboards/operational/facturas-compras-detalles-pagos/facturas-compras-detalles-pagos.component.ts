import { Component, Input, OnInit, Signal, signal } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { LANGUAGE_DATATABLE } from 'src/app/admin/datatable.language';
import { DatatableParameter } from 'src/app/admin/datatable.parameters';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../generic/general.service';
import { DataSelectDto } from '../../../../generic/dataSelectDto';
import { FacturaCompraDetallePago } from './facturas-compras-detalles-pagos.module';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-facturas-compras-detalles-pagos',
  standalone: false,
  templateUrl: './facturas-compras-detalles-pagos.component.html',
  styleUrl: './facturas-compras-detalles-pagos.component.css'
})
export class FacturasComprasDetallesPagosComponent implements OnInit {
  botones = ['btn-guardar'];
  @Input() FacturaCompraId: any = null;
  frmFacturasComprasDetallesPagos: FormGroup;
  statusForm: boolean = true;
  listMediosPagos = signal<DataSelectDto[]>([]);
  listFacturasComprasDetallesPagos = signal<FacturaCompraDetallePago[]>([]);
  Saldo = 0;
  constructor(
    public helperService: HelperService,
    private service: GeneralParameterService
  ) {
    this.frmFacturasComprasDetallesPagos = new FormGroup({
      Id: new FormControl(0, Validators.required),
      Valor: new FormControl(0, Validators.required),
      PagoCaja: new FormControl(false, Validators.required),
      Observacion: new FormControl(""),
      EmpleadoId: new FormControl(null, Validators.required),
      MedioPagoId: new FormControl(null, Validators.required),
      FacturaCompraId: new FormControl(this.FacturaCompraId, Validators.required),
      Activo: new FormControl(true, Validators.required),
    });
  }

  ngOnInit(): void {
    this.validarEmpleado();
    this.cargarLista();
    this.cargarMediosPagos();
  }

  CalcularSaldo(facturaCompraId: number) {
    var totalPagos = this.listFacturasComprasDetallesPagos().reduce((acumulador, detalle) => acumulador + detalle.valor, 0);
    this.service.getById("FacturaCompra", facturaCompraId).subscribe((res) => {
      this.Saldo = res.data.total - totalPagos;
    });
  }

  validarEmpleado() {
    var personaId = localStorage.getItem("persona_Id");
    if (personaId != null) {
      var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = personaId; data.nameForeignKey = "PersonaId";
      this.service.datatableKey("Empleado", data).subscribe((empleado) => {
        if (empleado.data.length == 1) {
          this.frmFacturasComprasDetallesPagos.controls['EmpleadoId'].setValue(empleado.data[0].id);
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

  cargarMediosPagos() {
    this.service.getAll('MedioPago').subscribe((res) => {
      res.data.forEach((item: any) => {
        this.listMediosPagos.update(listMediosPagos => {
          const DataSelectDto: DataSelectDto = {
            id: item.id,
            textoMostrar: item.nombre,
            activo: item.activo
          };

          return [...listMediosPagos, DataSelectDto];
        });
      });
    });
  }

  cargarLista() {
    this.getData()
      .then((datos) => {
        datos.data.forEach((item: any) => {
          this.listFacturasComprasDetallesPagos.update(listFacturasComprasDetallesPagos => {
            const FacturaCompraDetallePago: FacturaCompraDetallePago = {
              id: item.id,
              activo: item.activo,
              valor: item.valor,
              pagoCaja: item.pagoCaja,
              observacion: item.observacion,
              empleadoId: item.empleadoId,
              empleado: item.empleado,
              medioPagoId: item.medioPagoId,
              medioPago: item.medioPago,
              facturaCompraId: item.facturaCompraId,
              facturaCompra: item.facturaCompra,
              createAt: item.createAt
            };

            return [...listFacturasComprasDetallesPagos, FacturaCompraDetallePago];
          });
        });

        setTimeout(() => {
          $("#datatable").DataTable({
            dom: 'Blfrtip',
            destroy: true,
            language: LANGUAGE_DATATABLE,
            processing: true
          });
        }, 200);

        this.CalcularSaldo(Number(this.FacturaCompraId));
      })
      .catch((error) => {
        console.error('Error al obtener los datos:', error);
      });
  }

  getData(): Promise<any> {
    var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = this.FacturaCompraId; data.nameForeignKey = "FacturaCompraId";
    return new Promise((resolve, reject) => {
      this.service.datatableKey("FacturaCompraDetallePago", data).subscribe(
        (datos) => {
          resolve(datos);
        },
        (error) => {
          reject(error);
        }
      )
    });
  }

  refrescarTabla() {
    $("#datatable").DataTable().destroy();
    this.listFacturasComprasDetallesPagos = signal<FacturaCompraDetallePago[]>([]);

    setTimeout(() => {
      this.cargarLista();
    }, 200);
  }

  save() {
    this.frmFacturasComprasDetallesPagos.controls['FacturaCompraId'].setValue(Number(this.FacturaCompraId));
    if (this.frmFacturasComprasDetallesPagos.invalid) {
      this.statusForm = false;
      this.helperService.showMessage(MessageType.WARNING, Messages.EMPTYFIELD);
      return;
    }
    let data = this.frmFacturasComprasDetallesPagos.value;
    this.service.save("FacturaCompraDetallePago", this.frmFacturasComprasDetallesPagos.controls['Id'].value, data).subscribe(
      (response) => {
        if (response.status) {
          this.refrescarTabla();
          this.frmFacturasComprasDetallesPagos.reset();
          this.validarEmpleado();
          this.frmFacturasComprasDetallesPagos.controls['Id'].setValue(0);
          this.frmFacturasComprasDetallesPagos.controls['Valor'].setValue(0);
          this.frmFacturasComprasDetallesPagos.controls['Activo'].setValue(true);
          this.frmFacturasComprasDetallesPagos.controls['FacturaCompraId'].setValue(Number(this.FacturaCompraId));
          this.helperService.showMessage(
            MessageType.SUCCESS,
            Messages.SAVESUCCESS
          );
        }
      },
      (error) => {
        this.helperService.showMessage(
          MessageType.WARNING,
          error.error.message
        );
      }
    );
  }

  updateFCDP(item: any) {
    this.frmFacturasComprasDetallesPagos.controls['Id'].setValue(item.id);
    this.frmFacturasComprasDetallesPagos.controls['Activo'].setValue(item.activo);
    this.frmFacturasComprasDetallesPagos.controls['Valor'].setValue(item.valor);
    this.frmFacturasComprasDetallesPagos.controls['PagoCaja'].setValue(item.pagoCaja);
    this.frmFacturasComprasDetallesPagos.controls['Observacion'].setValue(item.observacion);
    this.frmFacturasComprasDetallesPagos.controls['EmpleadoId'].setValue(item.empleadoId);
    this.frmFacturasComprasDetallesPagos.controls['MedioPagoId'].setValue(item.medioPagoId);
    this.frmFacturasComprasDetallesPagos.controls['FacturaCompraId'].setValue(item.facturaCompraId);
  }

  deleteGeneric(id: any) {
    this.helperService.confirmDelete(() => {
      this.service.delete("FacturaCompraDetallePago", id).subscribe(
        (response) => {
          if (response.status) {
            this.helperService.showMessage(MessageType.SUCCESS, Messages.DELETESUCCESS);
            this.refrescarTabla();
          }
        },
        (error) => {
          this.helperService.showMessage(MessageType.WARNING, error.error.message);
        }
      )
    });
  }
}
