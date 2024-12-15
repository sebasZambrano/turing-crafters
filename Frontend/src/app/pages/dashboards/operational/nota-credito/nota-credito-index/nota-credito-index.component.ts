import { Component, OnInit, NgModule, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../../generic/general.service';
import { DatatableParameter } from '../../../../../admin/datatable.parameters';
import { NotaCredito } from '../nota-credito.module';
import { LANGUAGE_DATATABLE } from 'src/app/admin/datatable.language';

@Component({
  selector: 'app-nota-credito-index',
  standalone: false,
  templateUrl: './nota-credito-index.component.html',
  styleUrl: './nota-credito-index.component.css'
})
export class NotasCreditosIndexComponent implements OnInit {
  title = "Listado Notas Créditos";
  breadcrumb!: any[];
  listNotasCreditos = signal<NotaCredito[]>([]);

  constructor(
    private service: GeneralParameterService,
    public helperService: HelperService
  ) {
    this.breadcrumb = [{ name: `Inicio`, icon: `fa-duotone fa-house` }, { name: "Operativo", icon: "fa-duotone fa-shop" }, { name: "Nota Crédito", icon: "fa-duotone fa-file-circle-exclamation" }];
  }

  ngOnInit(): void {
    this.cargarLista();
  }

  cargarLista() {
    this.getData()
      .then((datos) => {
        datos.data.forEach((item: any) => {
          this.listNotasCreditos.update(listNotasCreditos => {
            const NotaCredito: NotaCredito = {
              id: item.id,
              activo: item.activo,
              codigo: item.codigo,
              concepto: item.concepto,
              metodoCredito: item.metodoCredito,
              total: item.total,
              pagoCaja: item.pagoCaja,
              motivoId: item.motivoId,
              estadoId: item.estadoId,
              facturaId: item.facturaId,
              empleadoId: item.empleadoId,
              medioPagoId: item.medioPagoId,
              motivo: item.motivo,
              estado: item.estado,
              factura: item.factura,
              empleado: item.empleado,
              medioPago: item.medioPago,
              createAt: item.createAt,
            };

            return [...listNotasCreditos, NotaCredito];
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
      this.service.datatable("NotaCredito", data).subscribe(
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
    this.listNotasCreditos = signal<NotaCredito[]>([]);
    this.cargarLista();
  }

  aprobar(id: any) {
    this.helperService.redirectApp(`/dashboard/operativo/notas-credito/aprobar/${id}`);
  }
}
@NgModule({
  declarations: [
    NotasCreditosIndexComponent,
  ],
  imports: [
    CommonModule,
    GeneralModule,
  ]
})
export class NotasCreditosIndexModule { }