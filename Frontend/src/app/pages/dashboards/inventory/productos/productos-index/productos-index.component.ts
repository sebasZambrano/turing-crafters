import { Component, OnInit, NgModule, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../../generic/general.service';
import { DatatableParameter } from '../../../../../admin/datatable.parameters';
import { LANGUAGE_DATATABLE } from 'src/app/admin/datatable.language';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-productos-index',
  standalone: false,
  templateUrl: './productos-index.component.html',
  styleUrl: './productos-index.component.css'
})
export class ProductosIndexComponent implements OnInit {
  title = "Listado de Productos";
  breadcrumb!: any[];
  botones: String[] = ['btn-nuevo'];
  public dtTrigger: Subject<any> = new Subject();
  @ViewChild(DataTableDirective) dtElement!: DataTableDirective;
  dtOptions: DataTables.Settings = {};

  constructor(
    private service: GeneralParameterService,
    public helperService: HelperService
  ) {
    this.breadcrumb = [{ name: `Inicio`, icon: `fa-duotone fa-house` }, { name: "Inventario", icon: "fa-duotone fa-boxes-stacked" }, { name: "Productos", icon: "fa-duotone fa-shirt" }];
  }

  ngOnInit(): void {
    this.cargarLista();
  }

  ngAfterViewInit() {
    this.dtTrigger.next(this.dtOptions);
  }

  ngOnDestroy(): void {
    this.dtTrigger.unsubscribe();
  }

  cargarLista() {
    const that = this;
    this.dtOptions = {
      dom: 'Blfrtip',
      processing: true,
      ordering: true,
      responsive: true,
      paging: true,
      order: [0, 'desc'],
      language: LANGUAGE_DATATABLE,
      ajax: (dataTablesParameters: any, callback: any) => {
        var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = "";
        this.service.datatable("Producto", data).subscribe((res) => {
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
          title: 'CÓDIGO',
          data: 'codigo',
          className: 'text-center',
        },
        {
          title: 'NOMBRE',
          data: 'nombre',
          className: 'text-center',
        },
        {
          title: 'DESCRIPCION CORTA',
          data: 'descripcionCorta',
          className: 'text-center',
        },
        {
          title: 'DESCRIPCION LARGA',
          data: 'descripcionLarga',
          className: 'text-center',
        },
        {
          title: 'PRECIO',
          data: 'precio',
          className: 'text-right',
          render: function (data: any) {
            return '$' + that.helperService.formaterNumber(data);
          },
        },
        {
          title: 'PRECIO COSTO',
          data: 'precioCosto',
          className: 'text-right',
          render: function (data: any) {
            return '$' + that.helperService.formaterNumber(data);
          },
        },
        {
          title: 'DESCUENTO',
          data: 'descuento',
          className: 'text-right',
          render: function (data: any) {
            return '$' + that.helperService.formaterNumber(data);
          },
        },
        {
          title: 'IVA',
          data: 'iva',
          className: 'text-center',
        },
        {
          title: 'CATEGORIA',
          data: 'categoria',
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
                          <button type="button" title="Editar" class="btn btn-sm text-secondary btn-dropdown-modificar" data-id="${id}"><i class="fa-duotone fa-pen-to-square" data-id="${id}"></i> Editar</button>
                          <button type="button" title="Eliminar" class="btn btn-sm text-secondary btn-dropdown-eliminar" data-id="${id}"><i class="fa-duotone fa-trash-can" data-id="${id}"></i> Eliminar</button>
                        </div>`
          },
        }
      ],
      drawCallback: () => {
        $('.btn-dropdown-modificar')
          .off()
          .on('click', (event: any) => {
            this.update(event.currentTarget.dataset.id);
          });

        $('.btn-dropdown-eliminar')
          .off()
          .on('click', (event: any) => {
            this.deleteGeneric(event.currentTarget.dataset.id);
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

  nuevo() {
    this.helperService.redirectApp("/dashboard/inventario/productos/crear");
  }

  update(id: any) {
    this.helperService.redirectApp(`/dashboard/inventario/productos/editar/${id}`);
  }

  deleteGeneric(id: any) {
    this.helperService.confirmDelete(() => {
      // Eliminar imagenes exixtente
      var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = id; data.nameForeignKey = "TablaId";
      this.service.datatableKey("Archivo", data).subscribe((res) => {
        if (res.data.length > 0) {
          res.data.forEach((item: any) => {
            if (item.tabla == "Producto") {
              this.service.delete("Archivo", item.id).subscribe(() => { });
            }
          });
        }
      });

      this.service.delete("Producto", id).subscribe(
        (response) => {
          if (response.status) {
            this.helperService.showMessage(MessageType.SUCCESS, Messages.DELETESUCCESS);
            this.refrescarTabla();
          }
        },
        (error) => {
          this.helperService.showMessage(MessageType.ERROR, error.error.message);
        }
      )
    });
  }
}

@NgModule({
  declarations: [
    ProductosIndexComponent,
  ],
  imports: [
    CommonModule,
    GeneralModule,
  ]
})
export class ProductosIndexModule { }