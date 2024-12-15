import { Component, Input, OnInit, NgModule, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { GeneralParameterService } from '../../../../generic/general.service';
import { DatatableParameter } from '../../../../admin/datatable.parameters';
import { FacturaDetalle } from './facturas-detalles.module';
import { LANGUAGE_DATATABLE } from 'src/app/admin/datatable.language';
import { HelperService } from 'src/app/admin/helper.service';

@Component({
  selector: 'app-facturas-detalles',
  standalone: false,
  templateUrl: './facturas-detalles.component.html',
  styleUrl: './facturas-detalles.component.css'
})
export class FacturasDetallesComponent implements OnInit {
  @Input() FacturaId: any = null;
  botones: String[] = ['btn-cancelar'];
  listFacturaDetalles = signal<FacturaDetalle[]>([]);

  constructor(
    private service: GeneralParameterService,
    public helperService: HelperService,
    private modalActive: NgbActiveModal,
  ) {

  }

  ngOnInit(): void {
    this.cargarLista();
  }

  getData(): Promise<any> {
    var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = this.FacturaId; data.nameForeignKey = "FacturaId";
    return new Promise((resolve, reject) => {
      this.service.datatableKey("FacturaDetalle", data).subscribe(
        (datos) => {
          resolve(datos);
        },
        (error) => {
          reject(error);
        }
      );
    });
  }

  cargarLista() {
    this.getData().then((datos) => {
      datos.data.forEach((item: any) => {
        this.listFacturaDetalles.update(listFacturaDetalles => {
          const FacturaDetalle: FacturaDetalle = {
            id: item.id,
            activo: item.activo,
            codigo: item.codigo,
            cantidad: item.cantidad,
            subTotal: item.subTotal,
            precioProducto: item.precioProducto,
            descuento: item.descuento,
            iva: item.iva,
            facturaId: item.facturaId,
            factura: item.factura,
            productoId: item.productoId,
            producto: item.producto,
          };

          return [...listFacturaDetalles, FacturaDetalle];
        });
      });

      setTimeout(() => {
        $("#datatableDetalles").DataTable({
          dom: 'Blfrtip',
          destroy: true,
          pageLength: 3,
          lengthMenu: [3, 10, 25, 50, 75, 100],
          language: LANGUAGE_DATATABLE,
          processing: true,
        });
      }, 200);
    })
      .catch((error) => {
        console.error('Error al obtener los datos:', error);
      });
  }

  cancel() {
    this.modalActive.close(null);
  }
}
@NgModule({
  declarations: [
    FacturasDetallesComponent,
  ],
  imports: [
    CommonModule,
    GeneralModule,
  ]
})
export class FacturasDetallesModule { }