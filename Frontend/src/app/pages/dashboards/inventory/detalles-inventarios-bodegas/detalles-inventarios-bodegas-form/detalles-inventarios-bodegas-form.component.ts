import { Component, Input, OnInit, signal, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { LANGUAGE_DATATABLE } from 'src/app/admin/datatable.language';
import { DatatableParameter } from 'src/app/admin/datatable.parameters';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../../generic/general.service';
import { DataAutoCompleteDto } from '../../../../../generic/dataAutoCompleteDto';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BitacorasInventariosComponent } from '../../bitacoras-inventarios/bitacoras-inventarios.component';
import { AutocompleteLibModule } from 'angular-ng-autocomplete';

@Component({
  selector: 'app-detalles-inventarios-bodegas-form',
  standalone: false,
  templateUrl: './detalles-inventarios-bodegas-form.component.html',
  styleUrl: './detalles-inventarios-bodegas-form.component.css'
})
export class DetallesInventariosBodegasFormComponent implements OnInit {
  @ViewChild('auto') auto: any;
  keyword = 'name';
  isLoading: boolean = false;
  botones = ['btn-guardar'];
  @Input() BodegaId: any = null;
  frmDetalleInevntarioBodega: FormGroup;
  statusForm: boolean = true;
  listInventarioDetalle = signal<DataAutoCompleteDto[]>([]);
  public dtTrigger: Subject<any> = new Subject();
  @ViewChild(DataTableDirective) dtElement!: DataTableDirective;
  dtOptions: DataTables.Settings = {};

  constructor(
    private helperService: HelperService,
    private service: GeneralParameterService,
    private modalService: NgbModal,
  ) {
    this.frmDetalleInevntarioBodega = new FormGroup({
      Id: new FormControl(0, Validators.required),
      Cantidad: new FormControl(0, Validators.required),
      CantidadFacturar: new FormControl(0),
      BodegaId: new FormControl(Number(this.BodegaId), Validators.required),
      InventarioDetalleId: new FormControl(null, Validators.required),
      Activo: new FormControl(true, Validators.required),
    });
  }

  ngOnInit(): void {
    this.cargarLista();
    this.cargarInventarioDetalle();
  }

  cargarLista() {
    this.dtOptions = {
      processing: true,
      ordering: true,
      responsive: true,
      paging: true,
      order: [0, 'desc'],
      language: LANGUAGE_DATATABLE,
      ajax: (dataTablesParameters: any, callback: any) => {
        var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = this.BodegaId; data.nameForeignKey = "BodegaId";
        this.service.datatableKey("DetalleInventarioBodega", data).subscribe((res) => {
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
          title: 'PRODUCTO',
          data: 'inventarioDetalle',
          className: 'text-center',
        },
        {
          title: 'CANTIDAD',
          data: 'cantidad',
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
                          <button type="button" title="Editar" class="btn btn-sm text-secondary btn-dropdown-modificar" data-id="${id}"><i class="fa-duotone fa-pen-to-square"></i> Editar</button>
                          <button type="button" title="Eliminar" class="btn btn-sm text-secondary btn-dropdown-eliminar" data-id="${id}"><i class="fa-duotone fa-trash-can"></i> Eliminar</button>
                          <button type="button" title="Movimientos" class="btn btn-sm text-secondary btn-dropdown-movimiento" data-id="${id}"><i class="fa-duotone fa-person-dolly"></i> Movimiento</a>
                        </div>`
          },
        }
      ],
      drawCallback: () => {
        $('.btn-dropdown-modificar')
          .off()
          .on('click', (event: any) => {
            this.service.getById("DetalleInventarioBodega", event.currentTarget.dataset.id).subscribe((res) => {
              this.update(res.data);
            })
          });
        $('.btn-dropdown-movimiento')
          .off()
          .on('click', (event: any) => {
            this.movimiento(event.currentTarget.dataset.id);
          });
        $('.btn-dropdown-eliminar')
          .off()
          .on('click', (event: any) => {
            this.deleteGeneric(event.currentTarget.dataset.id);
          });
      }
    };
  }

  movimiento(detalleInventarioBodegaId: any) {
    const modal = this.modalService.open(BitacorasInventariosComponent, { size: 'xl', keyboard: false, backdrop: false, centered: true });
    modal.componentInstance.inventarioBodega = true;
    modal.componentInstance.InsumoId = detalleInventarioBodegaId;
  }

  cargarInventarioDetalle() {
    this.isLoading = true;
    var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = "";
    this.service.datatable("InventarioDetalle", data).subscribe((res) => {
      res.data.forEach((item: any) => {
        this.listInventarioDetalle.update(listInventarioDetalle => {
          const DataAutoCompleteDto: DataAutoCompleteDto = {
            id: item.id,
            name: `${item.insumo}`,
          };

          return [...listInventarioDetalle, DataAutoCompleteDto];
        });
      })

      this.isLoading = false;
    });
  }

  ngAfterViewInit() {
    this.dtTrigger.next(this.dtOptions);
  }

  ngOnDestroy(): void {
    this.dtTrigger.unsubscribe();
  }

  refrescarTabla() {
    if (typeof this.dtElement.dtInstance != 'undefined') {
      this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
        dtInstance.ajax.reload()
      });
    }
  }

  save() {
    this.frmDetalleInevntarioBodega.controls['BodegaId'].setValue(Number(this.BodegaId));
    if (this.frmDetalleInevntarioBodega.invalid) {
      this.statusForm = false;
      this.helperService.showMessage(MessageType.WARNING, Messages.EMPTYFIELD);
      return;
    }
    let data = this.frmDetalleInevntarioBodega.value;
    this.service.save("DetalleInventarioBodega", this.frmDetalleInevntarioBodega.controls['Id'].value, data).subscribe(
      (response) => {
        if (response.status) {
          this.refrescarTabla();
          this.frmDetalleInevntarioBodega.reset();
          this.frmDetalleInevntarioBodega.controls['Id'].setValue(0);
          this.frmDetalleInevntarioBodega.controls['CantidadFacturar'].setValue(0);
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
    this.frmDetalleInevntarioBodega.controls['Id'].setValue(item.id);
    this.frmDetalleInevntarioBodega.controls['Cantidad'].setValue(item.cantidad);
    this.frmDetalleInevntarioBodega.controls['InventarioDetalleId'].setValue(item.inventarioDetalleId);
    this.frmDetalleInevntarioBodega.controls['Activo'].setValue(item.activo);
    // this.auto.select(item.inventarioDetalleId);
  }

  deleteGeneric(id: any) {
    this.helperService.confirmDelete(() => {
      this.service.delete("DetalleInventarioBodega", id).subscribe(
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

  // Events Autocomplete

  selectEvent(item: any) {
    this.frmDetalleInevntarioBodega.controls["InventarioDetalleId"].setValue(item.id);
  }

  onFocused() {
    this.auto.close();
  }

  onCleared() {
    this.auto.clear();
    this.auto.close();
    this.frmDetalleInevntarioBodega.controls['InventarioDetalleId'].setValue(null);
  }

  inputCleared() {
    this.auto.close();
    this.listInventarioDetalle = signal<DataAutoCompleteDto[]>([]);
    this.cargarInventarioDetalle();
  }
}
