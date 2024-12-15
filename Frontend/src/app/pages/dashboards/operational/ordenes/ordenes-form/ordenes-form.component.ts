import { Component, NgModule, OnInit, signal, ViewChild, ElementRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { HelperService, MessageType } from 'src/app/admin/helper.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { GeneralParameterService } from '../../../../../generic/general.service';
import { DatatableParameter } from '../../../../../admin/datatable.parameters';
import { DetalleFactura } from '../detalleFactura.model';
import { AutocompleteLibModule } from 'angular-ng-autocomplete';
import { DataAutoCompleteDto } from 'src/app/generic/dataAutoCompleteDto';
import { DetallesInventariosBodegasIndexComponent } from '../../../inventory/detalles-inventarios-bodegas/detalles-inventarios-bodegas-index/detalles-inventarios-bodegas-index.component';
import { FacturasFormComponent } from '../../facturas/facturas-form/facturas-form.component';
import { OrdenesService } from '../ordenes.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-ordenes-form',
  standalone: false,
  templateUrl: './ordenes-form.component.html',
  styleUrl: './ordenes-form.component.css'
})
export class OrdenesFormComponent implements OnInit {
  @ViewChild('auto') auto: any;
  keyword = 'name';
  isLoading: boolean = false;
  @ViewChild('inputScanner') inputScanner!: ElementRef;
  statusForm: boolean = true;
  scanner: boolean = false;
  id!: number;
  botones = ['btn-guardar', 'btn-cancelar'];
  title = 'Generar Factura';
  breadcrumb = [{ name: `Inicio`, icon: `fa-duotone fa-house` }, { name: 'Operativo', icon: 'fa-duotone fa-shop' }, { name: 'Facturar', icon: "fa-duotone fa-cart-shopping" }];
  listProductos = signal<DataAutoCompleteDto[]>([]);
  detallesFacturas = signal<DetalleFactura[]>([]);
  producto = 0;
  subTotal = 0;

  constructor(
    private service: GeneralParameterService,
    private ordenService: OrdenesService,
    public helperService: HelperService,
    private modalService: NgbModal,
  ) {

  }

  //Methods
  ngOnInit(): void {
    this.validarNumeracionFactura();
    this.validarEmpleado();
    this.cargarProductos();
    this.limpiar();
  }

  validarNumeracionFactura() {
    var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = "";

    this.service.datatable("NumeracionFactura", data).subscribe((res) => {
      if (res.data.length > 0) {
        var pos = false;
        var activas = 0;
        res.data.forEach((item: any) => {
          if (item.codigo == "POS") {
            pos = true;
          }

          if(item.activo){
            activas++;
          }
        })
        if (!pos) {
          Swal.fire({
            title: '¡Por favor cree una Numeración de Facturacion con código POS para poder facturar!',
            icon: 'warning',
          }).then(() => {
            this.helperService.redirectApp("/dashboard/operativo/numeracion-facturas");
          });
        }

        if(activas == 0){
          Swal.fire({
            title: '¡No hay una Numeración de Facturacion activa, por favor active una para poder facturar!',
            icon: 'warning',
          }).then(() => {
            this.helperService.redirectApp("/dashboard/operativo/numeracion-facturas");
          });
        }
      } else {
        Swal.fire({
          title: '¡No existe una Numeración de Facturacion, por favor creela para poder facturar!',
          icon: 'warning',
        }).then(() => {
          this.helperService.redirectApp("/dashboard/operativo/numeracion-facturas");
        });
      }
    })
  }

  validarEmpleado() {
    var personaId = localStorage.getItem("persona_Id");
    if (personaId != null) {
      var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = personaId; data.nameForeignKey = "PersonaId";
      this.service.datatableKey("Empleado", data).subscribe((empleado) => {
        if (empleado.data.length == 1) {
          localStorage.setItem("Empleado_Id", empleado.data[0].id);
          this.service.getById("Caja", empleado.data[0].cajaId).subscribe((caja) => {
            localStorage.setItem("CajaId", caja.data.id);
            localStorage.setItem("BodegaId", caja.data.bodegaId);
          })
        } else {
          Swal.fire({
            title: '¡No existe un empleado con este usuario!',
            icon: 'warning',
          }).then(() => {
            this.helperService.redirectApp("/dashboard");
          });
        }
      })
    }
  }

