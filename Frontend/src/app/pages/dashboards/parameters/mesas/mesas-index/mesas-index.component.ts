import { Component, OnInit, NgModule, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { MesasFormComponent } from '../mesas-form/mesas-form.component'
import { GeneralParameterService } from '../../../../../generic/general.service';
import { DatatableParameter } from '../../../../../admin/datatable.parameters';
import { Mesa } from '../mesas.module';
import { LANGUAGE_DATATABLE } from 'src/app/admin/datatable.language';

@Component({
  selector: 'app-mesas-index',
  standalone: false,
  templateUrl: './mesas-index.component.html',
  styleUrl: './mesas-index.component.css'
})
export class MesasIndexComponent implements OnInit {
  API_URL: any;
  title = "Listado de Mesas";
  breadcrumb!: any[];
  botones: String[] = ['btn-nuevo'];
  listMesas = signal<Mesa[]>([]);

  constructor(
    private service: GeneralParameterService,
    private modalService: NgbModal,
    private helperService: HelperService
  ) {
    this.breadcrumb = [{ name: `Inicio`, icon: `fa-duotone fa-house` }, { name: "Parametros", icon: "fa-duotone fa-gears" }, { name: "Mesas", icon: "fa-duotone fa-table-picnic" }];
  }

  ngOnInit(): void {
    this.cargarLista();
  }

  nuevo() {
    let modal = this.modalService.open(MesasFormComponent, { size: 'lg', keyboard: false, backdrop: false, centered: true });

    modal.componentInstance.titleData = "Mesa";
    modal.componentInstance.serviceName = "Mesa";
    modal.result.then(res => {
      if (res) {
        this.refrescarTabla();
      }
    })
  }

  refrescarTabla() {
    $("#datatable").DataTable().destroy();
    this.listMesas = signal<Mesa[]>([]);
    this.cargarLista();
  }

  cargarLista() {
    this.getData().then((datos) => {
      datos.data.forEach((item: any) => {
        this.listMesas.update(listMesas => {
          const Mesa: Mesa = {
            id: item.id,
            activo: item.activo,
            codigo: item.codigo,
            nombre: item.nombre,
            descripcion: item.descripcion,
            salonId: item.salonId,
            salon: item.salon,
            cupo: item.cupo,
            estadoId: item.estadoId,
            estado: item.estado,
            orden: {
              id: 0,
              activo: false,
              codigo: "",
              descripcion: "",
              cantidadPersonas: 0,
              total: 0,
              mesaId: item.id,
              empleadoId: 0,
              estadoId: 0,
              mesa: item.nombre,
              empleado: "",
              estado: "",
              createAt: undefined,
            }
          };

          return [...listMesas, Mesa];
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
      this.service.datatable("Mesa", data).subscribe(
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
    let modal = this.modalService.open(MesasFormComponent, { size: 'lg', keyboard: false, backdrop: false, centered: true });

    modal.componentInstance.serviceName = "Mesa";
    modal.componentInstance.titleData = "Mesa";
    modal.componentInstance.id = id;
    modal.result.then(res => {
      if (res) {
        this.refrescarTabla();
      }
    })
  }

  deleteGeneric(id: any) {
    this.helperService.confirmDelete(() => {
      this.service.delete("Mesa", id).subscribe(
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
    MesasIndexComponent,
  ],
  imports: [
    CommonModule,
    GeneralModule,
  ]
})
export class MesasIndexModule { }