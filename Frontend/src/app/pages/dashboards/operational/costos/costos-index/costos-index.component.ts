import { Component, OnInit, NgModule, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../../generic/general.service';
import { DatatableParameter } from '../../../../../admin/datatable.parameters';
import { Costo } from '../costos.module';
import { LANGUAGE_DATATABLE } from 'src/app/admin/datatable.language';

@Component({
  selector: 'app-costos-index',
  standalone: false,
  templateUrl: './costos-index.component.html',
  styleUrl: './costos-index.component.css'
})
export class CostosIndexComponent implements OnInit {
  title = "Listado de Costos & Gastos";
  breadcrumb!: any[];
  botones: String[] = ['btn-nuevo'];
  listCostos = signal<Costo[]>([]);

  constructor(
    private service: GeneralParameterService,
    public helperService: HelperService
  ) {
    this.breadcrumb = [{ name: `Inicio`, icon: `fa-duotone fa-house` }, { name: "Operativo", icon: "fa-duotone fa-shop" }, { name: "Costos", icon: "fa-duotone fa-dollar-sign" }];
  }

  ngOnInit(): void {
    this.cargarLista();
  }

  cargarLista() {
    this.getData()
      .then((datos) => {
        datos.data.forEach((item: any) => {
          this.listCostos.update(listCostos => {
            const Costo: Costo = {
              id: item.id,
              activo: item.activo,
              descripcion: item.descripcion,
              fechaCosto: item.fechaCosto,
              valor: item.valor,
              pagoCaja: item.pagoCaja,
              numeroFactura: item.numeroFactura,
              tipoCostoId: item.tipoCostoId,
              tipoCosto: item.tipoCosto,
              empleadoId: item.empleadoId,
              empleado: item.empleado,
              proveedorId: item.proveedorId,
              proveedor: item.proveedor,
              cajaId: item.cajaId,
              caja: item.caja,
            };

            return [...listCostos, Costo];
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
      this.service.datatable("Costo", data).subscribe(
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
    this.listCostos = signal<Costo[]>([]);
    this.cargarLista();
  }

  nuevo() {
    this.helperService.redirectApp("/dashboard/operativo/costos/crear");
  }

  update(id: any) {
    this.helperService.redirectApp(`/dashboard/operativo/costos/editar/${id}`);
  }

  deleteGeneric(id: any) {
    this.helperService.confirmDelete(() => {
      this.service.delete("Costo", id).subscribe(
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
    CostosIndexComponent,
  ],
  imports: [
    CommonModule,
    GeneralModule,
  ]
})
export class CostosIndexModule { }