  cargarProductos() {
    this.isLoading = true;
    this.service.getAll('Producto').subscribe((res) => {
      res.data.forEach((item: any) => {
        this.listProductos.update(listProductos => {
          const DataAutoCompleteDto: DataAutoCompleteDto = {
            id: item.id,
            name: `${item.codigo} - ${item.nombre}`,
          };

          return [...listProductos, DataAutoCompleteDto];
        });
      });

      this.isLoading = false;
    });
  }

  validarProducto(id: number) {
    var detalle: any[] = [];
    if (this.detallesFacturas().length > 0) {
      this.detallesFacturas().forEach((item: any) => {
        if (item.productoId == id) {
          detalle.push(item);
        }
      });
    }
    return detalle;
  }

  updateCantidad(cantidad: number, index: number) {
    this.detallesFacturas.update((detallesFacturas) => {
      return detallesFacturas.map((detallesFacturas, position) => {
        if (position === index) {
          var subtotal = detallesFacturas.precio * cantidad;
          return {
            ...detallesFacturas,
            cantidad: cantidad,
            subTotal: subtotal
          }
        }
        return detallesFacturas;
      })
    });
    this.subTotal = this.detallesFacturas().reduce((acumulador, detalle) => acumulador + detalle.subTotal, 0);
  }

  validarCantidadesBodega(detallesInventariosBodegas: any[]) {
    var alerta = false;

    detallesInventariosBodegas.forEach(element => {
      switch (element.alerta) {
        case true:
          alerta = true;
          break;
      }
    });
    return alerta;
  }

  facturar() {
    let modal = this.modalService.open(FacturasFormComponent, { size: 'lg', keyboard: false, backdrop: false, centered: true });
    modal.componentInstance.subTotal = this.subTotal;
    modal.componentInstance.total = this.subTotal;
    modal.componentInstance.saldo = this.subTotal;
    modal.componentInstance.facturasDetalles = this.detallesFacturas;

    modal.result.finally(() => {
      if (this.scanner) {
        setTimeout(() => {
          this.inputScanner.nativeElement.value = "";
          this.inputScanner.nativeElement.focus();
        }, 0);
      }
    })
  }

  // Events Botones

