import { Component, Input, OnInit, signal, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { LANGUAGE_DATATABLE } from 'src/app/admin/datatable.language';
import { DatatableParameter } from 'src/app/admin/datatable.parameters';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../generic/general.service';
import { DataAutoCompleteDto } from '../../../../generic/dataAutoCompleteDto';
import { BitacorasInventariosComponent } from '../bitacoras-inventarios/bitacoras-inventarios.component';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { DetallesInventariosBodegasIndexComponent } from '../detalles-inventarios-bodegas/detalles-inventarios-bodegas-index/detalles-inventarios-bodegas-index.component';
import { AutocompleteLibModule } from 'angular-ng-autocomplete';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-inventarios-detalles',
  standalone: false,
  templateUrl: './inventarios-detalles.component.html',
  styleUrl: './inventarios-detalles.component.css'
})
export class InventariosDetallesComponent implements OnInit {
  @ViewChild('auto') auto: any;
  keyword = 'name';
  isLoading: boolean = false;
  botones = ['btn-guardar'];
  @Input() InventarioId: any = null;
  frmInventariosDetalles: FormGroup;
  statusForm: boolean = true;
  listInsumos = signal<DataAutoCompleteDto[]>([]);
  public dtTrigger: Subject<any> = new Subject();
  @ViewChild(DataTableDirective) dtElement!: DataTableDirective;
  dtOptions: DataTables.Settings = {};

  constructor(
    private helperService: HelperService,
    private service: GeneralParameterService,
    private modalService: NgbModal,
  ) {
    this.frmInventariosDetalles = new FormGroup({
      Id: new FormControl(0, Validators.required),
      CantidadTotal: new FormControl(0, Validators.required),
      CantidadUsada: new FormControl(0, Validators.required),
      CantidadIngresada: new FormControl(0, Validators.required),
      PrecioCosto: new FormControl(0, Validators.required),
      InventarioId: new FormControl(this.InventarioId, Validators.required),
      InsumoId: new FormControl(null, Validators.required),
      Activo: new FormControl(true, Validators.required),
    });
  }

