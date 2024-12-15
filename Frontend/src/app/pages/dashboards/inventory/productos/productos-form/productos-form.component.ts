import { Component, NgModule, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { DatatableParameter } from '../../../../../admin/datatable.parameters';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../../generic/general.service';
import { DataSelectDto } from '../../../../../generic/dataSelectDto';
import { NgbNavModule } from '@ng-bootstrap/ng-bootstrap';
import { ProductosInsumosComponent } from '../../productos-insumos/productos-insumos.component';
import { AutocompleteLibModule } from 'angular-ng-autocomplete';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-productos-form',
  standalone: false,
  templateUrl: './productos-form.component.html',
  styleUrl: './productos-form.component.css'
})
export class ProductosFormComponent implements OnInit {
  img = '../../../../assets/no-photo.jpg';
  dataArchivo: any = undefined;
  frmProductos: FormGroup;
  statusForm: boolean = true;
  id!: number;
  botones = ['btn-guardar', 'btn-cancelar'];
  title = 'Crear Producto';
  listCategorias = signal<DataSelectDto[]>([]);
  breadcrumb = [{ name: `Inicio`, icon: `fa-duotone fa-house` }, { name: "Inventario", icon: "fa-duotone fa-boxes-stacked" }, { name: 'Productos', icon: "fa-duotone fa-shirt" }, { name: 'Crear', icon: "fa-duotone fa-octagon-plus" }];

  constructor(
    public routerActive: ActivatedRoute,
    private service: GeneralParameterService,
    private helperService: HelperService,
  ) {
    this.frmProductos = new FormGroup({
      Codigo: new FormControl(""),
      Nombre: new FormControl(null, [Validators.required, Validators.maxLength(100)]),
      DescripcionCorta: new FormControl("", [Validators.required, Validators.maxLength(100)]),
      DescripcionLarga: new FormControl("", [Validators.required, Validators.maxLength(100)]),
      Precio: new FormControl(0, Validators.required),
      PrecioCosto: new FormControl(0, Validators.required),
      Descuento: new FormControl(0),
      Iva: new FormControl(0),
      CategoriaId: new FormControl(null, Validators.required),
      EmpleadoId: new FormControl(null, Validators.required),
      Activo: new FormControl(true, Validators.required),
      Insumo: new FormControl(true, Validators.required)
    });
    this.routerActive.params.subscribe((l) => (this.id = l['id']));
  }

  ngOnInit(): void {
    if (this.id != undefined && this.id != null) {
      this.title = 'Editar Producto';
      this.breadcrumb = [{ name: `Inicio`, icon: `fa-duotone fa-house` }, { name: "Inventario", icon: "fa-duotone fa-boxes-stacked" }, { name: 'Productos', icon: "fa-duotone fa-shirt" }, { name: 'Editar', icon: "fa-duotone fa-pen-to-square" }];
      this.service.getById("Producto", this.id).subscribe((l) => {
        this.frmProductos.controls['Codigo'].setValue(l.data.codigo);
        this.frmProductos.controls['Nombre'].setValue(l.data.nombre);
        this.frmProductos.controls['DescripcionCorta'].setValue(l.data.descripcionCorta);
        this.frmProductos.controls['DescripcionLarga'].setValue(l.data.descripcionLarga);
        this.frmProductos.controls['Precio'].setValue(l.data.precio);
        this.frmProductos.controls['PrecioCosto'].setValue(l.data.precioCosto);
        this.frmProductos.controls['Descuento'].setValue(l.data.descuento);
        this.frmProductos.controls['Iva'].setValue(l.data.iva);
        this.frmProductos.controls['CategoriaId'].setValue(l.data.categoriaId);
        this.frmProductos.controls['Activo'].setValue(l.data.activo);
        this.frmProductos.controls['Insumo'].setValue(false);

        //Consulto el archivo
        var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = this.id; data.nameForeignKey = "TablaId";
        this.service.datatableKey("Archivo", data).subscribe((response) => {
          if (response.data.length > 0) {
            response.data.forEach((item: any) => {
              if (item.tabla == "Producto") {
                this.img = item.content;
              }
            });
          }
        });
      });
    }

    this.cargarCategorias();
    this.validarEmpleado();
  }

