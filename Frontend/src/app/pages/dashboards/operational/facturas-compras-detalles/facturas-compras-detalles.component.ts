import { Component, Input, OnInit, signal, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { LANGUAGE_DATATABLE } from 'src/app/admin/datatable.language';
import { DatatableParameter } from '../../../../admin/datatable.parameters';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../generic/general.service';
import { DataAutoCompleteDto } from '../../../../generic/dataAutoCompleteDto';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import Swal from 'sweetalert2';
import { AutocompleteLibModule } from 'angular-ng-autocomplete';
import { DetallesInventariosBodegasIndexComponent } from '../../inventory/detalles-inventarios-bodegas/detalles-inventarios-bodegas-index/detalles-inventarios-bodegas-index.component';
import { FacturaCompraDetalle } from './facturas-compras-detalles.module';

@Component({
  selector: 'app-facturas-compras-detalles',
  standalone: false,
  templateUrl: './facturas-compras-detalles.component.html',
  styleUrl: './facturas-compras-detalles.component.css'
})
export class FacturasComprasDetallesComponent implements OnInit {
  @ViewChild('auto') auto: any;
  keyword = 'name';
  isLoading: boolean = false;
  botones = ['btn-guardar'];
  @Input() FacturaCompraId: any = null;
  frmFacturasComprasDetalles: FormGroup;
  statusForm: boolean = true;
  listInsumos = signal<DataAutoCompleteDto[]>([]);
  listFacturasComprasDetalles = signal<FacturaCompraDetalle[]>([]);
  detallesInventariosBodegas: any[] = [];
  cantidadTotalDetallesInventarioBodega: number = 0;
  manejaClave = false;

  constructor(
    public helperService: HelperService,
    private service: GeneralParameterService,
    private modalService: NgbModal,
  ) {
    this.frmFacturasComprasDetalles = new FormGroup({
      Id: new FormControl(0, Validators.required),
      Codigo: new FormControl(""),
      Cantidad: new FormControl(1, Validators.required),
      SubTotal: new FormControl(0, Validators.required),
      PrecioCosto: new FormControl(null, Validators.required),
      Descuento: new FormControl(0),
      Iva: new FormControl(0),
      FacturaCompraId: new FormControl(this.FacturaCompraId, Validators.required),
      InsumoId: new FormControl(null, Validators.required),
      EmpleadoId: new FormControl(null, Validators.required),
      Activo: new FormControl(true, Validators.required),
    });
  }

  ngOnInit(): void {
    this.validarEmpleado();
    this.cargarLista();
    this.cargarInsumos();
    this.ManejaClave();
  }

  ManejaClave() {
    this.getConfiguration().then((res) => {
      if (res.status) {
        if (res.data[0].manejaClaveSupervisor) {
          this.manejaClave = true;
        }
      } else {
        this.helperService.showMessage(MessageType.WARNING, "¡No hay una clave de supervisor configurada!");
      }
    }).catch((error) => {
      console.error('Error al obtener los datos:', error);
    });
  }

  validarEmpleado() {
    var personaId = localStorage.getItem("persona_Id");
    if (personaId != null) {
      var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = personaId; data.nameForeignKey = "PersonaId";
      this.service.datatableKey("Empleado", data).subscribe((empleado) => {
        if (empleado.data.length == 1) {
          this.frmFacturasComprasDetalles.controls['EmpleadoId'].setValue(empleado.data[0].id);
          localStorage.setItem('EmpleadoId', empleado.data[0].id);
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

  calcularSubTotal() {
    let data = this.frmFacturasComprasDetalles.value;
    if (data.PrecioCosto != null) {
      var subtotal = parseInt(data.PrecioCosto) * parseInt(data.Cantidad);
      this.frmFacturasComprasDetalles.controls['SubTotal'].setValue(subtotal);
    }
  }

  cargarInsumos() {
    this.isLoading = true;
    this.service.getAll('Insumo').subscribe((res) => {
      res.data.forEach((item: any) => {
        this.listInsumos.update(listInsumos => {
          const DataAutoCompleteDto: DataAutoCompleteDto = {
            id: item.id,
            name: `${item.codigo} - ${item.nombre}`,
          };

          return [...listInsumos, DataAutoCompleteDto];
        });
      });
      this.isLoading = false;
    });
  }

  cargarLista() {
    this.getData().then((datos) => {
      datos.data.forEach((item: any) => {
        this.listFacturasComprasDetalles.update(listFacturasComprasDetalles => {
          const FacturaCompraDetalle: FacturaCompraDetalle = {
            id: item.id,
            activo: item.activo,
            codigo: item.codigo,
            cantidad: item.cantidad,
            subTotal: item.subTotal,
            precioCosto: item.precioCosto,
            descuento: item.descuento,
            iva: item.iva,
            facturaCompraId: item.facturaCompraId,
            facturaCompra: item.facturaCompra,
            insumoId: item.insumoId,
            insumo: item.insumo,
          };

          return [...listFacturasComprasDetalles, FacturaCompraDetalle];
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
    })
      .catch((error) => {
        console.error('Error al obtener los datos:', error);
      });
  }

  getData(): Promise<any> {
    var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = this.FacturaCompraId; data.nameForeignKey = "FacturaCompraId";
    return new Promise((resolve, reject) => {
      this.service.datatableKey("FacturaCompraDetalle", data).subscribe(
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
    this.listFacturasComprasDetalles = signal<FacturaCompraDetalle[]>([]);
    this.cargarLista();
  }

  save() {
    this.frmFacturasComprasDetalles.controls['FacturaCompraId'].setValue(Number(this.FacturaCompraId));
    if (this.frmFacturasComprasDetalles.invalid) {
      this.statusForm = false;
      this.helperService.showMessage(MessageType.WARNING, Messages.EMPTYFIELD);
      return;
    }
    var valido = this.validarCantidadesBodega();
    if (valido) {
      this.helperService.showLoading();
      let data = this.frmFacturasComprasDetalles.value;
      this.service.save("FacturaCompraDetalle", this.frmFacturasComprasDetalles.controls['Id'].value, data).subscribe(
        (response) => {
          if (response.status) {
            this.refrescarTabla();
            this.frmFacturasComprasDetalles.reset();
            this.validarEmpleado();
            this.frmFacturasComprasDetalles.controls['Id'].setValue(0);
            this.frmFacturasComprasDetalles.controls['FacturaCompraId'].setValue(Number(this.FacturaCompraId));
            this.frmFacturasComprasDetalles.controls['Activo'].setValue(true);
            this.frmFacturasComprasDetalles.controls['Descuento'].setValue(0);
            this.frmFacturasComprasDetalles.controls['Iva'].setValue(0);
            this.frmFacturasComprasDetalles.controls['Cantidad'].setValue(1);
            this.frmFacturasComprasDetalles.controls['SubTotal'].setValue(0);
            this.frmFacturasComprasDetalles.controls['Codigo'].setValue("");
            this.guardarCantidadesBodega();
            this.auto.clear();
          }
        },
        (error) => {
          setTimeout(() => {
            this.helperService.hideLoading();
          }, 200);
          this.helperService.showMessage(
            MessageType.WARNING,
            error.error.message
          );
        }
      );
    } else {
      Swal.fire({
        title: '¡Valide las cantidades en bodega!',
        icon: 'warning',
      }).then(() => {
        this.bodegas();
      });
    }
  }

  validarCantidadesBodega() {
    var valido = true
    var cantidad = this.frmFacturasComprasDetalles.controls["Cantidad"].value;
    if (this.cantidadTotalDetallesInventarioBodega != cantidad) {
      valido = false;
    }
    return valido;
  }

  update(item: any) {
    this.frmFacturasComprasDetalles.controls['Id'].setValue(item.id);
    this.frmFacturasComprasDetalles.controls['Activo'].setValue(item.activo);
    this.frmFacturasComprasDetalles.controls['Codigo'].setValue(item.codigo);
    this.frmFacturasComprasDetalles.controls['Cantidad'].setValue(item.cantidad);
    this.frmFacturasComprasDetalles.controls['SubTotal'].setValue(item.subTotal);
    this.frmFacturasComprasDetalles.controls['PrecioCosto'].setValue(item.precioCosto);
    this.frmFacturasComprasDetalles.controls['Descuento'].setValue(item.descuento);
    this.frmFacturasComprasDetalles.controls['Iva'].setValue(item.iva);
    this.frmFacturasComprasDetalles.controls['FacturaCompraId'].setValue(item.facturaCompraId);
    this.frmFacturasComprasDetalles.controls['InsumoId'].setValue(item.insumoId);
  }

  ValidarClaveSupervisor(clave: number, id: number) {
    this.getConfiguration().then((res) => {
      if (res.status) {
        if (clave == Number(res.data[0].claveSupervisor)) {
          this.eliminar(id);
        } else {
          this.helperService.showMessage(MessageType.WARNING, "¡Clave de supervisor incorrecta!");
        }
      } else {
        this.helperService.showMessage(MessageType.WARNING, "¡No hay una clave de supervisor configurada!");
      }
    });
  }

  getConfiguration(): Promise<any> {
    return new Promise((resolve, reject) => {
      this.service.getAll("Configuracion").subscribe(
        (datos) => {
          resolve(datos);
        },
        (error) => {
          reject(error);
        }
      );
    });
  }

  deleteGeneric(id: any) {
    if (this.manejaClave) {
      Swal.fire({
        title: "Clave de supervisor",
        input: "number",
        inputAttributes: {
          autocapitalize: "off"
        },
        showCancelButton: true,
        confirmButtonText: "Validar",
        cancelButtonText: "Cancelar",
        showLoaderOnConfirm: true,
        preConfirm: async (clave) => {
          this.ValidarClaveSupervisor(clave, id);
        },
        allowOutsideClick: () => !Swal.isLoading()
      });
    } else {
      this.eliminar(id);
    }
  }

  eliminar(id: any) {
    this.helperService.confirmDelete(() => {
      this.service.deleteEmpleado("FacturaCompraDetalle", id, this.frmFacturasComprasDetalles.controls['EmpleadoId'].value).subscribe(
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

  bodegas() {
    this.helperService.showLoading();
    var cantidad = this.frmFacturasComprasDetalles.controls["Cantidad"].value;
    var insumoId = this.frmFacturasComprasDetalles.controls["InsumoId"].value;
    if (insumoId != null) {
      this.getinventarioDetalleBodega(cantidad, insumoId).then((res) => {
        if (res) {
          setTimeout(() => {
            this.helperService.hideLoading();
          }, 200);
          setTimeout(() => {
            let modal = this.modalService.open(DetallesInventariosBodegasIndexComponent, { size: 'md', keyboard: false, backdrop: false, centered: true });
            modal.componentInstance.detallesInventariosBodegas = this.detallesInventariosBodegas;
            modal.componentInstance.cantidadFacturar = cantidad;
            modal.componentInstance.facturaCompra = true;
            modal.result.then(res => {
              if (res.length > 0) {
                var nuevaCantidad = res.reduce((acumulador: any, detalle: any) => acumulador + detalle.cantidadFacturar, 0);
                this.frmFacturasComprasDetalles.controls["Cantidad"].setValue(nuevaCantidad);
                this.cantidadTotalDetallesInventarioBodega = nuevaCantidad;
                this.detallesInventariosBodegas = res;
                this.calcularSubTotal();
              }
            });
          }, 1000);
        } else {
          this.helperService.showMessage(
            MessageType.WARNING,
            "Ocurrio un error al cargar las bodegas"
          );
        }
      });
    } else {
      this.helperService.showMessage(
        MessageType.WARNING,
        "¡Seleccione un insumo antes de asignar a bodega!"
      );
    }
  }

  guardarCantidadesBodega() {
    var detallesInventarioBodegaDto: any[] = [];
    this.detallesInventariosBodegas.forEach(item => {
      if (item.cantidadFacturar > 0) {
        var detalle = {
          Cantidad: 0,
          CantidadFacturar: item.cantidadFacturar,
          BodegaId: item.bodegaId,
          InventarioDetalleId: item.inventarioDetalleId,
          FacturaCompraId: Number(this.FacturaCompraId),
          EmpleadoId: Number(localStorage.getItem('EmpleadoId')),
        }

        detallesInventarioBodegaDto.push(detalle);
      }
    });

    this.service.saveDetalles("DetalleInventarioBodega", detallesInventarioBodegaDto).subscribe(
      (response) => {
        if (response.status) {
          this.detallesInventariosBodegas = [];
          setTimeout(() => {
            this.helperService.hideLoading();
          }, 200);
          this.helperService.showMessage(
            MessageType.SUCCESS,
            Messages.SAVESUCCESS
          );
        }
      },
      (error) => {
        setTimeout(() => {
          this.helperService.hideLoading();
        }, 200);
        this.helperService.showMessage(MessageType.ERROR, error.error.message);
      }
    );
  }

  getinventarioDetalleBodega(cantidad: number, insumoId: number): Promise<any> {
    var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = "";
    return new Promise((resolve, reject) => {
      var dataInventarioDetalle = new DatatableParameter(); dataInventarioDetalle.pageNumber = ""; dataInventarioDetalle.pageSize = ""; dataInventarioDetalle.filter = ""; dataInventarioDetalle.columnOrder = ""; dataInventarioDetalle.directionOrder = ""; dataInventarioDetalle.foreignKey = insumoId; dataInventarioDetalle.nameForeignKey = "InsumoId";

      this.service.datatableKey("InventarioDetalle", dataInventarioDetalle).subscribe((invDetalle: any) => {
        if (invDetalle.status) {
          if (this.detallesInventariosBodegas.length == 0) {
            this.service.datatable("Bodega", data).subscribe((res) => {
              if (res.status) {
                res.data.forEach((item: any) => {
                  if (item.codigo != "DEFAULT") {
                    cantidad = 0;
                  }
                  let detalle = {
                    id: 0,
                    cantidad: 1,
                    bodegaId: item.id,
                    bodega: item.nombre,
                    inventarioDetalleId: invDetalle.data[0].id,
                    insumo: "",
                    cantidadFacturar: cantidad,
                  };

                  this.detallesInventariosBodegas.push(detalle);
                });
              } else {
                resolve(false);
              }
            });
          }
        } else {
          resolve(false);
        }
      });
      resolve(true);
    });
  }

  // Events Autocomplete

  selectEvent(item: any) {
    this.frmFacturasComprasDetalles.controls["InsumoId"].setValue(item.id);
  }

  onFocused() {
    this.auto.close();
  }

  onCleared() {
    this.detallesInventariosBodegas = [];
    this.auto.clear();
    this.auto.close();
    this.frmFacturasComprasDetalles.controls['InsumoId'].setValue(null);
  }

  inputCleared() {
    this.auto.close();
    this.listInsumos = signal<DataAutoCompleteDto[]>([]);
    this.cargarInsumos();
  }
}
