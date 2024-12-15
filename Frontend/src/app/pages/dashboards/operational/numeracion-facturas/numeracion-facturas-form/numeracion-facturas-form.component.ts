import { Component, NgModule, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../../generic/general.service';

@Component({
  selector: 'app-numeracion-facturas-form',
  standalone: false,
  templateUrl: './numeracion-facturas-form.component.html',
  styleUrl: './numeracion-facturas-form.component.css',
})
export class NumeracionFacturasFormComponent implements OnInit {
  frmNumeracion: FormGroup;
  statusForm: boolean = true;
  id!: number;
  botones = ['btn-guardar', 'btn-cancelar'];
  title = 'Crear Numeración de Facturación';
  breadcrumb = [
    { name: `Inicio`, icon: `fa-duotone fa-house` },
    { name: 'Operativo', icon: 'fa-duotone fa-shop' },
    { name: 'Numeraciones de Facturas', icon: 'fa-duotone fa-sliders' },
    { name: 'Crear', icon: 'fa-duotone fa-octagon-plus' },
  ];
  public listaCodigo: any[] = [{ nombre: 'POS' }, { nombre: 'RM' }, { nombre: 'NC' }];

  constructor(
    public routerActive: ActivatedRoute,
    private service: GeneralParameterService,
    private helperService: HelperService
  ) {
    this.frmNumeracion = new FormGroup({
      Codigo: new FormControl(null, [Validators.required]),
      Nombre: new FormControl(null, [Validators.required]),
      Prefijo: new FormControl(null, [Validators.required]),
      NumInicial: new FormControl(null, [Validators.required]),
      NumFinal: new FormControl(null, [Validators.required]),
      NumActual: new FormControl(null, [Validators.required]),
      Resolucion: new FormControl(null, [Validators.required]),
      Autorizacion: new FormControl(null, [Validators.required]),
      Activo: new FormControl(true, Validators.required),
    });
    this.routerActive.params.subscribe((l) => (this.id = l['id']));
  }

  ngOnInit(): void {
    if (this.id != undefined && this.id != null) {
      this.title = 'Editar Numeración de Facturación';
      this.breadcrumb = [
        { name: `Inicio`, icon: `fa-duotone fa-house` },
        { name: 'Operativo', icon: 'fa-duotone fa-shop' },
        { name: 'Numeración', icon: 'fa-duotone fa-shop-lock' },
        { name: 'Numeraciones de Facturas', icon: 'fa-duotone fa-sliders' },
      ];
      this.service.getById('NumeracionFactura', this.id).subscribe((l) => {
        this.frmNumeracion.controls['Codigo'].setValue(l.data.codigo);
        this.frmNumeracion.controls['Nombre'].setValue(l.data.nombre);
        this.frmNumeracion.controls['Prefijo'].setValue(l.data.prefijo);
        this.frmNumeracion.controls['NumInicial'].setValue(l.data.numInicial);
        this.frmNumeracion.controls['NumFinal'].setValue(l.data.numFinal);
        this.frmNumeracion.controls['NumActual'].setValue(l.data.numActual);
        this.frmNumeracion.controls['Resolucion'].setValue(l.data.resolucion);
        this.frmNumeracion.controls['Autorizacion'].setValue(
          l.data.autorizacion
        );
        this.frmNumeracion.controls['Activo'].setValue(l.data.activo);
      });
    }
  }

  save() {
    if (this.frmNumeracion.invalid) {
      this.statusForm = false;
      this.helperService.showMessage(MessageType.WARNING, Messages.EMPTYFIELD);
      return;
    }
    this.frmNumeracion.controls['Resolucion'].setValue(
      this.frmNumeracion.controls['Resolucion'].value.toString()
    );
    let data = {
      id: this.id ?? 0,
      ...this.frmNumeracion.value,
    };
    this.service.save('NumeracionFactura', this.id, data).subscribe(
      (response) => {
        if (response.status) {
          this.helperService.showMessage(
            MessageType.SUCCESS,
            Messages.SAVESUCCESS
          );
          this.helperService.redirectApp('/dashboard/operativo/numeracion-facturas');
        }
      },
      (error) => {
        this.helperService.showMessage(MessageType.WARNING, error.error.message);
      }
    );
  }

  cancel() {
    this.helperService.redirectApp('/dashboard/operativo/numeracion-facturas');
  }
}
@NgModule({
  declarations: [NumeracionFacturasFormComponent],
  imports: [CommonModule, GeneralModule],
})
export class NumeracionFacturasFormModule {}
