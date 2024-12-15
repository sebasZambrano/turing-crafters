import { Component, NgModule, OnInit, signal } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../../generic/general.service';
import { DatatableParameter } from '../../../../../admin/datatable.parameters';
import { DataSelectDto } from '../../../../../generic/dataSelectDto';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-costos-form',
  standalone: false,
  templateUrl: './costos-form.component.html',
  styleUrl: './costos-form.component.css'
})
export class CostosFormComponent implements OnInit {
  frmCostos: FormGroup;
  statusForm: boolean = true;
  id!: number;
  botones = ['btn-guardar', 'btn-cancelar'];
  title = 'Crear Costo';
  breadcrumb = [{ name: `Inicio`, icon: `fa-duotone fa-house` }, { name: "Operativo", icon: "fa-duotone fa-shop" }, { name: "Costos", icon: "fa-duotone fa-dollar-sign" }, { name: 'Crear', icon: "fa-duotone fa-octagon-plus" }];
  listTiposCostos = signal<DataSelectDto[]>([]);
  listProveedores = signal<DataSelectDto[]>([]);

  constructor(
    public routerActive: ActivatedRoute,
    private service: GeneralParameterService,
    private helperService: HelperService,
    private datePipe: DatePipe
  ) {
    this.frmCostos = new FormGroup({
      Descripcion: new FormControl(null, [Validators.required, Validators.maxLength(100)]),
      FechaCosto: new FormControl(null, [Validators.required]),
      Valor: new FormControl(0, [Validators.required]),
      PagoCaja: new FormControl(false, [Validators.required]),
      NumeroFactura: new FormControl(""),
      TipoCostoId: new FormControl(null, [Validators.required]),
      EmpleadoId: new FormControl(null, [Validators.required]),
      ProveedorId: new FormControl(null, [Validators.required]),
      Activo: new FormControl(true, Validators.required)
    });
    this.routerActive.params.subscribe((l) => (this.id = l['id']));
  }

  ngOnInit(): void {
    this.cargarListas();

    if (this.id != undefined && this.id != null) {
      this.title = 'Editar Costo';
      this.breadcrumb = [{ name: `Inicio`, icon: `fa-duotone fa-house` }, { name: "Operativo", icon: "fa-duotone fa-shop" }, { name: "Costos", icon: "fa-duotone fa-dollar-sign" }, { name: 'Editar', icon: "fa-duotone fa-pen-to-square" }];
      this.service.getById("Costo", this.id).subscribe((l) => {
        const formattedFechaCosto = this.datePipe.transform(l.data.fechaCosto, 'yyyy-MM-ddTHH:mm:ss', 'America/Bogota');

        this.frmCostos.controls['Descripcion'].setValue(l.data.descripcion);
        this.frmCostos.controls['FechaCosto'].setValue(formattedFechaCosto);
        this.frmCostos.controls['Valor'].setValue(l.data.valor);
        this.frmCostos.controls['PagoCaja'].setValue(l.data.pagoCaja);
        this.frmCostos.controls['NumeroFactura'].setValue(l.data.numeroFactura);
        this.frmCostos.controls['TipoCostoId'].setValue(l.data.tipoCostoId);
        this.frmCostos.controls['EmpleadoId'].setValue(l.data.empleadoId);
        this.frmCostos.controls['ProveedorId'].setValue(l.data.proveedorId);
        this.frmCostos.controls['Activo'].setValue(l.data.activo);
      });
    }

  }

  validarEmpleado() {
    var personaId = localStorage.getItem("persona_Id");
    if (personaId != null) {
      var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = personaId; data.nameForeignKey = "PersonaId";
      this.service.datatableKey("Empleado", data).subscribe((empleado) => {
        if (empleado.data.length == 1) {
          this.frmCostos.controls['EmpleadoId'].setValue(empleado.data[0].id);
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

  cargarListas() {
    this.validarEmpleado();
    this.cargarTiposCostos();
    this.cargarProveedores();
  }

  cargarTiposCostos() {
    this.service.getAll('TipoCosto').subscribe((res) => {
      res.data.forEach((item: any) => {
        this.listTiposCostos.update(listTiposCostos => {
          const DataSelectDto: DataSelectDto = {
            id: item.id,
            textoMostrar: `${item.codigo} - ${item.nombre}`,
            activo: item.activo
          };

          return [...listTiposCostos, DataSelectDto];
        });
      });
    });
  }

  cargarProveedores() {
    this.service.getAll('Proveedor').subscribe((res) => {
      res.data.forEach((item: any) => {
        this.listProveedores.update(listProveedores => {
          const DataSelectDto: DataSelectDto = {
            id: item.id,
            textoMostrar: `${item.numeroCuenta} - ${item.empresa}`,
            activo: item.activo
          };

          return [...listProveedores, DataSelectDto];
        });
      });
    });
  }

  save() {
    if (this.frmCostos.invalid) {
      this.statusForm = false;
      this.helperService.showMessage(MessageType.WARNING, Messages.EMPTYFIELD);
      return;
    }
    let data = {
      id: this.id ?? 0,
      ...this.frmCostos.value,
    };
    this.service.save("Costo", this.id, data).subscribe(
      (response) => {
        if (response.status) {
          this.helperService.showMessage(MessageType.SUCCESS, Messages.SAVESUCCESS);
          this.helperService.redirectApp(`/dashboard/operativo/costos`);
        }
      },
      (error) => {
        this.helperService.showMessage(MessageType.ERROR, error.error.message);
      }
    );
  }

  cancel() {
    this.helperService.redirectApp('/dashboard/operativo/costos');
  }
}
@NgModule({
  declarations: [
    CostosFormComponent,
  ],
  imports: [
    CommonModule,
    GeneralModule,
  ],
})
export class CostosFormModule { }