  agregar(scanner: boolean) {
    this.helperService.showLoading();
    if (this.producto != 0) {
      var BodegaDefault = localStorage.getItem("BodegaId");
      var productoValidado = this.validarProducto(this.producto);
      if (productoValidado.length == 0) {
        this.service.getById('Producto', this.producto).subscribe((res) => {
          this.service.getById("Bodega", BodegaDefault).subscribe((b) => {
            var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = this.producto; data.nameForeignKey = "ProductoId";
            this.ordenService.getOrdenDetalle(data).subscribe((d) => {
              if (d.data.length >= 1) {
                var count = 0;
                d.data.forEach((detalleBodega: any) => {
                  if(count == 0){
                    detalleBodega.cantidadFacturar = 1;
                    const detalleFactura = {
                      id: 0,
                      activo: res.data.activo,
                      codigo: res.data.codigo,
                      cantidad: 1,
                      subTotal: res.data.precio,
                      precio: res.data.precio,
                      descuento: res.data.descuento,
                      iva: res.data.iva,
                      facturaId: 0,
                      productoId: res.data.id,
                      producto: res.data.nombre,
                      cantidadBodega: detalleBodega.cantidad,
                      detallesInventariosBodegas: d.data,
                      alerta: false
                    }
  
                    var alerta = this.validarCantidadesBodega(detalleFactura.detallesInventariosBodegas);
                    if (alerta) {
                      detalleFactura.alerta = true;
                    } else {
                      detalleFactura.alerta = false;
                    }
                    this.detallesFacturas.update((detallesFacturas) => [...detallesFacturas, detalleFactura]);
                    this.subTotal = this.detallesFacturas().reduce((acumulador, detalle) => acumulador + detalle.subTotal, 0);
                    count++;
                  }
                });
              } else {
                this.helperService.showMessage(MessageType.WARNING, "¡El producto se encuentra agotado, por favor valida las cantidades de bodega!");
              }
            });
          });
        });
      } else {
        //Sumar la cantidad
        var productoId = productoValidado[0].productoId;

        for (let i = 0; i < this.detallesFacturas().length; i++) {
          if (this.detallesFacturas()[i].productoId == productoId) {

            var nuevaCantidad = this.detallesFacturas()[i].cantidad + 1;

            this.detallesFacturas.update((detallesFacturas) => {
              return detallesFacturas.map((detallesFacturas, position) => {
                if (position === i) {
                  var subtotal = detallesFacturas.precio * nuevaCantidad;
                  return {
                    ...detallesFacturas,
                    cantidad: nuevaCantidad,
                    subTotal: subtotal
                  }
                }
                return detallesFacturas;
              })
            });


            this.detallesFacturas()[i].detallesInventariosBodegas.forEach(detalle => {
              if (BodegaDefault == detalle.bodegaId) {
                detalle.cantidadFacturar = nuevaCantidad;
                if (detalle.cantidad < nuevaCantidad) {
                  detalle.alerta = true;
                } else {
                  detalle.alerta = false;
                }
              }
            });

            var alerta = this.validarCantidadesBodega(this.detallesFacturas()[i].detallesInventariosBodegas);
            if (alerta) {
              this.detallesFacturas()[i].alerta = true;
            } else {
              this.detallesFacturas()[i].alerta = false;
            }
          }
        }
        this.subTotal = this.detallesFacturas().reduce((acumulador, detalle) => acumulador + detalle.subTotal, 0);
      }
      if (scanner) {
        setTimeout(() => {
          this.inputScanner.nativeElement.value = "";
          this.inputScanner.nativeElement.focus();
        }, 0);
      } else {
        this.auto.clear();
        this.auto.close();
      }

      setTimeout(() => {
        this.helperService.hideLoading();
      }, 200);
    } else {
      this.helperService.showMessage(MessageType.WARNING, "Selecciona un producto");
    }
  }

  limpiar() {
    this.detallesFacturas = signal<DetalleFactura[]>([]);
    this.subTotal = this.detallesFacturas().reduce((acumulador, detalle) => acumulador + detalle.subTotal, 0);
    if (this.scanner) {
      setTimeout(() => {
        this.inputScanner.nativeElement.value = "";
        this.inputScanner.nativeElement.focus();
      }, 0);
    }
  }

  onClickfacturar() {
    if (this.detallesFacturas().length > 0) {
      if (this.subTotal > 0) {
        var alerta = false;
        for (const element of this.detallesFacturas()) {
          alerta = this.validarCantidadesBodega(element.detallesInventariosBodegas);
          if (alerta) {
            break;
          }
        }
        if (alerta) {
          Swal.fire({
            title: '¡Valide las cantidades en bodega!',
            icon: 'warning',
          }).then(() => {
            this.facturar();
          });
        } else {
          this.facturar();
        }
      } else {
        this.helperService.showMessage(MessageType.WARNING, "¡No se puede facturas con el sub total en 0!");
      }
    } else {
      this.helperService.showMessage(MessageType.WARNING, "¡No hay productos para facturar!");
    }
  }

  scannerOnClick() {
    this.scanner = !this.scanner;
    setTimeout(() => {
      this.inputScanner.nativeElement.focus();
    }, 0);
  }

  keyboardOnClick() {
    this.scanner = !this.scanner;
  }

