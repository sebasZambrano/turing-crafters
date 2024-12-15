import { Component, Input, OnInit, signal, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { LANGUAGE_DATATABLE } from 'src/app/admin/datatable.language';
import { DatatableParameter } from 'src/app/admin/datatable.parameters';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../generic/general.service';
import { DataTableDirective } from 'angular-datatables';
import { DataSelectDto } from 'src/app/generic/dataSelectDto';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-impresoras-categorias',
  standalone: false,
  templateUrl: './impresoras-categorias.component.html',
  styleUrl: './impresoras-categorias.component.css'
})
export class InventariosDetallesComponent implements OnInit {
  botones = ['btn-guardar'];
  @Input() ImpresoraId: any = null;
  frmImpresorasCategorias: FormGroup;
  statusForm: boolean = true;
  listCategorias = signal<DataSelectDto[]>([]);
  listSalones = signal<DataSelectDto[]>([]);
  public dtTrigger: Subject<any> = new Subject();
  @ViewChild(DataTableDirective) dtElement!: DataTableDirective;
  dtOptions: DataTables.Settings = {};

  constructor(
    private helperService: HelperService,
    private service: GeneralParameterService,
    private modalService: NgbModal,
  ) {
    this.frmImpresorasCategorias = new FormGroup({
      Id: new FormControl(0, Validators.required),
      CategoriaId: new FormControl(null, [Validators.required]),
      ImpresoraId: new FormControl(this.ImpresoraId, [Validators.required]),
      SalonId: new FormControl(null, [Validators.required]),
      Activo: new FormControl(true, Validators.required),
    });
  }

  ngOnInit(): void {
    this.cargarLista();
    this.cargarCategorias();
    this.cargarSalon();
  }

  cargarCategorias() {
    this.service.getAll('Categoria').subscribe((res) => {
      res.data.forEach((item: any) => {
        this.listCategorias.update(listCategorias => {
          const DataAutoCompleteDto: DataSelectDto = {
            id: item.id,
            textoMostrar: `${item.codigo} - ${item.nombre}`,
            activo: item.activo,
          };

          return [...listCategorias, DataAutoCompleteDto];
        });
      });
    });
  }

  cargarSalon() {
    this.service.getAll('Salon').subscribe((res) => {
      res.data.forEach((item: any) => {
        this.listSalones.update(listSalones => {
          const DataAutoCompleteDto: DataSelectDto = {
            id: item.id,
            textoMostrar: `${item.codigo} - ${item.nombre}`,
            activo: item.activo,
          };

          return [...listSalones, DataAutoCompleteDto];
        });
      });
    });
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
        var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = this.ImpresoraId; data.nameForeignKey = "ImpresoraId";
        this.service.datatableKey("ImpresoraCategoria", data).subscribe((res) => {
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
          title: 'IMPRESORA',
          data: 'impresora',
          className: 'text-center',
        },
        {
          title: 'CATEGORÍA',
          data: 'categoria',
          className: 'text-center',
        },
        {
          title: 'SALÓN',
          data: 'salon',
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
                    </div>`
          },
        }
      ],
      drawCallback: () => {
        $('.btn-dropdown-modificar')
          .off()
          .on('click', (event: any) => {
            this.service.getById("ImpresoraCategoria", event.currentTarget.dataset.id).subscribe((res) => {
              this.update(res.data);
            });
          });
      }
    };
  }

  refrescarTabla() {
    if (typeof this.dtElement.dtInstance != 'undefined') {
      this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
        dtInstance.ajax.reload()
      });
    }
  }

  save() {
    this.frmImpresorasCategorias.controls['ImpresoraId'].setValue(Number(this.ImpresoraId));
    if (this.frmImpresorasCategorias.invalid) {
      this.statusForm = false;
      this.helperService.showMessage(MessageType.WARNING, Messages.EMPTYFIELD);
      return;
    }
    let data = this.frmImpresorasCategorias.value;
    this.service.save("ImpresoraCategoria", this.frmImpresorasCategorias.controls['Id'].value, data).subscribe(
      (response) => {
        if (response.status) {
          this.refrescarTabla();
          this.frmImpresorasCategorias.reset();
          this.frmImpresorasCategorias.controls['Id'].setValue(0);
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
    this.frmImpresorasCategorias.controls['Id'].setValue(item.id);
    this.frmImpresorasCategorias.controls['CategoriaId'].setValue(item.categoriaId);
    this.frmImpresorasCategorias.controls['ImpresoraId'].setValue(item.impresoraId);
    this.frmImpresorasCategorias.controls['SalonId'].setValue(item.salonId);
    this.frmImpresorasCategorias.controls['Activo'].setValue(item.activo);
  }
}