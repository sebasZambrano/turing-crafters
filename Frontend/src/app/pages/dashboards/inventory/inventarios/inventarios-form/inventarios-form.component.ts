import { Component, NgModule, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../../generic/general.service';
import { NgbNavModule } from '@ng-bootstrap/ng-bootstrap';
import { InventariosDetallesComponent } from '../../inventarios-detalles/inventarios-detalles.component';
import { AutocompleteLibModule } from 'angular-ng-autocomplete';

@Component({
  selector: 'app-inventarios-form',
  standalone: false,
  templateUrl: './inventarios-form.component.html',
  styleUrl: './inventarios-form.component.css'
})
export class InventariosFormComponent implements OnInit{
  frmInventarios: FormGroup;
  statusForm: boolean = true;
  id!: number;
  botones = ['btn-guardar', 'btn-cancelar'];
  title = 'Crear Inventario';
  breadcrumb = [{ name: `Inicio`, icon: `fa-duotone fa-house` }, { name: "Inventario", icon: "fa-duotone fa-boxes-stacked" }, { name: "Inventarios", icon: "fa-duotone fa-cart-flatbed-boxes" }, { name: 'Crear', icon: "fa-duotone fa-octagon-plus" }];
  
  constructor(
    public routerActive: ActivatedRoute,
    private service: GeneralParameterService,
    private helperService: HelperService,
  ) {
    this.frmInventarios = new FormGroup({
      Codigo: new FormControl(null, [Validators.required, Validators.maxLength(20)]),
      Nombre: new FormControl(null, [Validators.required, Validators.maxLength(100)]),
      Activo: new FormControl(true, Validators.required),
      Observacion: new FormControl(""),
    });
    this.routerActive.params.subscribe((l) => (this.id = l['id']));
  }

  ngOnInit(): void {
    if (this.id != undefined && this.id != null) {
      this.title = 'Editar Inventario';
      this.breadcrumb = [{ name: `Inicio`, icon: `fa-duotone fa-house` }, { name: "Inventario", icon: "fa-duotone fa-boxes-stacked" }, { name: "Inventarios", icon: "fa-duotone fa-cart-flatbed-boxes" }, { name: 'Editar', icon: "fa-duotone fa-pen-to-square" }];
      this.service.getById("Inventario", this.id).subscribe((l) => {
        this.frmInventarios.controls['Codigo'].setValue(l.data.codigo);
        this.frmInventarios.controls['Nombre'].setValue(l.data.nombre);
        this.frmInventarios.controls['Activo'].setValue(l.data.activo);
        this.frmInventarios.controls['Observacion'].setValue(l.data.observacion);
      });
    }
  }

  save() {
    if (this.frmInventarios.invalid) {
      this.statusForm = false;
      this.helperService.showMessage(MessageType.WARNING, Messages.EMPTYFIELD);
      return;
    }
    let data = {
      id: this.id ?? 0,
      ...this.frmInventarios.value,
    };
    this.service.save("Inventario", this.id, data).subscribe(
      (response) => {
        if (response.status) {
          this.helperService.showMessage(MessageType.SUCCESS, Messages.SAVESUCCESS);
          this.helperService.redirectApp(`/dashboard/inventario/inventarios/editar/${response.data.id}`);
        }
      },
      (error) => {
        this.helperService.showMessage(MessageType.ERROR, error.error.message);
      }
    );
  }

  cancel() {
    this.helperService.redirectApp('/dashboard');
  }
}

@NgModule({
  declarations: [
    InventariosFormComponent,
    InventariosDetallesComponent
  ],
  imports: [
    CommonModule,
    GeneralModule,
    AutocompleteLibModule,
    NgbNavModule,
  ],
})
export class InventariosFormModule { }