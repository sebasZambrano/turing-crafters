import { Component, Input, OnInit, signal, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { LANGUAGE_DATATABLE } from 'src/app/admin/datatable.language';
import { DatatableParameter } from 'src/app/admin/datatable.parameters';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../generic/general.service';
import { DataSelectDto } from '../../../../generic/dataSelectDto';
import { DataAutoCompleteDto } from '../../../../generic/dataAutoCompleteDto';
import { ProductoInsumo } from './productos-insumos.module';
import { AutocompleteLibModule } from 'angular-ng-autocomplete';

@Component({
  selector: 'app-productos-insumos',
  standalone: false,
  templateUrl: './productos-insumos.component.html',
  styleUrl: './productos-insumos.component.css'
})
export class ProductosInsumosComponent implements OnInit {
  @ViewChild('auto') auto: any;
  keyword = 'name';
  isLoading: boolean = false;
  botones = ['btn-guardar'];
  @Input() ProductoId: any = null;
  frmProductoInsumo: FormGroup;
  statusForm: boolean = true;
  listInsumos = signal<DataAutoCompleteDto[]>([]);
  listUnidadMedida = signal<DataSelectDto[]>([]);
  listProductosInsumos = signal<ProductoInsumo[]>([]);

  constructor(
    private helperService: HelperService,
    private service: GeneralParameterService
  ) {
    this.frmProductoInsumo = new FormGroup({
      Id: new FormControl(0, Validators.required),
      Cantidad: new FormControl(1, Validators.required),
      ProductoId: new FormControl(this.ProductoId, Validators.required),
      InsumoId: new FormControl(null, Validators.required),
      UnidadMedidaId: new FormControl(null, Validators.required),
      Activo: new FormControl(true, Validators.required),
      Adicional: new FormControl(false, Validators.required),
    });
  }

  ngOnInit(): void {
    this.cargarListas();
    this.cargarDataTable();
  }

  cargarListas() {
    this.cargarInsumos();
    this.cargarUnidadMedida();
  }

  cargarInsumos() {
    this.isLoading = true;
    this.service.getAll('Insumo').subscribe((res) => {
      res.data.forEach((item: any) => {
        this.listInsumos.update(listInsumos => {
          const DataAutoCompleteDto: DataAutoCompleteDto = {
            id: item.id,
            name: `${item.codigo} - ${item.nombre}`,
          };

          return [...listInsumos, DataAutoCompleteDto];
        });
      });
      this.isLoading = false;
    });
  }

  cargarUnidadMedida() {
    this.service.getAll('UnidadMedida').subscribe((res) => {
      res.data.forEach((item: any) => {
        this.listUnidadMedida.update(listUnidadMedida => {
          const DataSelectDto: DataSelectDto = {
            id: item.id,
            textoMostrar: `${item.codigo} - ${item.nombre}`,
            activo: item.activo
          };

          return [...listUnidadMedida, DataSelectDto];
        });
        if(item.codigo == "U"){
          this.frmProductoInsumo.controls["UnidadMedidaId"].setValue(item.id);
        }
      });
    });
  }

  getData(): Promise<any> {
    var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = this.ProductoId; data.nameForeignKey = "ProductoId";
    return new Promise((resolve, reject) => {
      this.service.datatableKey("InsumoProducto", data).subscribe(
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
    this.listProductosInsumos = signal<ProductoInsumo[]>([]);
    this.cargarDataTable();
  }

  cargarDataTable() {
    this.getData()
      .then((datos) => {
        datos.data.forEach((item: any) => {
          this.listProductosInsumos.update(listProductosInsumos => {
            const ProductoInsumo: ProductoInsumo = {
              id: item.id,
              activo: item.activo,
              cantidad: item.cantidad,
              adicional: item.adicional,
              productoId: item.productoId,
              producto: item.producto,
              insumoId: item.insumoId,
              insumo: item.insumo,
              unidadMedidaId: item.unidadMedidaId,
              unidadMedida: item.unidadMedida
            };

            return [...listProductosInsumos, ProductoInsumo];
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

  save() {
    this.frmProductoInsumo.controls['ProductoId'].setValue(this.ProductoId);
    if (this.frmProductoInsumo.invalid) {
      this.statusForm = false;
      this.helperService.showMessage(MessageType.WARNING, Messages.EMPTYFIELD);
      return;
    }
    let data = this.frmProductoInsumo.value;
    this.service.save("InsumoProducto", this.frmProductoInsumo.controls['Id'].value, data).subscribe(
      (response) => {
        if (response.status) {
          this.refrescarTabla();
          this.frmProductoInsumo.reset();
          this.frmProductoInsumo.controls['Id'].setValue(0);
          this.frmProductoInsumo.controls['Cantidad'].setValue(0);
          this.frmProductoInsumo.controls['InsumoId'].setValue(null);
          this.frmProductoInsumo.controls['ProductoId'].setValue(this.ProductoId);
          this.frmProductoInsumo.controls['Activo'].setValue(true);
          this.frmProductoInsumo.controls['Adicional'].setValue(false);
          this.helperService.showMessage(
            MessageType.SUCCESS,
            Messages.SAVESUCCESS
          );
        }
      },
      (error) => {
        this.helperService.showMessage(
          MessageType.WARNING,
          error.error.message
        );
      }
    );
  }

  update(item: any) {
    this.frmProductoInsumo.controls['Id'].setValue(item.id);
    this.frmProductoInsumo.controls['Cantidad'].setValue(item.cantidad);
    this.frmProductoInsumo.controls['InsumoId'].setValue(item.insumoId);
    this.frmProductoInsumo.controls['UnidadMedidaId'].setValue(item.unidadMedidaId);
    this.frmProductoInsumo.controls['Adicional'].setValue(item.adicional);
    this.frmProductoInsumo.controls['Activo'].setValue(item.activo);
  }

  deleteGeneric(id: any) {
    this.helperService.confirmDelete(() => {
      this.service.delete("InsumoProducto", id).subscribe(
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

  onChangeInsumo(event: any) {
    if (typeof event != "undefined") {
      this.service.getById("Insumo", event.id).subscribe((insumo) => {
        this.frmProductoInsumo.controls['UnidadMedidaId'].setValue(insumo.data.unidadMedidaId);
      })
    } else {
      this.frmProductoInsumo.controls['UnidadMedidaId'].setValue(null);
    }
  }

  // Events Autocomplete

  selectEvent(item: any) {
    this.frmProductoInsumo.controls["InsumoId"].setValue(item.id);
  }

  onFocused() {
    this.auto.close();
  }

  onCleared() {
    this.auto.clear();
    this.auto.close();
    this.frmProductoInsumo.controls["InsumoId"].setValue(null);
  }

  inputCleared() {
    this.auto.close();
    this.listInsumos = signal<DataAutoCompleteDto[]>([]);
    this.cargarInsumos();
  }
}
