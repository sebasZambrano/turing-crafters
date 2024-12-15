import { Component, NgModule, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { GeneralModule } from 'src/app/general/general.module';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../../generic/general.service';
import { NgbNavModule } from '@ng-bootstrap/ng-bootstrap';
import { DetallesInventariosBodegasFormComponent } from '../../detalles-inventarios-bodegas/detalles-inventarios-bodegas-form/detalles-inventarios-bodegas-form.component';
import { AutocompleteLibModule } from 'angular-ng-autocomplete';

@Component({
  selector: 'app-bodegas-form',
  standalone: false,
  templateUrl: './bodegas-form.component.html',
  styleUrl: './bodegas-form.component.css'
})
export class BodegasFormComponent implements OnInit {
  frmBodegas: FormGroup;
  statusForm: boolean = true
  id!: number;
  botones = ['btn-guardar', 'btn-cancelar'];
  title = "Crear Bodega";
  breadcrumb = [{ name: `Inicio`, icon: `fa-duotone fa-house` }, { name: 'Inventario', icon: 'fa-duotone fa-boxes-stacked' }, { name: 'Bodegas', icon: "fa-duotone fa-warehouse" }, { name: 'Crear', icon: "fa-duotone fa-octagon-plus" }];

  constructor(
    public routerActive: ActivatedRoute,
    private service: GeneralParameterService,
    private helperService: HelperService
  ) {
    this.frmBodegas = new FormGroup({
      Codigo: new FormControl(null, [Validators.required, Validators.maxLength(20)]),
      Nombre: new FormControl(null, [Validators.required, Validators.maxLength(100)]),
      Activo: new FormControl(true, Validators.required)
    });
    this.routerActive.params.subscribe((l) => (this.id = l['id']));

  }

  ngOnInit(): void {
    if (this.id != undefined && this.id != null) {
      this.title = "Editar Bodega";
      this.breadcrumb = [{ name: `Inicio`, icon: `fa-duotone fa-house` }, { name: 'Inventario', icon: 'fa-duotone fa-boxes-stacked' }, { name: 'Bodegas', icon: "fa-duotone fa-warehouse" }, { name: 'Editar', icon: "fa-duotone fa-pen-to-square" }];
      this.service.getById("Bodega", this.id).subscribe(l => {
        this.frmBodegas.controls['Codigo'].setValue(l.data.codigo);
        this.frmBodegas.controls['Nombre'].setValue(l.data.nombre);
        this.frmBodegas.controls['Activo'].setValue(l.data.activo);
      })
    }
  }

  save() {
    if (this.frmBodegas.invalid) {
      this.statusForm = false
      this.helperService.showMessage(MessageType.WARNING, Messages.EMPTYFIELD);
      return;
    }
    let data = {
      id: this.id ?? 0,
      ...this.frmBodegas.value
    };
    this.service.save("Bodega", this.id, data).subscribe(
      (response) => {
        if (response.status) {
          this.helperService.redirectApp("/dashboard/inventario/bodegas");
          this.helperService.showMessage(MessageType.SUCCESS, Messages.SAVESUCCESS);
        }
      },
      (error) => {
        this.helperService.showMessage(MessageType.WARNING, error.error.message);
      }
    )
  }

  cancel() {
    this.helperService.redirectApp("/dashboard/inventario/bodegas");
  }
}
@NgModule({
  declarations: [
    BodegasFormComponent,
    DetallesInventariosBodegasFormComponent
  ],
  imports: [
    CommonModule,
    GeneralModule,
    AutocompleteLibModule,
    NgbNavModule
  ]
})
export class BodegasFormModule { }