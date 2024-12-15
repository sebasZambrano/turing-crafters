import { Component, NgModule, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../../generic/general.service';
import { NgbAccordionModule } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-configuraciones-form',
  standalone: false,
  templateUrl: './configuraciones-form.component.html',
  styleUrl: './configuraciones-form.component.css'
})
export class ConfiguracionesFormComponent implements OnInit {
  frmConfiguracion: FormGroup;
  statusForm: boolean = true;
  id!: number;
  botones = ['btn-guardar'];
  title = 'Configuración general';
  breadcrumb = [{ name: `Inicio`, icon: `fa-duotone fa-house` }, { name: 'Parametros', icon: 'fa-duotone fa-gears' }, { name: 'Configuración General', icon: 'fa-duotone fa-gear' }];
  public listaTamano: any[] = [{ valor: 80 }];

  constructor(
    public routerActive: ActivatedRoute,
    private service: GeneralParameterService,
    private helperService: HelperService
  ) {
    this.frmConfiguracion = new FormGroup({
      ImprimeFactura: new FormControl(false, [Validators.required]),
      CantidadFactura: new FormControl(null, [Validators.required]),
      TamañoImpresion: new FormControl(null, [Validators.required]),
      ManejaInventario: new FormControl(false, [Validators.required]),
      ManejaClaveSupervisor: new FormControl(false, [Validators.required]),
      ClaveSupervisor: new FormControl(null, [Validators.required]),
      ManejaRemision: new FormControl(false, [Validators.required]),
      Activo: new FormControl(true, Validators.required),
    });
    this.routerActive.params.subscribe((l) => (this.id = l['id']));
  }

  ngOnInit(): void {
    if (this.id != undefined && this.id != null) {
      this.service.getById('Configuracion', this.id).subscribe((l) => {
        this.frmConfiguracion.controls['ImprimeFactura'].setValue(l.data.imprimeFactura);
        this.frmConfiguracion.controls['CantidadFactura'].setValue(l.data.cantidadFactura);
        this.frmConfiguracion.controls['TamañoImpresion'].setValue(l.data.tamañoImpresion);
        this.frmConfiguracion.controls['ManejaInventario'].setValue(l.data.manejaInventario);
        this.frmConfiguracion.controls['ManejaClaveSupervisor'].setValue(l.data.manejaClaveSupervisor);
        this.frmConfiguracion.controls['ClaveSupervisor'].setValue(l.data.claveSupervisor);
        this.frmConfiguracion.controls['ManejaRemision'].setValue(l.data.manejaRemision);
        this.frmConfiguracion.controls['Activo'].setValue(l.data.activo);
      });
    }
  }

  save() {
    if (this.frmConfiguracion.invalid) {
      this.statusForm = false;
      this.helperService.showMessage(MessageType.WARNING, Messages.EMPTYFIELD);
      return;
    }
    this.frmConfiguracion.controls["ClaveSupervisor"].setValue(this.frmConfiguracion.controls["ClaveSupervisor"].value.toString());
    let data = {
      id: this.id ?? 0,
      ...this.frmConfiguracion.value,
    };
    this.service.save('Configuracion', this.id, data).subscribe(
      (response) => {
        if (response.status) {
          this.helperService.showMessage(
            MessageType.SUCCESS,
            "Ajustes guardados"
          );
        }
      },
      (error) => {
        this.helperService.showMessage(MessageType.ERROR, error.error.message);
      }
    );
  }
}
@NgModule({
  declarations: [
    ConfiguracionesFormComponent
  ],
  imports: [
    CommonModule,
    GeneralModule,
    NgbAccordionModule
  ],
})
export class ConfiguracionesFormModule { }