  ngOnInit(): void {
    this.cargarLista();
    this.cargarInsumos();
    this.validarEmpleado();
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
  
  validarEmpleado() {
    var personaId = localStorage.getItem("persona_Id");
    if (personaId != null) {
      var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = personaId; data.nameForeignKey = "PersonaId";
      this.service.datatableKey("Empleado", data).subscribe((empleado) => {
        if (empleado.data.length == 1) {
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

  ngAfterViewInit() {
    this.dtTrigger.next(this.dtOptions);
  }

  ngOnDestroy(): void {
    this.dtTrigger.unsubscribe();
  }

  cargarLista() {
    this.dtOptions = {
      dom: 'Blfrtip',
      processing: true,
      ordering: true,
      responsive: true,
      paging: true,
      order: [0, 'desc'],
      language: LANGUAGE_DATATABLE,
      ajax: (dataTablesParameters: any, callback: any) => {
        var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = this.InventarioId; data.nameForeignKey = "InventarioId";
        this.service.datatableKey("InventarioDetalle", data).subscribe((res) => {
          callback({
            recordsTotal: res.data.length,
            recordsFiltered: res.data.length,
            draw: dataTablesParameters.draw,
            data: res.data,
          });
        });
      },
      columns: [
        {
          title: 'INSUMO',
          data: 'insumo',
          className: 'text-center',
        },
        {
          title: 'CANTIDAD TOTAL',
          data: 'cantidadTotal',
          className: 'text-center',
        },
        {
          title: 'CANTIDAD USADA',
          data: 'cantidadUsada',
          className: 'text-center',
        },
        {
          title: 'CANTIDAD INGRESADA',
          data: 'cantidadIngresada',
          className: 'text-center',
        },
        {
          title: 'PENDIENTE ASIGNAR',
          data: 'cantidadPendienteAsignar',
          className: 'text-center',
        },
        {
          title: 'PRECIO COSTO',
          data: 'precioCosto',
          className: 'text-center',
        },
        {
          title: 'ESTADO',
          data: 'activo',
          className: 'text-center',
          render: function (item: any) {
            if (item) {
              return "<label class='text-center text-success'>Activo</label>";
            } else {
              return "<label class='text-center text-danger'>Inactivo</label>";
            }
          }
        },
        {
          title: 'ACCIONES',
          orderable: false,
          data: 'id',
          className: 'text-center',
          render: function (id: any) {
            return `<div role="group"  class="button-group " aria-label="Basic example">
                          <button type="button" title="Editar" class="btn btn-sm text-secondary btn-dropdown-modificar" data-id="${id}"><i class="fa-duotone fa-pen-to-square"></i> Editar</a>
                          <button type="button" title="Movimientos" class="btn btn-sm text-secondary btn-dropdown-movimiento" data-id="${id}"><i class="fa-duotone fa-person-dolly"></i> Movimiento</a>
                          <button type="button" title="Asignar Godega" class="btn btn-sm text-secondary btn-dropdown-asignar" data-id="${id}"><i class="fa-duotone fa-garage"></i> Asignar a bodega</a>
                        </div>`
          },
        }
      ],
      drawCallback: () => {
        $('.btn-dropdown-modificar')
          .off()
          .on('click', (event: any) => {
            this.service.getById("InventarioDetalle", event.currentTarget.dataset.id).subscribe((res) => {
              this.update(res.data);
            });
          });

        $('.btn-dropdown-movimiento')
          .off()
          .on('click', (event: any) => {
            this.service.getById("InventarioDetalle", event.currentTarget.dataset.id).subscribe((res) => {
              this.movimiento(res.data.insumoId);
            });
          });
        $('.btn-dropdown-asignar')
          .off()
          .on('click', (event: any) => {
            this.Bodegas(event.currentTarget.dataset.id);
          });
      }
    };
  }

  Bodegas(id: number) {
    var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = id; data.nameForeignKey = "Id";

    this.service.datatableKey("InventarioDetalle", data).subscribe((res: any) => {
      var dataBodega = new DatatableParameter(); dataBodega.pageNumber = ""; dataBodega.pageSize = ""; dataBodega.filter = ""; dataBodega.columnOrder = ""; dataBodega.directionOrder = ""; dataBodega.foreignKey = id; dataBodega.nameForeignKey = "InventarioDetalleId";
      this.service.datatableKey("DetalleInventarioBodega", dataBodega).subscribe((l: any) => {
        if (res.data[0].cantidadPendienteAsignar > 0) {
          let modal = this.modalService.open(DetallesInventariosBodegasIndexComponent, { size: 'md', keyboard: false, backdrop: false, centered: true });
          modal.componentInstance.detallesInventariosBodegas = l.data;
          modal.componentInstance.cantidadFacturar = res.data[0].cantidadPendienteAsignar;
          modal.componentInstance.inventarioDetalle = true;
          modal.componentInstance.title = "Cantidad total para asignar:";

          modal.result.then(response => {
            var nuevaCantidad = response.reduce((acumulador: any, detalle: any) => acumulador + detalle.cantidadFacturar, 0);
            if (nuevaCantidad > res.data[0].cantidadPendienteAsignar) {
              this.helperService.showMessage(MessageType.PROGRESS, "¡Supero la cantidad total para asignar en bodegas!");
            } else if (nuevaCantidad > 0) {
              this.ActualizarCantidadesDetallesInventarioBodegas(response);
            }
          });
        } else {
          this.helperService.showMessage(MessageType.PROGRESS, "¡No hay cantidades pendientes por asignar!");
        }
      });
    });
  }

  ActualizarCantidadesDetallesInventarioBodegas(data: any) {
    this.helperService.showLoading();
    var lstDetalleInventarioBodegaDto: any[] = [];
    data.forEach((element: any) => {
      if (element.cantidadFacturar > 0) {
        var dto = {
          Id: element.id,
          Activo: element.activo,
          Cantidad: (element.cantidad + element.cantidadFacturar),
          CantidadFacturar: element.cantidadFacturar,
          BodegaId: element.bodegaId,
          InventarioDetalleId: element.inventarioDetalleId,
          FacturaCompraId: 0,
          EmpleadoId: Number(localStorage.getItem('EmpleadoId')),
        }
        lstDetalleInventarioBodegaDto.push(dto);
      }
    });

    setTimeout(() => {
      this.service.updateDetalles("DetalleInventarioBodega", lstDetalleInventarioBodegaDto).subscribe(
        (response) => {
          if (response.status) {
            this.helperService.hideLoading();
            this.refrescarTabla();
            this.helperService.showMessage(
              MessageType.SUCCESS,
              response.message
            );
          } else {
            this.helperService.hideLoading();
          }
        },
        (error) => {
          this.helperService.hideLoading();
          this.helperService.showMessage(
            MessageType.WARNING,
            error.error.message
          );
        }
      );
    }, 500);
  }

  refrescarTabla() {
    if (typeof this.dtElement.dtInstance != 'undefined') {
      this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
        dtInstance.ajax.reload()
      });
    }
  }

  save() {
    this.frmInventariosDetalles.controls['InventarioId'].setValue(Number(this.InventarioId));
    if (this.frmInventariosDetalles.invalid) {
      this.statusForm = false;
      this.helperService.showMessage(MessageType.WARNING, Messages.EMPTYFIELD);
      return;
    }
    let data = this.frmInventariosDetalles.value;
    this.service.save("InventarioDetalle", this.frmInventariosDetalles.controls['Id'].value, data).subscribe(
      (response) => {
        if (response.status) {
          this.refrescarTabla();
          this.frmInventariosDetalles.reset();
          this.frmInventariosDetalles.controls['Id'].setValue(0);
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

  update(item: any) {
    this.frmInventariosDetalles.controls['Id'].setValue(item.id);
    this.frmInventariosDetalles.controls['CantidadTotal'].setValue(item.cantidadTotal);
    this.frmInventariosDetalles.controls['CantidadUsada'].setValue(item.cantidadUsada);
    this.frmInventariosDetalles.controls['CantidadIngresada'].setValue(item.cantidadIngresada);
    this.frmInventariosDetalles.controls['PrecioCosto'].setValue(item.precioCosto);
    this.frmInventariosDetalles.controls['InsumoId'].setValue(item.insumoId);
    this.frmInventariosDetalles.controls['Activo'].setValue(item.activo);
  }

  movimiento(insumoId: any) {
    const modal = this.modalService.open(BitacorasInventariosComponent, { size: 'xl', keyboard: false, backdrop: false, centered: true });
    modal.componentInstance.InsumoId = insumoId;
  }

  // Events Autocomplete

  selectEvent(item: any) {
    this.frmInventariosDetalles.controls["InsumoId"].setValue(item.id);
  }

  onFocused() {
    this.auto.close();
  }

  onCleared() {
    this.auto.clear();
    this.auto.close();
    this.frmInventariosDetalles.controls['InsumoId'].setValue(null);
  }

  inputCleared() {
    this.auto.close();
    this.listInsumos = signal<DataAutoCompleteDto[]>([]);
    this.cargarInsumos();
  }
}