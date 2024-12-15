import { Component, NgModule, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../../generic/general.service';
import { DataSelectDto } from '../../../../../generic/dataSelectDto';

@Component({
  selector: 'app-insumos-form',
  standalone: false,
  templateUrl: './insumos-form.component.html',
  styleUrl: './insumos-form.component.css'
})
export class InsumosFormComponent implements OnInit {
  frmInsumos: FormGroup;
  statusForm: boolean = true;
  id!: number;
  botones = ['btn-guardar', 'btn-cancelar'];
  title = 'Crear Insumo';
  breadcrumb = [{ name: `Inicio`, icon: `fa-duotone fa-house` }, { name: 'Inventario', icon: 'fa-duotone fa-boxes-stacked' }, { name: 'Insumos', icon: "fa-duotone fa-hat-cowboy" }, { name: 'Crear', icon: "fa-duotone fa-octagon-plus" }];
  listUnidadMedida = signal<DataSelectDto[]>([]);

  constructor(
    public routerActive: ActivatedRoute,
    private service: GeneralParameterService,
    private helperService: HelperService,
  ) {
    this.frmInsumos = new FormGroup({
      Codigo: new FormControl(null, [Validators.required, Validators.maxLength(20)]),
      Nombre: new FormControl(null, [Validators.required, Validators.maxLength(100)]),
      Descripcion: new FormControl(null, [Validators.required, Validators.maxLength(100)]),
      UnidadMedidaId: new FormControl(null, [Validators.required]),
      Activo: new FormControl(true, Validators.required)
    });
    this.routerActive.params.subscribe((l) => (this.id = l['id']));
  }

  ngOnInit(): void {
    if (this.id != undefined && this.id != null) {
      this.title = 'Editar Insumo';
      this.breadcrumb = [{ name: `Inicio`, icon: `fa-duotone fa-house` }, { name: 'Inventario', icon: 'fa-duotone fa-boxes-stacked' }, { name: 'Insumos', icon: "fa-duotone fa-hat-cowboy" }, { name: 'Editar', icon: "fa-duotone fa-pen-to-square" }];
      this.service.getById("Insumo", this.id).subscribe((l) => {
        this.frmInsumos.controls['Codigo'].setValue(l.data.codigo);
        this.frmInsumos.controls['Nombre'].setValue(l.data.nombre);
        this.frmInsumos.controls['Descripcion'].setValue(l.data.descripcion);
        this.frmInsumos.controls['UnidadMedidaId'].setValue(l.data.unidadMedidaId);
        this.frmInsumos.controls['Activo'].setValue(l.data.activo);
      });
    }
    this.cargarUnidadMedida();
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
      });
    });
  }

  save() {
    if (this.frmInsumos.invalid) {
      this.statusForm = false;
      this.helperService.showMessage(MessageType.WARNING, Messages.EMPTYFIELD);
      return;
    }
    let data = {
      id: this.id ?? 0,
      ...this.frmInsumos.value,
    };
    this.service.save("Insumo", this.id, data).subscribe(
      (response) => {
        if (response.status) {
          this.helperService.showMessage(MessageType.SUCCESS, Messages.SAVESUCCESS);
          this.helperService.redirectApp(`/dashboard/inventario/insumos`);
        }
      },
      (error) => {
        this.helperService.showMessage(MessageType.ERROR, error.error.message);
      }
    );
  }

  cancel() {
    this.helperService. redirectApp('/dashboard/inventario/insumos');
  }

}

@NgModule({
  declarations: [
    InsumosFormComponent,
  ],
  imports: [
    CommonModule,
    GeneralModule,
  ],
})
export class InsumosFormModule { }