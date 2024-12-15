import { Component, OnInit, NgModule, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { MotivosFormComponent } from '../motivos-form/motivos-form.component'
import { GeneralParameterService } from '../../../../../generic/general.service';
import { DatatableParameter } from '../../../../../admin/datatable.parameters';
import { Motivo } from '../motivos.module';
import { LANGUAGE_DATATABLE } from 'src/app/admin/datatable.language';

@Component({
  selector: 'app-motivos-index',
  standalone: false,
  templateUrl: './motivos-index.component.html',
  styleUrl: './motivos-index.component.css'
})
export class MotivosIndexComponent implements OnInit {
  API_URL: any;
  title = "Listado de Motivos";
  breadcrumb!: any[];
  botones: String[] = ['btn-nuevo'];
  listMotivos = signal<Motivo[]>([]);

  constructor(
    private service: GeneralParameterService,
    private modalService: NgbModal,
    private helperService: HelperService
  ) {
    this.breadcrumb = [{ name: `Inicio`, icon: `fa-duotone fa-house` }, { name: "Parametros", icon: "fa-duotone fa-gears" }, { name: "Motivos", icon: "fa-duotone fa-file-circle-exclamation" }];
  }

  ngOnInit(): void {
    this.cargarLista();
  }

  nuevo() {
    let modal = this.modalService.open(MotivosFormComponent, { size: 'lg', keyboard: false, backdrop: false, centered: true });

    modal.componentInstance.titleData = "Motivo";
    modal.componentInstance.serviceName = "Motivo";
    modal.result.then(res => {
      if (res) {
        this.refrescarTabla();
      }
    })
  }

  refrescarTabla() {
    $("#datatable").DataTable().destroy();
    this.listMotivos = signal<Motivo[]>([]);
    this.cargarLista();
  }

  cargarLista() {
    this.getData().then((datos) => {
      datos.data.forEach((item: any) => {
        this.listMotivos.update(listMotivos => {
          const Motivo: Motivo = {
            id: item.id,
            activo: item.activo,
            codigo: item.codigo,
            nombre: item.nombre,
            descripcion: item.descripcion,
          };

          return [...listMotivos, Motivo];
        });
      });

      setTimeout(() => {
        $("#datatable").DataTable({
          destroy: true,
          language: LANGUAGE_DATATABLE,
          processing: true,
          dom: 'Blfrtip'
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
      this.service.datatable("Motivo", data).subscribe(
        (datos) => {
          resolve(datos);
        },
        (error) => {
          reject(error);
        }
      )
    });
  }

  updateGeneric(id: any) {
    let modal = this.modalService.open(MotivosFormComponent, { size: 'lg', keyboard: false, backdrop: false, centered: true });

    modal.componentInstance.serviceName = "Motivo";
    modal.componentInstance.titleData = "Motivo";
    modal.componentInstance.id = id;
    modal.result.then(res => {
      if (res) {
        this.refrescarTabla();
      }
    })
  }

  deleteGeneric(id: any) {
    this.helperService.confirmDelete(() => {
      this.service.delete("Motivo", id).subscribe(
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
    MotivosIndexComponent,
  ],
  imports: [
    CommonModule,
    GeneralModule,
  ]
})
export class MotivosIndexModule { }