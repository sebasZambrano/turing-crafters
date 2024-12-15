import { Component, Input, OnInit, NgModule, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { GeneralParameterService } from '../../../../generic/general.service';
import { DatatableParameter } from '../../../../admin/datatable.parameters';
import { BitacoraInventario } from './bitacoras-inventarios.module';
import { LANGUAGE_DATATABLE } from 'src/app/admin/datatable.language';

@Component({
  selector: 'app-bitacoras-inventarios',
  standalone: false,
  templateUrl: './bitacoras-inventarios.component.html',
  styleUrl: './bitacoras-inventarios.component.css'
})
export class BitacorasInventariosComponent implements OnInit {
  @Input() InsumoId: any = null;
  inventarioBodega = false;
  facturas = false;
  botones: String[] = ['btn-cancelar'];
  listMovimientosInventarios = signal<BitacoraInventario[]>([]);

  constructor(
    private service: GeneralParameterService,
    private modalActive: NgbActiveModal,
  ) {

  }

  ngOnInit(): void {
    this.cargarLista();
  }

  getData(): Promise<any> {
    var entity = "BitacoraInventario"
    var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = this.InsumoId; data.nameForeignKey = "InsumoId";
    if(this.inventarioBodega){
      entity = "BitacoraInventarioBodega";
      data.nameForeignKey = "DetalleInventarioBodegaId";
    }else if(this.facturas){
      entity = "BitacoraFactura";
      data.nameForeignKey = "FacturaId";
    }
    return new Promise((resolve, reject) => {
      this.service.datatableKey(entity, data).subscribe(
        (datos) => {
          resolve(datos);
        },
        (error) => {
          reject(error);
        }
      )
    });
  }

  cargarLista() {
    this.getData().then((datos) => {
      datos.data.forEach((item: any) => {
        this.listMovimientosInventarios.update(listMovimientosInventarios => {
          const BitacoraInventario: BitacoraInventario = {
            id: item.id,
            codigo: item.codigo,
            nombre: item.nombre,
            activo: item.activo,
            cantidad: item.cantidad,
            createAt: item.createAt,
            observacion: item.observacion,
            empleadoId: item.empleadoId,
            empleado: item.empleado,
            insumoId: item.insumoId,
            insumo: item.insumo,
          };

          return [...listMovimientosInventarios, BitacoraInventario];
        });
      });

      setTimeout(() => {
        $("#datatableDetalles").DataTable({
          dom: 'Blfrtip',
          destroy: true,
          pageLength: 3,
          lengthMenu: [ 3, 10, 25, 50, 75, 100 ],
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
    BitacorasInventariosComponent,
  ],
  imports: [
    CommonModule,
    GeneralModule,
  ]
})
export class BitacorasInventariosModule { }