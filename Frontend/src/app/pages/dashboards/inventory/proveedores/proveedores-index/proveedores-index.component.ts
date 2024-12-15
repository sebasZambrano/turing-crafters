import { Component, OnInit, NgModule, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../../generic/general.service';
import { DatatableParameter } from '../../../../../admin/datatable.parameters';
import { Proveedor } from '../proveedores.module';
import { LANGUAGE_DATATABLE } from 'src/app/admin/datatable.language';

@Component({
  selector: 'app-proveedores-index',
  standalone: false,
  templateUrl: './proveedores-index.component.html',
  styleUrl: './proveedores-index.component.css'
})
export class ProveedoresIndexComponent implements OnInit {
  title = "Listado de Proveedores";
  breadcrumb!: any[];
  botones: String[] = ['btn-nuevo'];
  listProveedores = signal<Proveedor[]>([]);

  constructor(
    private service: GeneralParameterService,
    private helperService: HelperService
  ) {
    this.breadcrumb = [{ name: `Inicio`, icon: `fa-duotone fa-house` }, { name: "Inventario", icon: "fa-duotone fa-boxes-stacked" }, { name: "Proveedores", icon: "fa-duotone fa-people-carry-box" }];
  }

  ngOnInit(): void {
    this.cargarLista();
  }

  cargarLista() {
    this.getData()
      .then((datos) => {
        datos.data.forEach((item: any) => {
          this.listProveedores.update(listProveedores => {
            const Proveedor: Proveedor = {
              id: item.id,
              activo: item.activo,
              numeroCuenta: item.numeroCuenta,
              empresaId: item.empresaId,
              empresa: item.empresa,
              bancoId: item.bancoId,
              banco: item.banco,
            };

            return [...listProveedores, Proveedor];
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
      this.service.datatable("Proveedor", data).subscribe(
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
    this.listProveedores = signal<Proveedor[]>([]);
    this.cargarLista();
  }

  nuevo() {
    this.helperService.redirectApp("/dashboard/inventario/proveedores/crear");
  }

  update(id: any) {
    this.helperService.redirectApp(`/dashboard/inventario/proveedores/editar/${id}`);
  }

  deleteGeneric(id: any) {
    this.helperService.confirmDelete(() => {
      this.service.delete("Proveedor", id).subscribe(
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
    ProveedoresIndexComponent,
  ],
  imports: [
    CommonModule,
    GeneralModule,
  ]
})
export class ProveedoresIndexModule { }