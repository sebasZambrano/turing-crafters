import { Component, OnInit, NgModule, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { SalonesFormComponent } from '../salones-form/salones-form.component'
import { GeneralParameterService } from '../../../../../generic/general.service';
import { DatatableParameter } from '../../../../../admin/datatable.parameters';
import { Salon } from '../salones.module';
import { LANGUAGE_DATATABLE } from 'src/app/admin/datatable.language';

@Component({
  selector: 'app-salones-index',
  standalone: false,
  templateUrl: './salones-index.component.html',
  styleUrl: './salones-index.component.css'
})
export class SalonesIndexComponent implements OnInit {
  API_URL: any;
  title = "Listado de Salones";
  breadcrumb!: any[];
  botones: String[] = ['btn-nuevo'];
  listSalones = signal<Salon[]>([]);

  constructor(
    private service: GeneralParameterService,
    private modalService: NgbModal,
    private helperService: HelperService
  ) {
    this.breadcrumb = [{ name: `Inicio`, icon: `fa-duotone fa-house` }, { name: "Parametros", icon: "fa-duotone fa-gears" }, { name: "Salones", icon: "fa-duotone fa-person-shelter" }];
  }

  ngOnInit(): void {
    this.cargarLista();
  }

  nuevo() {
    let modal = this.modalService.open(SalonesFormComponent, { size: 'lg', keyboard: false, backdrop: false, centered: true });

    modal.componentInstance.titleData = "Salón";
    modal.componentInstance.serviceName = "Salon";
    modal.result.then(res => {
      if (res) {
        this.refrescarTabla();
      }
    })
  }

  refrescarTabla() {
    $("#datatable").DataTable().destroy();
    this.listSalones = signal<Salon[]>([]);
    this.cargarLista();
  }

  cargarLista() {
    this.getData().then((datos) => {
      datos.data.forEach((item: any) => {
        this.listSalones.update(listSalones => {
          const Salon: Salon = {
            id: item.id,
            activo: item.activo,
            codigo: item.codigo,
            nombre: item.nombre,
            descripcion: item.descripcion,
            zonaId: item.zonaId,
            zona: item.zona
          };

          return [...listSalones, Salon];
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
      this.service.datatable("Salon", data).subscribe(
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
    let modal = this.modalService.open(SalonesFormComponent, { size: 'lg', keyboard: false, backdrop: false, centered: true });

    modal.componentInstance.serviceName = "Salon";
    modal.componentInstance.titleData = "Salon";
    modal.componentInstance.id = id;
    modal.result.then(res => {
      if (res) {
        this.refrescarTabla();
      }
    })
  }

  deleteGeneric(id: any) {
    this.helperService.confirmDelete(() => {
      this.service.delete("Salon", id).subscribe(
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
    SalonesIndexComponent,
  ],
  imports: [
    CommonModule,
    GeneralModule,
  ]
})
export class SalonesIndexModule { }