import { Component, NgModule, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../../generic/general.service';
import { DatatableParameter } from '../../../../../admin/datatable.parameters';
import { DataSelectDto } from '../../../../../generic/dataSelectDto';
import { NotaCreditoDetalle } from '../nota-credito-detalle.module';

@Component({
  selector: 'app-nota-credito-aprobar-form',
  standalone: false,
  templateUrl: './nota-credito-aprobar-form.component.html',
  styleUrl: './nota-credito-aprobar-form.component.css'
})
export class NotasCreditosAprobarFormComponent implements OnInit {
  frmNotaCredito: FormGroup;
  statusForm: boolean = true;
  id!: number;
  botones = ['btn-aprobar', 'btn-rechazar', 'btn-cancelar'];
  title = 'Aprobar Nota de Crédito';
  breadcrumb = [{ name: `Inicio`, icon: `fa-duotone fa-house` }, { name: "Operativo", icon: "fa-duotone fa-shop" }, { name: "Nota Crédito", icon: "fa-duotone fa-file-circle-exclamation" }, { name: 'Aprobar', icon: "fa-duotone fa-check" }];
  listMotivos = signal<DataSelectDto[]>([]);
  listMediosPagos = signal<DataSelectDto[]>([]);
  listNotasCreditosDetalles = signal<NotaCreditoDetalle[]>([]);
  subTotal = 0;
  motivo = false;
  infoMotivo = "";
  completo = true;
  estado = "";

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
      FacturaId: new FormControl(null, [Validators.required]),
      EmpleadoId: new FormControl(null, [Validators.required]),
      PagoCaja: new FormControl(true, [Validators.required]),
      MedioPagoId: new FormControl(null, [Validators.required]),
      Activo: new FormControl(true, Validators.required)
    });
    this.routerActive.params.subscribe((l) => (this.id = l['id']));
  }

  ngOnInit(): void {
    this.cargarListas();
    if (this.id != undefined && this.id != null) {
      this.helperService.showLoading();

      this.service.getById("NotaCredito", this.id).subscribe((l) => {
        this.frmNotaCredito.controls['Codigo'].setValue(l.data.codigo);
        this.frmNotaCredito.controls['Concepto'].setValue(l.data.concepto);
        this.frmNotaCredito.controls['Total'].setValue(l.data.total);
        this.frmNotaCredito.controls['MotivoId'].setValue(l.data.motivoId);
        this.frmNotaCredito.controls['EstadoId'].setValue(l.data.estadoId);
        this.frmNotaCredito.controls['FacturaId'].setValue(l.data.facturaId);
        this.frmNotaCredito.controls['EmpleadoId'].setValue(l.data.empleadoId);
        this.frmNotaCredito.controls['PagoCaja'].setValue(l.data.pagoCaja);
        this.frmNotaCredito.controls['MedioPagoId'].setValue(l.data.medioPagoId);
        this.frmNotaCredito.controls['Activo'].setValue(l.data.activo);
        this.subTotal = l.data.total;
        this.service.getById("Estado", l.data.estadoId).subscribe((estado) => {
          this.estado = estado.data.nombre;
          if (estado.data.nombre == "RECHAZADA") {
            this.completo = false;
            this.frmNotaCredito.controls["MetodoCredito"].setValue(false);
            this.botones = ['btn-cancelar'];
            this.title = "Ver Nota de Crédito";
          }
        });
      });

      var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = this.id; data.nameForeignKey = "NotaCreditoId"
      this.service.datatableKey("NotaCreditoDetalle", data).subscribe((res: any) => {
        res.data.forEach((element: any) => {
          if (element.activo == false) {
            this.completo = false;
            this.frmNotaCredito.controls["MetodoCredito"].setValue(false);
            this.botones = ['btn-cancelar'];
            this.title = "Ver Nota de Crédito";
          }
          const detalle = {
            id: element.id,
            activo: element.activo,
            notaCreditoId: element.notaCreditoId,
            facturaDetalleId: element.facturaDetalleId,
            cantidad: element.cantidad,
            notaCredito: element.notaCredito,
            facturaDetalle: element.facturaDetalle,
            select: true,
            codigo: element.codigo,
            producto: element.producto,
            productoId: element.productoId,
            precioProducto: element.precioProducto,
            subTotal: (element.precioProducto * element.cantidad),
          }

          this.listNotasCreditosDetalles.update((detalles) => [...detalles, detalle]);

          this.subTotal = this.listNotasCreditosDetalles().reduce((acumulador, detalle) => {
            if (detalle.select) {
              return acumulador + detalle.subTotal;
            } else {
              return acumulador;
            }
          }, 0);
          this.helperService.hideLoading();
        });
      });
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
      });
    });
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
    this.listNotasCreditosDetalles.update((listNotasCreditosDetalles) => {
      return listNotasCreditosDetalles.map((detalles) => {
        return {
          ...detalles,
          select: event,
        }
      })
    });

    this.subTotal = this.listNotasCreditosDetalles().reduce((acumulador, detalle) => {
      if (detalle.select) {
        return acumulador + detalle.subTotal;
      } else {
        return acumulador;
      }
    }, 0);
  }

  onChangeDevolver(event: any, index: number) {
    this.listNotasCreditosDetalles.update((detalles) => {
      return detalles.map((detalles, position) => {
        if (position === index) {
          return {
            ...detalles,
            select: event.target.checked,
          }
        }
        return detalles;
      })
    });

    this.subTotal = this.listNotasCreditosDetalles().reduce((acumulador, detalle) => {
      if (detalle.select) {
        return acumulador + detalle.subTotal;
      } else {
        return acumulador;
      }
    }, 0);

    var lengthDescontar = 0;
    this.listNotasCreditosDetalles().forEach(element => {
      if (element.select) {
        lengthDescontar++;
      }
    });
    if (lengthDescontar == this.listNotasCreditosDetalles().length) {
      this.frmNotaCredito.controls["MetodoCredito"].setValue(true);
    } else {
      this.frmNotaCredito.controls["MetodoCredito"].setValue(false);
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
    if (this.frmNotaCredito.invalid) {
      this.statusForm = false;
      this.helperService.showMessage(MessageType.WARNING, Messages.EMPTYFIELD);
      return;
    }

    if (this.subTotal > 0) {
      this.helperService.showLoading();
      var metodoCredito = "Reembolso parcial";

      if (this.frmNotaCredito.controls["MetodoCredito"].value) {
        metodoCredito = "Reembolso completo";
      }

      var detalles: any[] = [];
      this.listNotasCreditosDetalles().forEach(element => {
        if (element.select) {
          var detalle = {
            Id: element.facturaDetalleId,
            Activo: true,
            CreateAt: new Date(),
            Codigo: element.codigo,
            Cantidad: element.cantidad,
            SubTotal: element.subTotal,
            PrecioProducto: element.precioProducto,
            Descuento: 0,
            Iva: 0,
            FacturaId: 0,
            ProductoId: element.productoId,
            EmpleadoId: 0,
            DetallesInventariosBodegas: [],
          };

          detalles.push(detalle);
        }
      });

      let data = {
        id: this.id ?? 0,
        FacturaDetalles: detalles,
        ...this.frmNotaCredito.value,
      };

      data.MetodoCredito = metodoCredito;

      this.service.save("NotaCredito", this.id, data).subscribe(
        (response) => {
          if (response.status) {
            this.helperService.hideLoading();
            this.helperService.showMessage(MessageType.SUCCESS, Messages.SAVESUCCESS);
            this.helperService.redirectApp(`/dashboard/operativo/notas-credito`);
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
      this.helperService.showMessage(MessageType.WARNING, "¡No hay productos seleccionados para aprobar!");
    }
  }

  aprobar() {
    this.helperService.confirmUpdate(() => {
      this.service.getByCode("Estado", "NC-2").subscribe((l) => {
        if (this.subTotal > 0) {
          this.frmNotaCredito.controls["Total"].setValue(this.subTotal);
          this.frmNotaCredito.controls["EstadoId"].setValue(l.data.id);
          this.save();
        } else {
          this.helperService.showMessage(MessageType.WARNING, "¡No hay productos seleccionados para aprobar la devolución!");
        }
      });
    });
  }

  rechazar() {
    this.helperService.confirmUpdate(() => {
      this.service.getByCode("Estado", "NC-3").subscribe((l) => {
        this.frmNotaCredito.controls["EstadoId"].setValue(l.data.id);
        this.save();
      });
    });
  }

  cancel() {
    this.helperService.redirectApp('/dashboard/operativo/notas-credito');
  }
}
@NgModule({
  declarations: [
    NotasCreditosAprobarFormComponent,
  ],
  imports: [
    CommonModule,
    GeneralModule,
  ],
})
export class NotasCreditosAprobarFormModule { }