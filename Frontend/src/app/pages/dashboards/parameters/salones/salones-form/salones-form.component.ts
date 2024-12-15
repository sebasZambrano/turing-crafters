import { Component, NgModule, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../../generic/general.service';
import { DataSelectDto } from 'src/app/generic/dataSelectDto';

@Component({
  selector: 'app-salones-form',
  standalone: false,
  templateUrl: './salones-form.component.html',
  styleUrl: './salones-form.component.css'
})
export class SalonesFormComponent implements OnInit {
  frmSalones: FormGroup;
  statusForm: boolean = true
  id!: number;
  botones = ['btn-guardar', 'btn-cancelar'];
  titulo = "";
  serviceName: String = '';
  titleData: String = '';
  listaZonas = signal<DataSelectDto[]>([]);

  constructor(
    public routerActive: ActivatedRoute,
    private service: GeneralParameterService,
    private helperService: HelperService,
    private modalActive: NgbActiveModal
  ) {
    this.frmSalones = new FormGroup({
      Codigo: new FormControl(null, [Validators.required, Validators.maxLength(20)]),
      Nombre: new FormControl(null, [Validators.required, Validators.maxLength(100)]),
      Descripcion: new FormControl(""),
      ZonaId: new FormControl(null, [Validators.required]),
      Activo: new FormControl(true, Validators.required)
    });
  }

  ngOnInit(): void {
    this.cargarZonas();
    if (this.id != undefined && this.id != null) {
      this.titulo = `Editar ${this.titleData}`;
      this.service.getById(this.serviceName, this.id).subscribe(l => {
        this.frmSalones.controls['Codigo'].setValue(l.data.codigo);
        this.frmSalones.controls['Nombre'].setValue(l.data.nombre);
        this.frmSalones.controls['Descripcion'].setValue(l.data.descripcion);
        this.frmSalones.controls['ZonaId'].setValue(l.data.zonaId);
        this.frmSalones.controls['Activo'].setValue(l.data.activo);
      })
    } else {
      this.titulo = `Crear ${this.titleData}`;
    }
  }

  cargarZonas() {
    this.service.getAll('Zona').subscribe((res) => {
      res.data.forEach((item: any) => {
        this.listaZonas.update((listaZonas) => {
          const DataSelectDto: DataSelectDto = {
            id: item.id,
            textoMostrar: `${item.codigo} - ${item.nombre}`,
            activo: item.activo,
          };

          return [...listaZonas, DataSelectDto];
        });
      });
    });
  }

  save() {
    if (this.frmSalones.invalid) {
      this.statusForm = false
      this.helperService.showMessage(MessageType.WARNING, Messages.EMPTYFIELD);
      return;
    }
    let data = {
      id: this.id ?? 0,
      ...this.frmSalones.value
    };
    this.service.save(this.serviceName, this.id, data).subscribe(
      (response) => {
        if (response.status) {
          this.modalActive.close(true);
          this.helperService.showMessage(MessageType.SUCCESS, Messages.SAVESUCCESS);
        }
      },
      (error) => {
        this.helperService.showMessage(MessageType.WARNING, error.error.message);
      }
    )
  }

  cancel() {
    this.modalActive.close();
  }
}

@NgModule({
  declarations: [
    SalonesFormComponent,
  ],
  imports: [
    CommonModule,
    GeneralModule
  ]
})
export class SalonesFormModule { }