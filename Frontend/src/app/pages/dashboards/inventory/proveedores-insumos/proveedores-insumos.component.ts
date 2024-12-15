import { Component, Input, OnInit, signal, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { LANGUAGE_DATATABLE } from 'src/app/admin/datatable.language';
import { DatatableParameter } from 'src/app/admin/datatable.parameters';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../generic/general.service';
import { DataAutoCompleteDto } from '../../../../generic/dataAutoCompleteDto';
import { InsumoProveedor } from './proveedores-insumos.module';
import { AutocompleteLibModule } from 'angular-ng-autocomplete';

@Component({
  selector: 'app-proveedores-insumos',
  standalone: false,
  templateUrl: './proveedores-insumos.component.html',
  styleUrl: './proveedores-insumos.component.css'
})
export class ProveedoresInsumosComponent implements OnInit {
  @ViewChild('auto') auto: any;
  keyword = 'name';
  isLoading: boolean = false;
  botones = ['btn-guardar'];
  @Input() ProveedorId: any = null;
  frmProveedoresInsumos: FormGroup;
  statusForm: boolean = true;
  listInsumos = signal<DataAutoCompleteDto[]>([]);
  listProveedoresInsumos = signal<InsumoProveedor[]>([]);

  constructor(
    private helperService: HelperService,
    private service: GeneralParameterService
  ) {
    this.frmProveedoresInsumos = new FormGroup({
      Id: new FormControl(0, Validators.required),
      ProveedorId: new FormControl(this.ProveedorId, Validators.required),
      InsumoId: new FormControl(null, Validators.required),
      Activo: new FormControl(true, Validators.required),
    });
  }

  ngOnInit(): void {
    this.cargarLista();
    this.cargarInsumos();
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

  cargarLista() {
    this.getData()
      .then((datos) => {
        datos.data.forEach((item: any) => {
          this.listProveedoresInsumos.update(listProveedoresInsumos => {
            const InsumoProveedor: InsumoProveedor = {
              id: item.id,
              activo: item.activo,
              proveedorId: item.proveedorId,
              proveedor: item.proveedor,
              insumoId: item.insumoId,
              insumo: item.insumo,
            };

            return [...listProveedoresInsumos, InsumoProveedor];
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
    var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = this.ProveedorId; data.nameForeignKey = "ProveedorId";
    return new Promise((resolve, reject) => {
      this.service.datatableKey("InsumoProveedor", data).subscribe(
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
    this.listProveedoresInsumos = signal<InsumoProveedor[]>([]);
    this.cargarLista();
  }

  save() {
    this.frmProveedoresInsumos.controls['ProveedorId'].setValue(this.ProveedorId);
    if (this.frmProveedoresInsumos.invalid) {
      this.statusForm = false;
      this.helperService.showMessage(MessageType.WARNING, Messages.EMPTYFIELD);
      return;
    }
    let data = this.frmProveedoresInsumos.value;
    this.service.save("InsumoProveedor", this.frmProveedoresInsumos.controls['Id'].value, data).subscribe(
      (response) => {
        if (response.status) {
          this.refrescarTabla();
          this.frmProveedoresInsumos.reset();
          this.frmProveedoresInsumos.controls['Id'].setValue(0);
          this.frmProveedoresInsumos.controls['ProveedorId'].setValue(this.ProveedorId);
          this.frmProveedoresInsumos.controls['Activo'].setValue(true);
          this.frmProveedoresInsumos.controls['InsumoId'].setValue(null);
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
    this.frmProveedoresInsumos.controls['Id'].setValue(item.id);
    this.frmProveedoresInsumos.controls['InsumoId'].setValue(item.insumoId);
    this.frmProveedoresInsumos.controls['Activo'].setValue(item.activo);
  }

  deleteGeneric(id: any) {
    this.helperService.confirmDelete(() => {
      this.service.delete("ProveedorId", id).subscribe(
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

  // Events Autocomplete

  selectEvent(item: any) {
    this.frmProveedoresInsumos.controls["InsumoId"].setValue(item.id);
  }

  onFocused() {
    this.auto.close();
  }

  onCleared() {
    this.auto.clear();
    this.auto.close();
    this.frmProveedoresInsumos.controls["InsumoId"].setValue(null);
  }

  inputCleared() {
    this.auto.close();
    this.listInsumos = signal<DataAutoCompleteDto[]>([]);
    this.cargarInsumos();
  }
}
