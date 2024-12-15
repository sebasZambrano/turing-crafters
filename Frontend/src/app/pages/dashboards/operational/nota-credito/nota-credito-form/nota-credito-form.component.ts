import { Component, NgModule, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../../generic/general.service';
import { DatatableParameter } from '../../../../../admin/datatable.parameters';
import { DataSelectDto } from '../../../../../generic/dataSelectDto';
import { DetalleFactura } from '../../ordenes/detalleFactura.model';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-nota-credito-form',
  standalone: false,
  templateUrl: './nota-credito-form.component.html',
  styleUrl: './nota-credito-form.component.css'
})
export class NotasCreditosFormComponent implements OnInit {
  frmNotaCredito: FormGroup;
  statusForm: boolean = true;
  facturaId!: number;
  botones = ['btn-guardar', 'btn-cancelar'];
  title = 'Crear Nota de Crédito';
  breadcrumb = [{ name: `Inicio`, icon: `fa-duotone fa-house` }, { name: "Operativo", icon: "fa-duotone fa-shop" }, { name: "Nota Crédito", icon: "fa-duotone fa-file-circle-exclamation" }, { name: 'Crear', icon: "fa-duotone fa-octagon-plus" }];
  listMotivos = signal<DataSelectDto[]>([]);
  listMediosPagos = signal<DataSelectDto[]>([]);
  listFacturaDetalles = signal<DetalleFactura[]>([]);
  subTotal = 0;
  motivo = false;
  infoMotivo = "";
  completo = true;

  constructor(
    public routerActive: ActivatedRoute,
    private service: GeneralParameterService,
    public helperService: HelperService
  ) {
    this.frmNotaCredito = new FormGroup({
      Codigo: new FormControl(""),
      Concepto: new FormControl(null, [Validators.required]),
      MetodoCredito: new FormControl(true),
      Total: new FormControl(null),
      MotivoId: new FormControl(null, [Validators.required]),
      EstadoId: new FormControl(0),
      FacturaId: new FormControl(this.facturaId, [Validators.required]),
      EmpleadoId: new FormControl(null, [Validators.required]),
      PagoCaja: new FormControl(true, [Validators.required]),
      MedioPagoId: new FormControl(null, [Validators.required]),
      Activo: new FormControl(true, Validators.required)
    });
    this.routerActive.params.subscribe((l) => (this.facturaId = l['id']));
  }

