import { Component, OnInit, NgModule, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { GeneralParameterService } from '../../../../../generic/general.service';
import { DatatableParameter } from '../../../../../admin/datatable.parameters';
import { Generic } from '../../../../../generic/generic.module';
import { LANGUAGE_DATATABLE } from 'src/app/admin/datatable.language';
import { TrasladoBodegasFormComponent } from '../../traslado-bodegas/traslado-bodegas-form.component';

@Component({
  selector: 'app-bodegas-index',
  standalone: false,
  templateUrl: './bodegas-index.component.html',
  styleUrl: './bodegas-index.component.css'
})
export class BodegasIndexComponent implements OnInit {
  title = "Listado de Bodegas";
  breadcrumb!: any[];
  botones: String[] = ['btn-nuevo', 'btn-traslado'];
  listBodegas = signal<Generic[]>([]);

  constructor(
    private service: GeneralParameterService,
    private helperService: HelperService,
    private modalService: NgbModal,
  ) {
    this.breadcrumb = [{ name: `Inicio`, icon: `fa-duotone fa-house` }, { name: "Inventario", icon: "fa-duotone fa-boxes-stacked" }, { name: "Bodegas", icon: "fa-duotone fa-warehouse" }];
  }

  ngOnInit(): void {
    this.cargarLista();
  }

  cargarLista() {
    this.getData().then((datos) => {
      datos.data.forEach((item: any) => {
        this.listBodegas.update(listBodegas => {
          const Generic: Generic = {
            id: item.id,
            activo: item.activo,
            codigo: item.codigo,
            nombre: item.nombre,
          };

          return [...listBodegas, Generic];
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
    var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = "";
    return new Promise((resolve, reject) => {
      this.service.datatable("Bodega", data).subscribe(
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
    this.listBodegas = signal<Generic[]>([]);
    this.cargarLista();
  }

  nuevo() {
    this.helperService.redirectApp("/dashboard/inventario/bodegas/crear");
  }

  traslado() {
    let modal = this.modalService.open(TrasladoBodegasFormComponent, { size: 'lg', keyboard: false, backdrop: false, centered: true });
    modal.result.then(res => {
      if (res) {
        this.refrescarTabla();
      }
    });
  }

  update(id: any) {
    this.helperService.redirectApp(`/dashboard/inventario/bodegas/editar/${id}`);
  }

  deleteGeneric(id: any) {
    this.helperService.confirmDelete(() => {
      this.service.delete("Bodega", id).subscribe(
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
}

@NgModule({
  declarations: [
    BodegasIndexComponent,
  ],
  imports: [
    CommonModule,
    GeneralModule,
  ]
})
export class BodegasIndexModule { }