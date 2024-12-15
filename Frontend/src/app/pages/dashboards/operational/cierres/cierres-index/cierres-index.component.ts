import { Component, OnInit, NgModule, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { HelperService } from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../../generic/general.service';
import { DatatableParameter } from '../../../../../admin/datatable.parameters';
import { Cierre } from '../cierres.module';
import { LANGUAGE_DATATABLE } from 'src/app/admin/datatable.language';


@Component({
  selector: 'app-cierres-index',
  standalone: false,
  templateUrl: './cierres-index.component.html',
  styleUrl: './cierres-index.component.css'
})
export class CierresIndexComponent implements OnInit {
  title = "Listado de Cierres";
  breadcrumb!: any[];
  botones: String[] = ['btn-nuevo'];
  listCierres = signal<Cierre[]>([]);

  constructor(
    private service: GeneralParameterService,
    public helperService: HelperService
  ) {
    this.breadcrumb = [{ name: `Inicio`, icon: `fa-duotone fa-house` }, { name: "Operativo", icon: "fa-duotone fa-shop" }, { name: "Cierres", icon: "fa-duotone fa-shop-lock" }];
  }

  ngOnInit(): void {
    this.cargarLista();
  }

  cargarLista() {
    this.getData()
      .then((datos) => {
        datos.data.forEach((item: any) => {
          this.listCierres.update(listCierres => {
            const Cierre: Cierre = {
              id: item.id,
              activo: item.activo,
              fechaInicial: item.fechaInicial,
              fechaFinal: item.fechaFinal,
              totalIngreso: item.totalIngreso,
              totalEgreso: item.totalEgreso,
              saldoCaja: item.saldoCaja,
              saldoEmpleado: item.saldoEmpleado,
              base: item.base,
              observacion: item.observacion,
              empleadoId: item.empleadoId,
              empleado: item.empleado,
            };

            return [...listCierres, Cierre];
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
      this.service.datatable("Cierre", data).subscribe(
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
    this.listCierres = signal<Cierre[]>([]);
    this.cargarLista();
  }

  nuevo() {
    this.helperService.redirectApp("/dashboard/operativo/cierres/crear");
  }

  imprimir(id: any) {
    this.helperService.showLoading();
    this.service.GetArchivo("Cierre", id).subscribe((res) => {
      this.openPdfInNewTab(res.data.content);
    });
  }

  openPdfInNewTab(pdfContent: string) {
    const byteCharacters = atob(pdfContent);
    const byteNumbers = new Array(byteCharacters.length);
    for (let i = 0; i < byteCharacters.length; i++) {
      byteNumbers[i] = byteCharacters.charCodeAt(i);
    }
    const byteArray = new Uint8Array(byteNumbers);
    const blob = new Blob([byteArray], { type: 'application/pdf' });
    const objectUrl = URL.createObjectURL(blob);

    setTimeout(() => {
      this.helperService.hideLoading();
    }, 200);

    const newWindow = window.open(objectUrl, '_blank');

    if (newWindow) {
      newWindow.document.title = 'Cierre';
      newWindow.print();
    }

    setTimeout(() => {
      location.reload();
    }, 500);
  }
}
@NgModule({
  declarations: [
    CierresIndexComponent,
  ],
  imports: [
    CommonModule,
    GeneralModule,
  ]
})
export class CierresIndexModule { }