import { Component, NgModule, OnInit, signal, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { ActivatedRoute } from '@angular/router';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DataSelectDto } from '../../../../generic/dataSelectDto';
import { DataAutoCompleteDto } from '../../../../generic/dataAutoCompleteDto';
import { DatatableParameter } from 'src/app/admin/datatable.parameters';
import { GeneralParameterService } from '../../../../generic/general.service';
import { AutocompleteLibModule } from 'angular-ng-autocomplete';
import { TrasladoBodegasService } from './traslados-bodegas.service';
import { TrasladoBodega } from './traslado-bodegas.module';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-traslado-bodegas-form',
  standalone: false,
  templateUrl: './traslado-bodegas-form.component.html',
  styleUrl: './traslado-bodegas-form.component.css'
})
export class TrasladoBodegasFormComponent implements OnInit {
  id: number = 0;
  frmTraslado: FormGroup;
  statusForm: boolean = true;
  @ViewChild('auto') auto: any;
  keyword = 'name';
  isLoading: boolean = false;
  botones = ['btn-guardar', 'btn-cancelar'];
  bodega: boolean = false;
  listBodegas = signal<DataSelectDto[]>([]);
  listBodegasDestino = signal<DataSelectDto[]>([]);
  listInventarioDetalle = signal<DataAutoCompleteDto[]>([]);
  trasladoBodega = signal<TrasladoBodega[]>([]);

  constructor(
    public routerActive: ActivatedRoute,
    private service: GeneralParameterService,
    private serviceTraslado: TrasladoBodegasService,
    private helperService: HelperService,
    private modalActive: NgbActiveModal
  ) {
    this.frmTraslado = new FormGroup({
      BodegaId: new FormControl(null, [Validators.required]),
      Cantidad: new FormControl(null, [Validators.required]),
      BodegaDestinoId: new FormControl(null, [Validators.required]),
      InventarioDetalleId: new FormControl(null, [Validators.required]),
      EmpleadoId: new FormControl(null, [Validators.required]),
    });
  }

  ngOnInit(): void {
    this.cargarBodegas();
    this.validarEmpleado();
  }

