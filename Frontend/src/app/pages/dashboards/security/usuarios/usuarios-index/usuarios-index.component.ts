import { Component, OnInit, NgModule, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { UsuariosPaswordFormComponent } from '../usuarios-pasword-form/usuarios-pasword-form.component'
import { GeneralParameterService } from '../../../../../generic/general.service';
import { DatatableParameter } from '../../../../../admin/datatable.parameters';
import { Usuario } from '../usuarios.module';
import { LANGUAGE_DATATABLE } from 'src/app/admin/datatable.language';

@Component({
  selector: 'app-usuarios-index',
  standalone: false,
  templateUrl: './usuarios-index.component.html',
  styleUrl: './usuarios-index.component.css'
})
export class UsuariosIndexComponent implements OnInit {
  API_URL: any;
  title = "Listado de Usuarios";
  breadcrumb!: any[];
  botones: String[] = ['btn-nuevo'];
  listUsuarios = signal<Usuario[]>([]);

  constructor(
    private service: GeneralParameterService,
    private modalService: NgbModal,
    private helperService: HelperService
  ) {
    this.breadcrumb = [{ name: `Inicio`, icon: `fa-duotone fa-house` }, { name: "Seguridad", icon: "fa-duotone fa-lock" }, { name: "Usuarios", icon: "fa-duotone fa-user-gear" }];
  }

  ngOnInit(): void {
    this.cargarLista();
  }

  cargarLista() {
    this.getData()
      .then((datos) => {
        datos.data.forEach((item: any) => {
          this.listUsuarios.update(listUsuarios => {
            const Usuario: Usuario = {
              id: item.id,
              activo: item.activo,
              userName: item.userName,
              password: item.password,
              personaId: item.personaId,
              persona: item.persona,
            };

            return [...listUsuarios, Usuario];
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
      this.service.datatable("Usuario", data).subscribe(
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
    this.listUsuarios = signal<Usuario[]>([]);
    this.cargarLista();
  }

  nuevo() {
    this.helperService.redirectApp("dashboard/seguridad/usuarios/crear");
  }

  update(id: any) {
    this.helperService.redirectApp(`dashboard/seguridad/usuarios/editar/${id}`);
  }

  deleteGeneric(id: any) {
    this.helperService.confirmDelete(() => {
      this.service.delete("Usuario", id).subscribe(
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

  changePassword(id: any) {
    let modal = this.modalService.open(UsuariosPaswordFormComponent, { size: 'lg', keyboard: false, backdrop: false, centered: true });

    modal.componentInstance.titleData = "Usuario";
    modal.componentInstance.serviceName = "Usuario";
    modal.componentInstance.id = id;
    modal.componentInstance.key = "Persona";

    modal.result.then(res => {
      if (res) {
        this.refrescarTabla();
      }
    })
  }
}

@NgModule({
  declarations: [
    UsuariosIndexComponent,
  ],
  imports: [
    CommonModule,
    GeneralModule,
  ]
})
export class UsuariosIndexModule { }