import { Component, OnInit, NgModule, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../../generic/general.service';
import { DatatableParameter } from '../../../../../admin/datatable.parameters';
import { Inventario } from '../inventarios.module';
import { LANGUAGE_DATATABLE } from 'src/app/admin/datatable.language';

@Component({
  selector: 'app-inventarios-index',
  standalone: false,
  templateUrl: './inventarios-index.component.html',
  styleUrl: './inventarios-index.component.css'
})
export class InventariosIndexComponent implements OnInit {

  title = "Listado de inventarios";
  botones: String[] = ['btn-nuevo'];
  breadcrumb!: any[];
  listInventarios = signal<Inventario[]>([]);

  constructor(
    private service: GeneralParameterService,
    private helperService: HelperService
  ) {
    this.breadcrumb = [{ name: `Inicio`, icon: `fa-duotone fa-house` }, { name: "Inventario", icon: "fa-duotone fa-boxes-stacked" }, { name: "Inventarios", icon: "fa-duotone fa-cart-flatbed-boxes" }];
  }

  ngOnInit(): void {
    this.cargarLista();
  }

  cargarLista() {
    this.getData()
    .then((datos) => {
      datos.data.forEach((item: any) => {
        this.listInventarios.update(listInventarios => {
          const Inventario: Inventario = {
            id: item.id,
            activo: item.activo,
            codigo: item.codigo,
            nombre: item.nombre,
            observacion: item.observacion,
          };

          return [...listInventarios, Inventario];
        });
      });

      setTimeout(() => {
        $("#datatable").DataTable({
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
      this.service.datatable("Inventario", data).subscribe(
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
    this.listInventarios = signal<Inventario[]>([]);
    this.cargarLista();
  }

  nuevo() {
    this.helperService.redirectApp("/dashboard/inventario/inventarios/crear");
  }

  update(id: any) {
    this.helperService.redirectApp(`/dashboard/inventario/inventarios/editar/${id}`);

  }

  deleteGeneric(id: any) {
    this.helperService.confirmDelete(() => {
      this.service.delete("Inventario", id).subscribe(
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
    InventariosIndexComponent,
  ],
  imports: [
    CommonModule,
    GeneralModule,
  ]
})
export class InventariosIndexModule { }