  onChangeScanner(event: any) {
    var input = event.target as HTMLInputElement;
    if (input.value != '') {
      var codigo = input.value;
      this.service.getByCode("Producto", codigo).subscribe((res) => {
        this.producto = res.data.id;
        this.agregar(true);
      })
    }
  }

  // Events Table

  changeCantidad(event: any, index: number) {
    var BodegaDefault = localStorage.getItem("BodegaId");
    var inputCantidad = event.target as HTMLInputElement;
    if (inputCantidad.value != '') {
      var nuevaCantidad = Number(inputCantidad.value);
      if (nuevaCantidad == 0) {
        nuevaCantidad = 1;
      }

      this.detallesFacturas.update((detallesFacturas) => {
        return detallesFacturas.map((detallesFacturas, position) => {
          if (position === index) {
            var subtotal = detallesFacturas.precio * nuevaCantidad;
            return {
              ...detallesFacturas,
              cantidad: nuevaCantidad,
              subTotal: subtotal
            }
          }
          return detallesFacturas;
        })
      });
    }

    this.detallesFacturas()[index].detallesInventariosBodegas.forEach(item => {
      if (BodegaDefault == item.bodegaId) {
        item.cantidadFacturar = nuevaCantidad;
        if (item.cantidad < nuevaCantidad) {
          item.alerta = true;
        } else {
          item.alerta = false;
        }
      }
    })

    var alerta = this.validarCantidadesBodega(this.detallesFacturas()[index].detallesInventariosBodegas);
    if (alerta) {
      this.detallesFacturas()[index].alerta = true;
    } else {
      this.detallesFacturas()[index].alerta = false;
    }
    this.subTotal = this.detallesFacturas().reduce((acumulador, detalle) => acumulador + detalle.subTotal, 0);
    if (this.scanner) {
      setTimeout(() => {
        this.inputScanner.nativeElement.value = "";
        this.inputScanner.nativeElement.focus();
      }, 0);
    }
  }

  bodegas(index: number) {
    let modal = this.modalService.open(DetallesInventariosBodegasIndexComponent, { size: 'md', keyboard: false, backdrop: false, centered: true });
    modal.componentInstance.detallesInventariosBodegas = this.detallesFacturas()[index].detallesInventariosBodegas;
    modal.componentInstance.cantidadFacturar = this.detallesFacturas()[index].cantidad;

    modal.result.then(res => {
      if (res.length > 0) {
        var nuevaCantidad = res.reduce((acumulador: any, detalle: any) => acumulador + detalle.cantidadFacturar, 0);
        this.updateCantidad(Number(nuevaCantidad), index);
        this.detallesFacturas()[index].detallesInventariosBodegas = res;

        var alerta = this.validarCantidadesBodega(this.detallesFacturas()[index].detallesInventariosBodegas);
        if (alerta) {
          this.detallesFacturas()[index].alerta = true;
        } else {
          this.detallesFacturas()[index].alerta = false;
        }

        if (this.scanner) {
          setTimeout(() => {
            this.inputScanner.nativeElement.value = "";
            this.inputScanner.nativeElement.focus();
          }, 0);
        }
      }
    })
  }

  delete(index: number) {
    this.detallesFacturas.update((detallesFacturas) => detallesFacturas.filter((detalle, position) => position !== index));
    this.subTotal = this.detallesFacturas().reduce((acumulador, detalle) => acumulador + detalle.subTotal, 0);
    if (this.scanner) {
      setTimeout(() => {
        this.inputScanner.nativeElement.value = "";
        this.inputScanner.nativeElement.focus();
      }, 0);
    }
  }

  // Events Autocomplete
  selectEvent(item: any) {
    this.producto = item.id;
  }

  onFocused() {
    this.auto.close();
  }

  inputCleared() {
    this.auto.close();
    this.listProductos = signal<DataAutoCompleteDto[]>([]);
    this.cargarProductos();
  }
}

@NgModule({
  declarations: [
    OrdenesFormComponent
  ],
  imports: [
    CommonModule,
    GeneralModule,
    AutocompleteLibModule
  ],
})
export class OrdenesFormModule { }