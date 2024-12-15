import { Component, NgModule, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { GeneralParameterService } from '../../../../../generic/general.service';
import { FacturaDetallePago } from '../facturaDetallePago.module';
import { DataAutoCompleteDto } from 'src/app/generic/dataAutoCompleteDto';
import { DetalleFactura } from '../../ordenes/detalleFactura.model';
import { ClientesFormComponent } from '../../../parameters/clientes/clientes-form/clientes-form.component';
import { OrdenDetalle } from '../../ordenes-resto/ordenDetalle.module';
import { DatatableParameter } from 'src/app/admin/datatable.parameters';

@Component({
  selector: 'app-facturas-form',
  standalone: false,
  templateUrl: './facturas-form.component.html',
  styleUrl: './facturas-form.component.css',
})
export class FacturasFormComponent implements OnInit {
  frmFactura: FormGroup;

  statusForm: boolean = true;
  listConvenios = signal<DataAutoCompleteDto[]>([]);
  listCliente = signal<DataAutoCompleteDto[]>([]);
  listMedioPago = signal<DataAutoCompleteDto[]>([]);
  facturaDetallesPagos = signal<FacturaDetallePago[]>([]);
  facturasDetalles = signal<DetalleFactura[]>([]);

  subTotal = 0;
  total = 0;
  saldo = 0;
  cambio = 0;
  ordenId = 0;

  constructor(
    private service: GeneralParameterService,
    public helperService: HelperService,
    private modalService: NgbModal,
    private modalActive: NgbActiveModal
  ) {
    this.frmFactura = new FormGroup({
      EmpleadoId: new FormControl(null, [Validators.required]),
      CajaId: new FormControl(null, [Validators.required]),
      ConvenioId: new FormControl(null),
      Iva: new FormControl(0),
      Descuento: new FormControl(0),
      DescuentoValor: new FormControl(0),
      ClienteId: new FormControl(null, [Validators.required]),
      MedioPagoId: new FormControl(null),
      Remision: new FormControl(false),
      Valor: new FormControl(0),
      Observacion: new FormControl(''),
      Voucher: new FormControl(''),
    });
  }

  ngOnInit(): void {
    this.cargarListas();
    this.CargarParametros();
  }

  NuevoCliente() {
    let modal = this.modalService.open(ClientesFormComponent, {
      size: 'lg',
      keyboard: false,
      backdrop: false,
      centered: true,
    });

    modal.result.finally(() => {
      this.listCliente = signal<DataAutoCompleteDto[]>([]);

      setTimeout(() => {
        this.cargarClientes();
      }, 200);
    });
  }

  CargarParametros() {
    var empleadoId = localStorage.getItem('Empleado_Id');
    this.frmFactura.controls['EmpleadoId'].setValue(Number(empleadoId));
    var cajaId = localStorage.getItem('CajaId');
    this.frmFactura.controls['CajaId'].setValue(Number(cajaId));
  }

  cargarListas() {
    this.cargarConvenios();
    this.cargarClientes();
    this.cargarMediosPagos();
  }

  cargarConvenios() {
    this.service.getAll('Convenio').subscribe((res) => {
      res.data.forEach((item: any) => {
        this.listConvenios.update((listConvenios) => {
          const DataAutoCompleteDto: DataAutoCompleteDto = {
            id: item.id,
            name: `${item.codigo} - ${item.nombre}`,
          };

          return [...listConvenios, DataAutoCompleteDto];
        });
      });
    });
  }

  cargarClientes() {
    this.service.getAll('Cliente').subscribe((res) => {
      res.data.forEach((item: any) => {
        this.listCliente.update((listCliente) => {
          const DataAutoCompleteDto: DataAutoCompleteDto = {
            id: item.id,
            name: item.nombre,
          };

          return [...listCliente, DataAutoCompleteDto];
        });
        if (item.codigo == 'UNIVERSAL') {
          this.frmFactura.controls['ClienteId'].setValue(item.id);
        }
      });
    });
  }

  cargarMediosPagos() {
    this.service.getAll('MedioPago').subscribe((res) => {
      res.data.forEach((item: any) => {
        this.listMedioPago.update((listMedioPago) => {
          const DataAutoCompleteDto: DataAutoCompleteDto = {
            id: item.id,
            name: item.nombre,
          };

          return [...listMedioPago, DataAutoCompleteDto];
        });

        if (item.codigo == 'EFECTIVO') {
          this.frmFactura.controls['MedioPagoId'].setValue(item.id);
        }
      });
    });
  }

  cancel() {
    this.modalActive.close();
  }

  changeRemision() {
    this.frmFactura.controls['Remision'].setValue(
      !this.frmFactura.controls['Remision'].value
    );
  }

  onChangeConvenio(event: any) {
    if (typeof event == 'undefined') {
      this.frmFactura.controls['Descuento'].setValue(0);
      this.calcularDescuento(0);
    } else {
      this.service.getById('Convenio', event.id).subscribe((res) => {
        if (res.data.activo) {
          this.frmFactura.controls['Descuento'].setValue(res.data.descuento);
          this.calcularDescuento(res.data.descuento);
        } else {
          this.frmFactura.controls['ConvenioId'].setValue(null);
          this.helperService.showMessage(
            MessageType.WARNING,
            'El convenio no está activo'
          );
        }
      });
    }
  }

  onChangeDescuento(event: any) {
    var convenio = this.frmFactura.controls['ConvenioId'].value;
    if (convenio != null) {
      this.frmFactura.controls['ConvenioId'].setValue(null);
    }
    var input = event.target as HTMLInputElement;
    this.calcularDescuento(Number(input.value));
  }

  onChangeInpuesto(event: any) {
    var input = event.target as HTMLInputElement;
    this.calcularInpuesto(Number(input.value));
  }

  onChangeDescuentoValor(event: any) {
    var input = event.target as HTMLInputElement;
    this.calcularDescuentoValor(Number(input.value));
  }

  calcularDescuento(descuento: number) {
    var valorDescuentoProcentaje = (this.subTotal * descuento) / 100;
    var valorDescuento = parseInt(valorDescuentoProcentaje.toString());
    if (valorDescuento > this.subTotal) {
      this.frmFactura.controls['Descuento'].setValue(100);
      this.frmFactura.controls['DescuentoValor'].setValue(this.subTotal);
      this.total -= this.subTotal;
      this.saldo -= this.subTotal;
    } else {
      this.frmFactura.controls['DescuentoValor'].setValue(valorDescuento);
      var iva = this.frmFactura.controls['Iva'].value;
      if (iva == 0) {
        var total = this.subTotal - valorDescuento;
        this.total = total;
        this.saldo = total;
      } else {
        var valorImpuesto = (this.subTotal * iva) / 100;
        var totalDescuento = this.subTotal + valorImpuesto - valorDescuento;
        this.total = totalDescuento;
        this.saldo = totalDescuento;
      }
    }
  }

  calcularInpuesto(inpuesto: number) {
    var valorImpuesto = (this.subTotal * inpuesto) / 100;
    if (valorImpuesto > this.subTotal) {
      this.frmFactura.controls['Iva'].setValue(100);
      this.total += this.subTotal;
      this.saldo += this.subTotal;
    } else {
      var descuento = this.frmFactura.controls['Descuento'].value;
      if (descuento == 0) {
        var total = this.subTotal + valorImpuesto;
        this.total = total;
        this.saldo = total;
      } else {
        var valorDescuento = (this.subTotal * descuento) / 100;
        var total = this.subTotal + valorImpuesto - valorDescuento;
        this.total = total;
        this.saldo = total;
      }
    }
  }

  calcularDescuentoValor(valorDescuento: number) {
    if (valorDescuento > this.subTotal) {
      this.frmFactura.controls['Descuento'].setValue(100);
      this.calcularDescuento(100);
    } else {
      var descuento = (valorDescuento / this.subTotal) * 100;
      this.frmFactura.controls['Descuento'].setValue(
        parseFloat(descuento.toFixed(1))
      );
      this.calcularDescuento(descuento);
    }
  }

  agregarDetallePago() {
    if (this.saldo > 0) {
      this.helperService.showLoading();
      var empleado = Number(localStorage.getItem('Empleado_Id'));
      var valor = this.frmFactura.controls['Valor'].value;
      var medioPagoId = this.frmFactura.controls['MedioPagoId'].value;
      if (valor > 0) {
        if (medioPagoId != null) {
          var detalle = this.validarMedioPago(medioPagoId);
          if (detalle.length == 0) {
            this.service.getById('MedioPago', medioPagoId).subscribe((res) => {
              if (valor > this.saldo) {
                if (res.data.codigo == 'EFECTIVO') {
                  //Calcular el cambio
                  this.cambio = valor - this.saldo;
                }
                valor = this.saldo;
              }
              const detalle: FacturaDetallePago = {
                id: 0,
                activo: true,
                valor: valor,
                observacion: '',
                empleadoId: empleado,
                medioPagoId: medioPagoId,
                medioPago: res.data.nombre,
                facturaId: 0,
              };
              this.facturaDetallesPagos.update((facturaDetallesPagos) => [
                ...facturaDetallesPagos,
                detalle,
              ]);
              var totalPagos = this.facturaDetallesPagos().reduce(
                (acumulador, detalle) => acumulador + detalle.valor,
                0
              );
              this.saldo = this.total - totalPagos;
              this.frmFactura.controls['MedioPagoId'].setValue(null);
              this.frmFactura.controls['Valor'].setValue(0);

              setTimeout(() => {
                this.helperService.hideLoading();
              }, 200);
            });
          } else {
            setTimeout(() => {
              this.helperService.hideLoading();
            }, 200);
            this.helperService.showMessage(
              MessageType.WARNING,
              '¡Ya existe un detalle con ese medio de pago!'
            );
          }
        } else {
          setTimeout(() => {
            this.helperService.hideLoading();
          }, 200);
          this.helperService.showMessage(
            MessageType.WARNING,
            '¡Falta seleccionar un medio de pago!'
          );
        }
      } else {
        setTimeout(() => {
          this.helperService.hideLoading();
        }, 200);
        this.helperService.showMessage(
          MessageType.WARNING,
          '¡Falta agregar un valor!'
        );
      }
    } else {
      setTimeout(() => {
        this.helperService.hideLoading();
      }, 200);
      this.helperService.showMessage(
        MessageType.WARNING,
        '¡No hay saldo pendiente!'
      );
    }
  }

  validarMedioPago(id: number) {
    var detalle: any[] = [];
    if (this.facturaDetallesPagos().length > 0) {
      this.facturaDetallesPagos().forEach((item: any) => {
        if (item.medioPagoId == id) {
          detalle.push(item);
        }
      });
    }
    return detalle;
  }

  facturar() {
    this.helperService.showLoading();
    if (this.saldo == 0) {
      if (this.frmFactura.invalid) {
        this.statusForm = false;
        this.helperService.hideLoading();
        this.helperService.showMessage(
          MessageType.WARNING,
          Messages.EMPTYFIELD
        );
        return;
      }
      if (this.ordenId != 0) {
        this.gardarFactura(this.ordenId);
      } else {
        this.guardarOrden();
      }

    } else {
      this.helperService.hideLoading();
      this.helperService.showMessage(
        MessageType.WARNING,
        '¡Hay un saldo pendiente!'
      );
    }
  }

  guardarOrden() {
    let data = {
      Id: 0,
      Codigo: "",
      Descripcion: "",
      CantidadPersonas: 1,
      Total: this.total,
      MesaId: 0,
      EmpleadoId: this.frmFactura.controls['EmpleadoId'].value,
      EstadoId: 0
    };

    this.service.save('Orden', data.Id, data).subscribe(
      (response) => {
        if (response.status) {
          this.guardarDetallesOrden(response.data.id);
        } else {
          this.helperService.hideLoading();
        }
      },
      (error) => {
        this.helperService.hideLoading();
        this.helperService.showMessage(
          MessageType.ERROR,
          error.error.message
        );
      }
    );
  }

  guardarDetallesOrden(ordenId: number) {
    let detalles: any[] = [];

    this.facturasDetalles().forEach((element: any) => {
      var detalle = {
        Id: 0,
        Activo: true,
        CreateAt: new Date(),
        Codigo: element.codigo,
        Cantidad: element.cantidad,
        Precio: element.precio,
        Observaciones: "",
        OrdenId: ordenId,
        ProductoId: element.productoId,
        EstadoId: 0,
      };

      detalles.push(detalle);
    });

    this.service.saveDetalles('OrdenDetalle', detalles).subscribe(
      (response) => {
        if (response.status) {
          this.gardarFactura(response.data[0].ordenId);
        } else {
          this.helperService.hideLoading();
        }
      },
      (error) => {
        this.helperService.hideLoading();
        this.helperService.showMessage(MessageType.ERROR, error.error.message);
      }
    );
  }

  gardarFactura(ordenId: number) {
    let data = {
      id: 0,
      Activo: true,
      NumeroFactura: '',
      SubTotal: this.subTotal,
      Total: this.total,
      Descuento: this.frmFactura.controls['Descuento'].value,
      Iva: this.frmFactura.controls['Iva'].value,
      Observacion: this.frmFactura.controls['Observacion'].value,
      Remision: this.frmFactura.controls['Remision'].value,
      ClienteId: this.frmFactura.controls['ClienteId'].value,
      EstadoId: 0,
      EmpleadoId: this.frmFactura.controls['EmpleadoId'].value,
      CajaId: this.frmFactura.controls['CajaId'].value,
      NumeracionFacturaId: 0,
      OrdenId: ordenId,
    };

    this.service.save('Factura', data.id, data).subscribe(
      (response) => {
        if (response.status) {
          this.guardarDetalles(response.data.id);
        } else {
          this.helperService.hideLoading();
        }
      },
      (error) => {
        this.helperService.hideLoading();
        this.helperService.showMessage(
          MessageType.ERROR,
          error.error.message
        );
      }
    );
  }

  validarDetalles(facturaId: number) {
    let detalles: any[] = [];

    if (this.facturasDetalles().length > 0) {
      this.facturasDetalles().forEach((element: any) => {
        let detallesInventariosBodegas: any[] = [];
        element.detallesInventariosBodegas.forEach((item: any) => {
          var DetalleInventarioBodega = {
            Id: item.id,
            Activo: true,
            Cantidad: item.cantidad,
            BodegaId: item.bodegaId,
            InventarioDetalleId: item.inventarioDetalleId,
            CantidadFacturar: item.cantidadFacturar,
            CreateAt: new Date(),
          };

          detallesInventariosBodegas.push(DetalleInventarioBodega);
        });

        var detalle = {
          Id: 0,
          Activo: true,
          CreateAt: new Date(),
          Codigo: element.codigo,
          Cantidad: element.cantidad,
          SubTotal: element.subTotal,
          PrecioProducto: element.precio,
          Descuento: element.descuento,
          Iva: element.iva,
          FacturaId: facturaId,
          ProductoId: element.productoId,
          EmpleadoId: this.frmFactura.controls['EmpleadoId'].value,
          DetallesInventariosBodegas: detallesInventariosBodegas,
        };

        detalles.push(detalle);
      });
    } else {
      var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = this.ordenId; data.nameForeignKey = "OrdenId";
      this.service.datatableKey("OrdenDetalle", data).subscribe((res: any) => {
        res.data.forEach((element: any) => {
          var detalle = {
            Id: 0,
            Activo: true,
            CreateAt: new Date(),
            Codigo: element.codigo,
            Cantidad: element.cantidad,
            SubTotal: (element.precio * element.cantidad),
            PrecioProducto: element.precio,
            Descuento: 0,
            Iva: 0,
            FacturaId: facturaId,
            ProductoId: element.productoId,
            EmpleadoId: this.frmFactura.controls['EmpleadoId'].value,
            DetallesInventariosBodegas: [],
          };

          detalles.push(detalle);
        });
      });
    }

    return detalles;
  }

  guardarDetalles(facturaId: number) {
    var detalles = this.validarDetalles(facturaId);
    console.log(detalles);
    this.service.saveDetalles('FacturaDetalle', detalles).subscribe(
      (response) => {
        if (response.status) {
          this.guardarDetallesPagos(facturaId);
        } else {
          this.helperService.hideLoading();
        }
      },
      (error) => {
        this.helperService.hideLoading();
        this.helperService.showMessage(MessageType.ERROR, error.error.message);
      }
    );
  }

  guardarDetallesPagos(facturaId: number) {
    let detalles: any[] = [];
    this.facturaDetallesPagos().forEach((element: any) => {
      var detalle = {
        Id: 0,
        Activo: true,
        CreateAt: new Date(),
        Valor: element.valor,
        Observacion: element.observacion,
        EmpleadoId: element.empleadoId,
        MedioPagoId: element.medioPagoId,
        FacturaId: facturaId,
      };

      detalles.push(detalle);
    });

    this.service.saveDetalles('FacturaDetallePago', detalles).subscribe(
      (response) => {
        if (response.status) {
          this.generarFactura(facturaId);
        } else {
          this.helperService.hideLoading();
        }
      },
      (error) => {
        this.helperService.hideLoading();
        this.helperService.showMessage(MessageType.ERROR, error.error.message);
      }
    );
  }

  generarFactura(facturaId: number) {
    this.service.generarFactura('Factura', facturaId).subscribe((res) => {
      this.openPdfInNewTab(res.data.content);
    });
  }

  openPdfInNewTab(pdfContent: string) {
    const byteCharacters = atob(pdfContent);
    const byteNumbers = new Array(byteCharacters.length);
    for (let i = 0; i < byteCharacters.length; i++) {
      byteNumbers[i] = byteCharacters.charCodeAt(i);
    }
    const byteArray = new Uint8Array(byteNumbers);
    const blob = new Blob([byteArray], { type: 'application/pdf' });
    const objectUrl = URL.createObjectURL(blob);

    setTimeout(() => {
      this.helperService.hideLoading();
    }, 200);

    const newWindow = window.open(objectUrl, '_blank');

    if (newWindow) {
      newWindow.document.title = 'Factura';
      newWindow.print();
    }

    setTimeout(() => {
      location.reload();
    }, 500);
  }
}

@NgModule({
  declarations: [FacturasFormComponent],
  imports: [CommonModule, GeneralModule],
})
export class FacturasFormModule { }