  validarEmpleado() {
    var personaId = localStorage.getItem("persona_Id");
    if (personaId != null) {
      var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = personaId; data.nameForeignKey = "PersonaId";
      this.service.datatableKey("Empleado", data).subscribe((empleado) => {
        if (empleado.data.length == 1) {
          this.frmTraslado.controls["EmpleadoId"].setValue(empleado.data[0].id)
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

  cargarBodegaDestino(bodegaId: number) {
    this.service.getAll('Bodega').subscribe((res) => {
      res.data.forEach((item: any) => {
        if (item.id != bodegaId) {
          this.listBodegasDestino.update(listBodegasDestino => {
            const DataSelectDto: DataSelectDto = {
              id: item.id,
              textoMostrar: `${item.codigo} - ${item.nombre}`,
              activo: item.activo
            };

            return [...listBodegasDestino, DataSelectDto];
          });
        }
      });
    });
  }

  cargarBodegas() {
    this.service.getAll('Bodega').subscribe((res) => {
      res.data.forEach((item: any) => {
        this.listBodegas.update(listBodegas => {
          const DataSelectDto: DataSelectDto = {
            id: item.id,
            textoMostrar: `${item.codigo} - ${item.nombre}`,
            activo: item.activo
          };

          return [...listBodegas, DataSelectDto];
        });
      });
    });
  }

  cargarInventarioDetalle(bodegaId: number) {
    this.isLoading = true;
    var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = bodegaId; data.nameForeignKey = "BodegaId"
    this.service.datatableKey("DetalleInventarioBodega", data).subscribe((res) => {
      res.data.forEach((item: any) => {
        this.listInventarioDetalle.update(listInventarioDetalle => {
          const DataAutoCompleteDto = {
            id: item.id,
            name: `${item.inventarioDetalle}`,
            inventarioDetalle: item.inventarioDetalleId,
          };

          return [...listInventarioDetalle, DataAutoCompleteDto];
        });
      })

      this.isLoading = false;
    });
  }

  agregar() {
    this.helperService.showLoading();
    var insumo = this.id;
    var insumoValidado = this.validarInsumo(insumo);
    if (insumoValidado.length == 0) {
      //Agregar insumo nuevo
      this.frmTraslado.controls["Cantidad"].setValue(1);
      this.service.getById("Bodega", this.frmTraslado.controls["BodegaId"].value).subscribe((bodega) => {
        if (bodega.status) {
          this.service.getById("Bodega", this.frmTraslado.controls["BodegaDestinoId"].value).subscribe((bodegaDestino) => {
            if (bodegaDestino.status) {
              this.service.getById("DetalleInventarioBodega", insumo).subscribe((detalleInventarioBodega) => {
                if (detalleInventarioBodega.status) {
                  this.service.getById("InventarioDetalle", detalleInventarioBodega.data.inventarioDetalleId).subscribe((inventarioDetalle) => {
                    if (inventarioDetalle.status) {
                      this.service.getById("Insumo", inventarioDetalle.data.insumoId).subscribe((res) => {
                        if (res.status) {
                          let traslado = {
                            Bodega: bodega.data.nombre,
                            BodegaDestino: bodegaDestino.data.nombre,
                            InventarioDetalle: res.data.nombre,
                            Existencias: detalleInventarioBodega.data.cantidad,
                            ...this.frmTraslado.value,
                          };

                          this.trasladoBodega.update((trasladoBodega) => [...trasladoBodega, traslado]);
                          setTimeout(() => {
                            this.helperService.hideLoading();
                          }, 200);
                        } else {
                          setTimeout(() => {
                            this.helperService.hideLoading();
                          }, 200);
                        }
                      });
                    } else {
                      setTimeout(() => {
                        this.helperService.hideLoading();
                      }, 200);
                    }
                  });
                } else {
                  setTimeout(() => {
                    this.helperService.hideLoading();
                  }, 200);
                }
              });
            } else {
              setTimeout(() => {
                this.helperService.hideLoading();
              }, 200);
            }
          });
        } else {
          setTimeout(() => {
            this.helperService.hideLoading();
          }, 200);
        }
      });
    } else {
      //Sumar la cantidad
      var inventarioDetalleId = insumoValidado[0].InventarioDetalleId;
      for (let i = 0; i < this.trasladoBodega().length; i++) {
        if (this.trasladoBodega()[i].InventarioDetalleId == inventarioDetalleId) {

          var nuevaCantidad = this.trasladoBodega()[i].Cantidad + 1;

          this.trasladoBodega.update((trasladoBodega) => {
            return trasladoBodega.map((trasladoBodega, position) => {
              if (position === i) {
                return {
                  ...trasladoBodega,
                  Cantidad: nuevaCantidad,
                }
              }
              return trasladoBodega;
            })
          });
        }
      }
      setTimeout(() => {
        this.helperService.hideLoading();
      }, 200);
    }
  }

  changeCantidad(event: any, index: number) {
    var inputCantidad = event.target as HTMLInputElement;
    if (inputCantidad.value != '') {
      var nuevaCantidad = Number(inputCantidad.value);
      if (nuevaCantidad == 0) {
        nuevaCantidad = 1;
      }

      this.trasladoBodega.update((trasladoBodega) => {
        return trasladoBodega.map((trasladoBodega, position) => {
          if (position === index) {
            return {
              ...trasladoBodega,
              Cantidad: nuevaCantidad,
            }
          }
          return trasladoBodega;
        })
      });
    }
  }

  delete(index: number) {
    this.trasladoBodega.update((trasladoBodega) => trasladoBodega.filter((detalle, position) => position !== index));
  }

  save() {
    if (this.trasladoBodega().length > 0) {
      this.helperService.showLoading();
      this.serviceTraslado.trasladoBodegas("DetalleInventarioBodega", this.trasladoBodega()).subscribe(
        (response) => {
          if (response.status) {
            setTimeout(() => {
              this.helperService.hideLoading();
            }, 200);
            this.helperService.showMessage(MessageType.SUCCESS, "Traslado realizado con éxito");
            this.modalActive.close(true);
          }
        },
        (error) => {
          setTimeout(() => {
            this.helperService.hideLoading();
          }, 200);
          this.helperService.showMessage(MessageType.ERROR, error.error.message);
        }
      );
    } else {
      this.helperService.showMessage(MessageType.WARNING, "¡Agregue un insumo para realizar el traslado!");
    }
  }

  onChangeBodega(event: any) {
    if (typeof event != "undefined") {
      this.bodega = true;

      //Cargo las bodegas de destino
      this.listBodegasDestino = signal<DataSelectDto[]>([]);
      this.cargarBodegaDestino(event.id);

      //Cargo los inventarioDetalle segun la bodega de origen
      this.listInventarioDetalle = signal<DataAutoCompleteDto[]>([]);
      this.cargarInventarioDetalle(event.id);
    } else {
      this.bodega = false;

      //Limpio las listas
      this.frmTraslado.controls['BodegaDestinoId'].setValue(null);
      this.listBodegasDestino = signal<DataSelectDto[]>([]);

      this.frmTraslado.controls['InventarioDetalleId'].setValue(null);
      this.listInventarioDetalle = signal<DataAutoCompleteDto[]>([]);
    }
  }

  cancel() {
    this.modalActive.close();
  }

  validarInsumo(id: number) {
    var detalle: any[] = [];
    if (this.trasladoBodega().length > 0) {
      this.trasladoBodega().forEach((item: any) => {
        if (item.InventarioDetalleId == id) {
          detalle.push(item);
        }
      });
    }
    return detalle;
  }

  // Events Autocomplete

  selectEvent(item: any) {
    this.id = item.id;
    this.frmTraslado.controls["InventarioDetalleId"].setValue(item.inventarioDetalle);
  }

  onFocused() {
    this.auto.close();
  }

  onCleared() {
    this.auto.clear();
    this.auto.close();
    this.frmTraslado.controls['InventarioDetalleId'].setValue(null);
  }

  inputCleared() {
    this.auto.close();
    this.listInventarioDetalle = signal<DataAutoCompleteDto[]>([]);
    this.cargarInventarioDetalle(Number(this.frmTraslado.controls["BodegaId"].value));
  }
}
@NgModule({
  declarations: [
    TrasladoBodegasFormComponent,
  ],
  imports: [
    CommonModule,
    GeneralModule,
    AutocompleteLibModule
  ]
})
export class TrasladoBodegasFormModule { }