  ngOnInit(): void {
    this.validarEmpleado();
    this.cargarListas();
    if (this.facturaId != undefined && this.facturaId != null) {
      this.helperService.showLoading();
      this.service.getById("Factura", this.facturaId).subscribe((l: any) => {
        var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = this.facturaId; data.nameForeignKey = "FacturaId"
        this.service.datatableKey("FacturaDetalle", data).subscribe((res) => {
          res.data.forEach((item: any) => {
            if (item.activo == false) {
              this.completo = false;
              this.frmNotaCredito.controls["MetodoCredito"].setValue(false);
            }
            const detalleFactura = {
              id: item.id,
              activo: item.activo,
              codigo: item.codigo,
              cantidad: item.cantidad,
              subTotal: (item.precioProducto * item.cantidad),
              precio: item.precioProducto,
              descuento: item.descuento,
              iva: item.iva,
              facturaId: item.facturaId,
              productoId: item.productoId,
              producto: item.producto,
              cantidadBodega: item.cantidad,
              detallesInventariosBodegas: [],
              alerta: item.activo
            }
            this.listFacturaDetalles.update((detallesFacturas) => [...detallesFacturas, detalleFactura]);
            this.subTotal = this.listFacturaDetalles().reduce((acumulador, detalle) => {
              if (detalle.alerta) {
                return acumulador + detalle.subTotal;
              } else {
                return acumulador;
              }
            }, 0);
            this.helperService.hideLoading();
          });
        });
      });
    } else {
      this.helperService.redirectApp('/dashboard/operativo/facturas');
    }
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
          this.frmNotaCredito.controls['MedioPagoId'].setValue(item.id);
        }
      });
    });
  }

  validarEmpleado() {
    var personaId = localStorage.getItem("persona_Id");
    if (personaId != null) {
      var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = personaId; data.nameForeignKey = "PersonaId";
      this.service.datatableKey("Empleado", data).subscribe((empleado) => {
        if (empleado.data.length == 1) {
          this.frmNotaCredito.controls["EmpleadoId"].setValue(empleado.data[0].id);
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

  onChangeMotivo(event: any) {
    if (typeof event == "undefined") {
      this.motivo = false;
      this.infoMotivo = "";
    } else {
      this.service.getById("Motivo", event.id).subscribe((res: any) => {
        this.motivo = true;
        this.infoMotivo = res.data.descripcion;
      });
    }
  }

  onChangeReembolso(event: any) {
    this.listFacturaDetalles.update((listFacturaDetalles) => {
      return listFacturaDetalles.map((detallesFacturas) => {
        return {
          ...detallesFacturas,
          alerta: event,
        }
      })
    });

    this.subTotal = this.listFacturaDetalles().reduce((acumulador, detalle) => {
      if (detalle.alerta) {
        return acumulador + detalle.subTotal;
      } else {
        return acumulador;
      }
    }, 0);
  }

  onChangeDevolver(event: any, index: number) {
    this.listFacturaDetalles.update((detallesFacturas) => {
      return detallesFacturas.map((detallesFacturas, position) => {
        if (position === index) {
          return {
            ...detallesFacturas,
            alerta: event.target.checked,
          }
        }
        return detallesFacturas;
      })
    });

    this.subTotal = this.listFacturaDetalles().reduce((acumulador, detalle) => {
      if (detalle.alerta) {
        return acumulador + detalle.subTotal;
      } else {
        return acumulador;
      }
    }, 0);

    var lengthDescontar = 0;
    this.listFacturaDetalles().forEach(element => {
      if (element.alerta) {
        lengthDescontar++;
      }
    });
    if (lengthDescontar == this.listFacturaDetalles().length) {
      this.frmNotaCredito.controls["MetodoCredito"].setValue(true);
    } else {
      this.frmNotaCredito.controls["MetodoCredito"].setValue(false);
    }
  }

  changeCantidad(event: any, index: number) {
    var inputCantidad = event.target as HTMLInputElement;
    if (inputCantidad.value != '') {
      var nuevaCantidad = Number(inputCantidad.value);
      if (nuevaCantidad == 0) {
        nuevaCantidad = 1;
      } else if (nuevaCantidad > this.listFacturaDetalles()[index].cantidadBodega) {
        nuevaCantidad = this.listFacturaDetalles()[index].cantidad;
      }

      this.listFacturaDetalles.update((detallesFacturas) => {
        return detallesFacturas.map((detallesFacturas, position) => {
          if (position === index) {
            var subtotal = detallesFacturas.precio * nuevaCantidad;
            return {
              ...detallesFacturas,
              cantidadBodega: nuevaCantidad,
              subTotal: subtotal
            }
          }
          return detallesFacturas;
        })
      });

      this.subTotal = this.listFacturaDetalles().reduce((acumulador, detalle) => {
        if (detalle.alerta) {
          return acumulador + detalle.subTotal;
        } else {
          return acumulador;
        }
      }, 0);
    }
  }

  cargarListas() {
    this.cargarMotivos();
    this.cargarMediosPagos();
  }

  cargarMotivos() {
    this.service.getAll('Motivo').subscribe((res) => {
      res.data.forEach((item: any) => {
        this.listMotivos.update(listMotivos => {
          const DataSelectDto: DataSelectDto = {
            id: item.id,
            textoMostrar: `${item.codigo} - ${item.nombre}`,
            activo: item.activo
          };

          return [...listMotivos, DataSelectDto];
        });
      });
    });
  }

  save() {
    this.helperService.confirmUpdate(() => {
      this.frmNotaCredito.controls["FacturaId"].setValue(this.facturaId);
      if (this.frmNotaCredito.invalid) {
        this.statusForm = false;
        this.helperService.showMessage(MessageType.WARNING, Messages.EMPTYFIELD);
        return;
      }

      if (this.subTotal > 0) {
        this.helperService.showLoading();
        this.frmNotaCredito.controls["Total"].setValue(this.subTotal);
        var metodoCredito = "Reembolso parcial";

        if (this.frmNotaCredito.controls["MetodoCredito"].value) {
          metodoCredito = "Reembolso completo";
        }

        var detalles: any[] = [];
        this.listFacturaDetalles().forEach(element => {
          if (element.alerta) {
            var detalle = {
              Id: element.id,
              Activo: true,
              CreateAt: new Date(),
              Codigo: element.codigo,
              Cantidad: element.cantidadBodega,
              SubTotal: element.subTotal,
              PrecioProducto: element.precio,
              Descuento: element.descuento,
              Iva: element.iva,
              FacturaId: this.facturaId,
              ProductoId: element.productoId,
              EmpleadoId: 0,
              DetallesInventariosBodegas: [],
            };

            detalles.push(detalle);
          }
        });

        let data = {
          id: 0,
          FacturaDetalles: detalles,
          ...this.frmNotaCredito.value,
        };

        data.MetodoCredito = metodoCredito;

        this.service.save("NotaCredito", data.id, data).subscribe(
          (response) => {
            if (response.status) {
              this.helperService.hideLoading();
              this.helperService.showMessage(MessageType.SUCCESS, Messages.SAVESUCCESS);
              this.helperService.redirectApp(`/dashboard/operativo/facturas`);
            } else {
              this.helperService.hideLoading();
            }
          },
          (error) => {
            this.helperService.hideLoading();
            this.helperService.showMessage(MessageType.ERROR, error.error.message);
          }
        );
      } else {
        this.helperService.showMessage(MessageType.WARNING, "¡No hay productos seleccionados para devolver!");
      }
    });
  }

  cancel() {
    this.helperService.redirectApp('/dashboard/operativo/facturas');
  }
}
@NgModule({
  declarations: [
    NotasCreditosFormComponent,
  ],
  imports: [
    CommonModule,
    GeneralModule,
  ],
})
export class NotasCreditosFormModule { }