import { Component, OnInit, NgModule, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../../generic/general.service';
import { DatatableParameter } from '../../../../../admin/datatable.parameters';
import { FacturaCompra } from '../facturas-compras.module';
import { LANGUAGE_DATATABLE } from 'src/app/admin/datatable.language';

@Component({
  selector: 'app-facturas-compras-index',
  standalone: false,
  templateUrl: './facturas-compras-index.component.html',
  styleUrl: './facturas-compras-index.component.css'
})
export class FacturasComprasIndexComponent implements OnInit {
  title = "Listado de Facturas de Compra";
  breadcrumb!: any[];
  botones: String[] = ['btn-nuevo'];
  listFacturasCompras = signal<FacturaCompra[]>([]);

  constructor(
    private service: GeneralParameterService,
    public helperService: HelperService
  ) {
    this.breadcrumb = [{ name: `Inicio`, icon: `fa-duotone fa-house` }, { name: "Operativo", icon: "fa-duotone fa-shop" }, { name: "Facturas de Compra", icon: "fa-duotone fa-file-invoice-dollar" }];
  }

  ngOnInit(): void {
    this.cargarLista();
  }

  cargarLista() {
    this.getData().then((datos) => {
      datos.data.forEach((item: any) => {
        this.listFacturasCompras.update(listFacturasCompras => {
          const FacturaCompra: FacturaCompra = {
            id: item.id,
            activo: item.activo,
            numeroFactura: item.numeroFactura,
            fecha: item.fecha,
            total: item.total,
            descuento: item.descuento,
            iva: item.iva,
            proveedorId: item.proveedorId,
            proveedor: item.proveedor,
            estadoId: item.estadoId,
            estado: item.estado,
            empleadoId: item.empleadoId,
            empleado: item.empleado,
          };

          return [...listFacturasCompras, FacturaCompra];
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
      this.service.datatable("FacturaCompra", data).subscribe(
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
    this.listFacturasCompras = signal<FacturaCompra[]>([]);
    this.cargarLista();
  }

  nuevo() {
    this.helperService.redirectApp("/dashboard/operativo/facturas-compras/crear");
  }

  update(id: any) {
    this.helperService.redirectApp(`/dashboard/operativo/facturas-compras/editar/${id}`);
  }

  deleteGeneric(id: any) {
    this.helperService.confirmDelete(() => {
      this.service.delete("FacturaCompra", id).subscribe(
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
    FacturasComprasIndexComponent,
  ],
  imports: [
    CommonModule,
    GeneralModule,
  ]
})
export class FacturasComprasIndexModule { }