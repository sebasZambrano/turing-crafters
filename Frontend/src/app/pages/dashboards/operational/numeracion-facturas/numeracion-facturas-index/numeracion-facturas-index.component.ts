import { Component, OnInit, NgModule, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { HelperService } from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../../generic/general.service';
import { DatatableParameter } from '../../../../../admin/datatable.parameters';
import { NumeracionFacturas } from '../mumeracion-facturas.module';
import { LANGUAGE_DATATABLE } from 'src/app/admin/datatable.language';

@Component({
  selector: 'app-numeracion-facturas-index',
  standalone: false,
  templateUrl: './numeracion-facturas-index.component.html',
  styleUrl: './numeracion-facturas-index.component.css',
})
export class NumeracionFacturasIndexComponent implements OnInit {
  title = 'Listado de Numeraciones';
  breadcrumb!: any[];
  botones: String[] = ['btn-nuevo'];
  lstNumeracion = signal<NumeracionFacturas[]>([]);

  constructor(
    private service: GeneralParameterService,
    public helperService: HelperService
  ) {
    this.breadcrumb = [
      { name: `Inicio`, icon: `fa-duotone fa-house` },
      { name: 'Operativo', icon: 'fa-duotone fa-shop' },
      { name: 'Numeraciones de Facturas', icon: 'fa-duotone fa-sliders' },
    ];
  }

  ngOnInit(): void {
    this.cargarLista();
  }

  cargarLista() {
    this.getData()
      .then((datos) => {
        datos.data.forEach((item: any) => {
          this.lstNumeracion.update((lstNumeracion) => {
            const NumeracionFacturas: NumeracionFacturas = {
              id: item.id,
              codigo: item.codigo,
              nombre: item.nombre,
              activo: item.activo,
              prefijo: item.prefijo,
              numInicial: item.numInicial,
              numFinal: item.numFinal,
              numActual: item.numActual,
              resolucion: item.resolucion,
              autorizacion: item.autorizacion,
            };

            return [...lstNumeracion, NumeracionFacturas];
          });
        });

        setTimeout(() => {
          $('#datatable').DataTable({
            dom: 'Blfrtip',
            destroy: true,
            language: LANGUAGE_DATATABLE,
            processing: true,
          });
        }, 200);
      })
      .catch((error) => {
        console.error('Error al obtener los datos:', error);
      });
  }

  getData(): Promise<any> {
    var data = new DatatableParameter();
    data.pageNumber = '';
    data.pageSize = '';
    data.filter = '';
    data.columnOrder = '';
    data.directionOrder = '';
    return new Promise((resolve, reject) => {
      this.service.datatable('NumeracionFactura', data).subscribe(
        (datos) => {
          resolve(datos);
        },
        (error) => {
          reject(error);
        }
      );
    });
  }

  refrescarTabla() {
    $('#datatable').DataTable().destroy();
    this.lstNumeracion = signal<NumeracionFacturas[]>([]);
    this.cargarLista();
  }

  nuevo() {
    this.helperService.redirectApp('/dashboard/operativo/numeracion-facturas/crear');
  }

  update(id: any) {
    this.helperService.redirectApp(
      `/dashboard/operativo/numeracion-facturas/editar/${id}`
    );
  }
}
@NgModule({
  declarations: [NumeracionFacturasIndexComponent],
  imports: [CommonModule, GeneralModule],
})
export class NumeracionIndexModule {}