  validarEmpleado() {
    var personaId = localStorage.getItem("persona_Id");
    if (personaId != null) {
      var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = personaId; data.nameForeignKey = "PersonaId";
      this.service.datatableKey("Empleado", data).subscribe((empleado) => {
        if (empleado.data.length == 1) {
          this.frmProductos.controls['EmpleadoId'].setValue(empleado.data[0].id);
        } else {
          Swal.fire({
            title: '¡No existe un empleado con este usuario!',
            icon: 'warning',
          }).then(() => {
            this.helperService.redirectApp("/login");
          });
        }
      })
    }
  }

  cargarCategorias() {
    this.service.getAll('Categoria').subscribe((res) => {
      res.data.forEach((item: any) => {
        this.listCategorias.update(listCategorias => {
          const DataSelectDto: DataSelectDto = {
            id: item.id,
            textoMostrar: `${item.codigo} - ${item.nombre}`,
            activo: item.activo
          };

          return [...listCategorias, DataSelectDto];
        });
      });
    });
  }

  save() {
    if (this.frmProductos.invalid) {
      this.statusForm = false;
      this.helperService.showMessage(MessageType.WARNING, Messages.EMPTYFIELD);
      return;
    }

    if (this.id != undefined && this.id != null) {
      var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = this.id; data.nameForeignKey = "TablaId";
      if (this.dataArchivo != undefined) {
        this.dataArchivo.TablaId = this.id;
        this.dataArchivo.Nombre = this.frmProductos.controls['Codigo'].value;
        this.service.datatableKey("Archivo", data).subscribe((res) => {
          if (res.data.length > 0) {
            res.data.forEach((item: any) => {
              if (item.tabla == "Producto") {
                // Eliminar imagenes exixtente
                this.service.delete("Archivo", item.id).subscribe(() => { });
              }
            });
          }
        });
        this.guardarProducto(false, true);
      } else {
        this.guardarProducto(false, false);
      }
    } else {
      if (this.dataArchivo != undefined) {
        this.guardarProducto(true, true);
      } else {
        this.guardarProducto(false, false);
      }
    }
  }

  guardarProducto(nuevo: boolean, imagen: boolean) {
    this.helperService.showLoading();
    let data = {
      id: this.id ?? 0,
      ...this.frmProductos.value,
    };

    this.service.save("Producto", this.id, data).subscribe(
      (response) => {
        if (response.status) {
          setTimeout(() => {
            this.helperService.hideLoading();
          }, 200);
          this.helperService.showMessage(MessageType.SUCCESS, Messages.SAVESUCCESS);
          if (imagen) {
            if (nuevo) {
              this.dataArchivo.TablaId = response.data.id;
              this.dataArchivo.Nombre = response.data.codigo;
            }
            this.guardarImagen();
          } else {
            this.helperService.redirectApp(`/dashboard/inventario/productos`);
          }
        }
      },
      (error) => {
        setTimeout(() => {
          this.helperService.hideLoading();
        }, 200);
        this.helperService.showMessage(MessageType.ERROR, error.error.message);
      }
    );
  }

  guardarImagen() {
    this.service.save("Archivo", 0, this.dataArchivo).subscribe(
      (response) => {
        if (response.status) {
          setTimeout(() => {
            this.helperService.hideLoading();
          }, 200);
          this.helperService.redirectApp(`/dashboard/inventario/productos`);
        }
      },
      (error) => {
        setTimeout(() => {
          this.helperService.hideLoading();
        }, 200);
        this.helperService.showMessage(MessageType.ERROR, error.error.message);
      }
    );
  }

  cancel() {
    this.helperService. redirectApp('/dashboard/inventario/productos');
  }

  fileEvent(event: any) {
    let archivo: any;
    let type = event.target.files[0].type.split('/')[1];
    let { name } = event.target.files[0];
    if (type == 'png' || type == 'jpeg' || type == 'jpg') {
      var reader = new FileReader();
      reader.readAsDataURL(event.target.files[0]);
      reader.onload = async (e: any) => {
        archivo = await e.target.result; //imagen en base 64
        this.dataArchivo = {
          Nombre: name,
          TablaId: 1,
          Tabla: 'Producto',
          Extension: type,
          Content: archivo,
          Activo: true,
        };
        this.img = archivo;
      };
    }
  }

}
@NgModule({
  declarations: [
    ProductosFormComponent,
    ProductosInsumosComponent
  ],
  imports: [
    CommonModule,
    GeneralModule,
    NgbNavModule,
    AutocompleteLibModule,
  ],
})
export class ProductosFormModule { }