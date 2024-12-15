import { Component, NgModule, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import {
  HelperService,
  Messages,
  MessageType,
} from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../../generic/general.service';
import { PersonasFormComponent } from '../../../security/personas/personas-form/personas-form.component';
import { DataSelectDto } from 'src/app/generic/dataSelectDto';

@Component({
  selector: 'app-clientes-form',
  standalone: false,
  templateUrl: './clientes-form.component.html',
  styleUrl: './clientes-form.component.css',
})
export class ClientesFormComponent implements OnInit {
  frmClientes: FormGroup;
  statusForm: boolean = true;
  id!: number;
  botones = ['btn-guardar', 'btn-cancelar'];
  title = 'Crear Cliente';
  breadcrumb = [
    { name: `Inicio`, icon: `fa-duotone fa-house` },
    { name: 'Parametros', icon: 'fa-duotone fa-gears' },
    { name: 'Clientes', icon: 'fa-duotone fa-user' },
    { name: 'Crear', icon: 'fa-duotone fa-octagon-plus' },
  ];
  listPersonas = signal<DataSelectDto[]>([]);

  constructor(
    public routerActive: ActivatedRoute,
    private service: GeneralParameterService,
    private helperService: HelperService,
    private modalService: NgbModal,
    private router: Router
  ) {
    this.frmClientes = new FormGroup({
      Codigo: new FormControl(""),
      Nombre: new FormControl(null, [Validators.required]),
      PersonaId: new FormControl(null, [Validators.required]),
      Activo: new FormControl(true, Validators.required),
    });
    this.routerActive.params.subscribe((l) => (this.id = l['id']));
  }

  ngOnInit(): void {
    this.cargarPersonas(false);
    if (this.id != undefined && this.id != null) {
      this.title = 'Editar Cliente';
      this.breadcrumb = [
        { name: `Inicio`, icon: `fa-duotone fa-house` },
        { name: 'Parametros', icon: 'fa-duotone fa-gears' },
        { name: 'Clientes', icon: 'fa-duotone fa-user' },
        { name: 'Editar', icon: 'fa-duotone fa-pen-to-square' },
      ];
      this.service.getById('Cliente', this.id).subscribe((l) => {
        this.frmClientes.controls['Codigo'].setValue(l.data.codigo);
        this.frmClientes.controls['Nombre'].setValue(l.data.nombre);
        this.frmClientes.controls['PersonaId'].setValue(l.data.personaId);
        this.frmClientes.controls['Activo'].setValue(l.data.activo);
      });
    }
  }

  save() {
    if (this.frmClientes.invalid) {
      this.statusForm = false;
      this.helperService.showMessage(MessageType.WARNING, Messages.EMPTYFIELD);
      return;
    }
    let data = {
      id: this.id ?? 0,
      ...this.frmClientes.value,
    };
    this.service.save('Cliente', this.id, data).subscribe(
      (response) => {
        if (response.status) {
          this.helperService.showMessage(
            MessageType.SUCCESS,
            Messages.SAVESUCCESS
          );

          var ruta: string[] = this.router.url.toString().split('/');

          if (ruta[2] != 'parametros') {
            this.modalService.dismissAll();
          } else {
            this.helperService.redirectApp('dashboard/parametros/clientes');
          }
        }
      },
      (error) => {
        this.helperService.showMessage(MessageType.WARNING, error.error.message);
      }
    );
  }

  cancel() {
    var ruta: string[] = this.router.url.toString().split('/');
    if (ruta[2] != 'parametros') {
      this.modalService.dismissAll();
    } else {
      this.helperService.redirectApp('dashboard/parametros/clientes');
    }
  }

  nuevaPersona() {
    let modal = this.modalService.open(PersonasFormComponent, {
      size: 'lg',
      keyboard: false,
      backdrop: false,
      centered: true,
    });

    modal.componentInstance.cliente = true;
    modal.componentInstance.titleData = 'Persona';
    modal.componentInstance.serviceName = 'Persona';
    modal.componentInstance.key = 'Ciudad';

    modal.result.finally(() => {
      this.listPersonas = signal<DataSelectDto[]>([]);

      setTimeout(() => {
        this.cargarPersonas(true);
      }, 200);
    });
  }

  cargarPersonas(nuevo: boolean) {
    this.service.getAll('Persona').subscribe((res) => {
      res.data.forEach((item: any) => {
        this.listPersonas.update((listPersonas) => {
          const DataSelectDto: DataSelectDto = {
            id: item.id,
            textoMostrar: `${item.documento} - ${item.primerNombre} ${item.primerApellido}`,
            activo: item.activo,
          };

          return [...listPersonas, DataSelectDto];
        });
        if (nuevo) {
          this.frmClientes.controls['PersonaId'].setValue(item.id);
          this.selectNombre(`${item.primerNombre} ${item.primerApellido}`);
        }
      });
    });
  }

  onselect(event: any) {
    if (typeof event != 'undefined') {
      var array = event.textoMostrar.split('-');
      this.selectNombre(array[1]);
    } else {
      this.frmClientes.controls['Nombre'].setValue(null);
    }
  }

  selectNombre(nombre: string) {
    this.frmClientes.controls['Nombre'].setValue(nombre);
  }
}
@NgModule({
  declarations: [ClientesFormComponent],
  imports: [CommonModule, GeneralModule],
})
export class ClientesFormModule { }
