import { Component, NgModule, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../../generic/general.service';
import { DataSelectDto } from 'src/app/generic/dataSelectDto';
import { DatatableParameter } from 'src/app/admin/datatable.parameters';

@Component({
  selector: 'app-mesas-form',
  standalone: false,
  templateUrl: './mesas-form.component.html',
  styleUrl: './mesas-form.component.css'
})
export class MesasFormComponent implements OnInit {
  frmMesas: FormGroup;
  statusForm: boolean = true
  id!: number;
  botones = ['btn-guardar', 'btn-cancelar'];
  titulo = "";
  serviceName: String = '';
  titleData: String = '';
  listaSalones = signal<DataSelectDto[]>([]);
  listaEstados = signal<DataSelectDto[]>([]);

  constructor(
    public routerActive: ActivatedRoute,
    private service: GeneralParameterService,
    private helperService: HelperService,
    private modalActive: NgbActiveModal
  ) {
    this.frmMesas = new FormGroup({
      Codigo: new FormControl(null, [Validators.required, Validators.maxLength(20)]),
      Nombre: new FormControl(null, [Validators.required, Validators.maxLength(100)]),
      Descripcion: new FormControl(""),
      Cupo: new FormControl(null, [Validators.required]),
      SalonId: new FormControl(null, [Validators.required]),
      EstadoId: new FormControl(null),
      Activo: new FormControl(true, Validators.required)
    });
  }

  ngOnInit(): void {
    this.cargarSalones();
    this.cargarEstados();
    if (this.id != undefined && this.id != null) {
      this.titulo = `Editar ${this.titleData}`;
      this.service.getById(this.serviceName, this.id).subscribe(l => {
        this.frmMesas.controls['Codigo'].setValue(l.data.codigo);
        this.frmMesas.controls['Nombre'].setValue(l.data.nombre);
        this.frmMesas.controls['Descripcion'].setValue(l.data.descripcion);
        this.frmMesas.controls['SalonId'].setValue(l.data.salonId);
        this.frmMesas.controls['EstadoId'].setValue(l.data.estadoId);
        this.frmMesas.controls['Cupo'].setValue(l.data.cupo);
        this.frmMesas.controls['Activo'].setValue(l.data.activo);
      })
    } else {
      this.titulo = `Crear ${this.titleData}`;
    }
  }

  cargarEstados() {
    var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = "";
    this.service.datatable('Estado', data).subscribe((res) => {
      res.data.forEach((item: any) => {
        if (item.tipoEstado == "MESA") {
          this.listaEstados.update((listaEstados) => {
            const DataSelectDto: DataSelectDto = {
              id: item.id,
              textoMostrar: `${item.nombre}`,
              activo: item.activo,
            };

            return [...listaEstados, DataSelectDto];
          });
        }
      });
    });
  }

  cargarSalones() {
    this.service.getAll('Salon').subscribe((res) => {
      res.data.forEach((item: any) => {
        this.listaSalones.update((listaSalones) => {
          const DataSelectDto: DataSelectDto = {
            id: item.id,
            textoMostrar: `${item.codigo} - ${item.nombre}`,
            activo: item.activo,
          };

          return [...listaSalones, DataSelectDto];
        });
      });
    });
  }

  save() {
    if (this.frmMesas.invalid) {
      this.statusForm = false
      this.helperService.showMessage(MessageType.WARNING, Messages.EMPTYFIELD);
      return;
    }
    let data = {
      id: this.id ?? 0,
      ...this.frmMesas.value
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
    MesasFormComponent,
  ],
  imports: [
    CommonModule,
    GeneralModule
  ]
})
export class MesasFormModule { }