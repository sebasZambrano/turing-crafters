import { Component, NgModule, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { ActivatedRoute } from '@angular/router';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { HelperService } from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../../generic/general.service';

@Component({
  selector: 'app-detalles-inventarios-bodegas-index',
  standalone: false,
  templateUrl: './detalles-inventarios-bodegas-index.component.html',
  styleUrl: './detalles-inventarios-bodegas-index.component.css'
})
export class DetallesInventariosBodegasIndexComponent implements OnInit {
  botones = ['btn-guardar'];
  detallesInventariosBodegas: any[] = [];
  listdetallesInventariosBodegas = signal<any[]>([]);
  cantidadFacturar = 0;
  BodegaId = 0;
  title = "Cantidad total a facturar:";
  facturaCompra: boolean = false;
  inventarioDetalle: boolean = false;

  constructor(
    public routerActive: ActivatedRoute,
    private service: GeneralParameterService,
    private helperService: HelperService,
    private modalActive: NgbActiveModal
  ) {
  }

  ngOnInit(): void {
    this.BodegaId = Number(localStorage.getItem('BodegaId'));
    if (this.detallesInventariosBodegas.length > 0) {
      if (this.detallesInventariosBodegas[0].id != 0) {
        this.cargarListaFactura();
      } else {
        if (this.inventarioDetalle) {
          this.title = "Cantidad total para asignar:";
        }else{
          this.facturaCompra = true;
          this.cargarListaFacturaCompra();
        }
      }
    } else {
      this.modalActive.close([]);
    }
  }

  cargarListaFactura() {
    this.detallesInventariosBodegas.forEach((item: any) => {
      this.listdetallesInventariosBodegas.update(listdetallesInventariosBodegas => {
        const DetalleInventarioBodega = {
          id: item.id,
          activo: item.activo,
          cantidad: item.cantidad,
          bodegaId: item.bodegaId,
          bodega: item.bodega,
          inventarioDetalleId: item.inventarioDetalleId,
          inventarioDetalle: item.inventarioDetalle,
          cantidadFacturar: item.cantidadFacturar,
          insumo: item.insumo,
          alerta: item.alerta
        };
        return [...listdetallesInventariosBodegas, DetalleInventarioBodega];
      });
    })
  }

  cargarListaFacturaCompra() {
    this.detallesInventariosBodegas.forEach((item: any) => {
      this.listdetallesInventariosBodegas.update(listdetallesInventariosBodegas => {
        const DetalleInventarioBodega = {
          id: item.id,
          activo: true,
          cantidad: 10000000000000000000000000000000000000000000000000000000000000000000,
          bodegaId: item.bodegaId,
          bodega: item.bodega,
          inventarioDetalleId: item.inventarioDetalleId,
          inventarioDetalle: "",
          cantidadFacturar: item.cantidadFacturar,
          insumo: item.insumo,
          alerta: false
        };

        return [...listdetallesInventariosBodegas, DetalleInventarioBodega];
      });
    })
  }

  save() {
    this.modalActive.close(this.listdetallesInventariosBodegas());
  }

  changeCantidad(event: any, index: number) {
    var inputCantidad = event.target as HTMLInputElement;
    if (inputCantidad.value != '') {
      var nuevaCantidad = Number(inputCantidad.value);
      this.listdetallesInventariosBodegas.update((listdetallesInventariosBodegas) => {
        return listdetallesInventariosBodegas.map((listdetallesInventariosBodegas, position) => {
          if (position === index) {
            return {
              ...listdetallesInventariosBodegas,
              cantidadFacturar: nuevaCantidad
            }
          }
          return listdetallesInventariosBodegas;
        })
      });

      if (this.listdetallesInventariosBodegas()[index].cantidadFacturar > this.listdetallesInventariosBodegas()[index].cantidad) {
        this.listdetallesInventariosBodegas()[index].alerta = true;
      } else {
        this.listdetallesInventariosBodegas()[index].alerta = false;
      }
    }
  }
}

@NgModule({
  declarations: [
    DetallesInventariosBodegasIndexComponent,
  ],
  imports: [
    CommonModule,
    GeneralModule
  ]
})
export class DetallesInventariosBodegasIndexModule { }