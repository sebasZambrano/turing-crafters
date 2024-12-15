import { Component, NgModule, OnInit, signal } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import {
  HelperService,
  Messages,
  MessageType,
} from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../../generic/general.service';
import { DatatableParameter } from '../../../../../admin/datatable.parameters';
import { DataSelectDto } from '../../../../../generic/dataSelectDto';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-cierres-form',
  standalone: false,
  templateUrl: './cierres-form.component.html',
  styleUrl: './cierres-form.component.css',
})
export class CierresFormComponent implements OnInit {
  frmCierres: FormGroup;
  statusForm: boolean = true
  id!: number;
  botones = ['btn-guardar', 'btn-cancelar'];
  title = 'Crear Cierre';
  breadcrumb = [
    { name: `Inicio`, icon: `fa-duotone fa-house` },
    { name: 'Operativo', icon: 'fa-duotone fa-shop' },
    { name: 'Cierres', icon: 'fa-duotone fa-shop-lock' },
    { name: 'Crear', icon: 'fa-duotone fa-octagon-plus' },
  ];
  listCajas = signal<DataSelectDto[]>([]);

  constructor(
    public routerActive: ActivatedRoute,
    private service: GeneralParameterService,
    private helperService: HelperService,
    private datePipe: DatePipe
  ) {
    this.frmCierres = new FormGroup({
      FechaInicial: new FormControl(null, [Validators.required]),
      FechaFinal: new FormControl(null, [Validators.required]),
      TotalIngreso: new FormControl(0),
      TotalEgreso: new FormControl(0),
      SaldoCaja: new FormControl(0),
      SaldoEmpleado: new FormControl(0, [Validators.required]),
      Base: new FormControl(0, [Validators.required]),
      Observacion: new FormControl(''),
      EmpleadoId: new FormControl(null, [Validators.required]),
      Activo: new FormControl(true, Validators.required),
      CajaId: new FormControl(null, [Validators.required]),
    });
    this.routerActive.params.subscribe((l) => (this.id = l['id']));
  }

  ngOnInit(): void {
    this.validarEmpleado();
    this.cargarCajas();

    if (this.id != undefined && this.id != null) {
      this.title = 'Editar Cierre';
      this.breadcrumb = [
        { name: `Inicio`, icon: `fa-duotone fa-house` },
        { name: 'Operativo', icon: 'fa-duotone fa-shop' },
        { name: 'Cierres', icon: 'fa-duotone fa-shop-lock' },
        { name: 'Editar', icon: 'fa-duotone fa-pen-to-square' },
      ];
      this.service.getById('Cierre', this.id).subscribe((l) => {
        const formattedFechaInicial = this.datePipe.transform(
          l.data.fechaInicial,
          'yyyy-MM-ddTHH:mm:ss',
          'America/Bogota'
        );
        const formattedFechaFinal = this.datePipe.transform(
          l.data.fechaFinal,
          'yyyy-MM-ddTHH:mm:ss',
          'America/Bogota'
        );
        this.frmCierres.controls['FechaInicial'].setValue(
          formattedFechaInicial
        );
        this.frmCierres.controls['FechaFinal'].setValue(formattedFechaFinal);
        this.frmCierres.controls['TotalIngreso'].setValue(l.data.totalIngreso);
        this.frmCierres.controls['TotalEgreso'].setValue(l.data.totalEgreso);
        this.frmCierres.controls['SaldoCaja'].setValue(l.data.saldoCaja);
        this.frmCierres.controls['SaldoEmpleado'].setValue(
          l.data.saldoEmpleado
        );
        this.frmCierres.controls['Base'].setValue(l.data.base);
        this.frmCierres.controls['Observacion'].setValue(l.data.observacion);
        this.frmCierres.controls['EmpleadoId'].setValue(l.data.empleadoId);
        this.frmCierres.controls['Activo'].setValue(l.data.activo);
      });
    }
  }

  cargarCajas() {
    //Agregar general
    this.listCajas.update(listCajas => {
      const DataSelectDto: DataSelectDto = {
        id: 0,
        textoMostrar: "GENERAL",
        activo: true
      };

      return [...listCajas, DataSelectDto];
    });

    this.service.getAll('Caja').subscribe((res) => {
      res.data.forEach((item: any) => {
        this.listCajas.update(listCajas => {
          const DataSelectDto: DataSelectDto = {
            id: item.id,
            textoMostrar: `${item.codigo} - ${item.nombre}`,
            activo: item.activo
          };

          return [...listCajas, DataSelectDto];
        });
      });
    });
  }

  validarEmpleado() {
    var personaId = localStorage.getItem('persona_Id');
    if (personaId != null) {
      var data = new DatatableParameter();
      data.pageNumber = '';
      data.pageSize = '';
      data.filter = '';
      data.columnOrder = '';
      data.directionOrder = '';
      data.foreignKey = personaId;
      data.nameForeignKey = 'PersonaId';
      this.service.datatableKey('Empleado', data).subscribe((empleado) => {
        if (empleado.data.length == 1) {
          this.frmCierres.controls['EmpleadoId'].setValue(empleado.data[0].id);
        } else {
          Swal.fire({
            title: '¡No existe un empleado con este usuario!',
            icon: 'warning',
          }).then(() => {
            this.helperService.redirectApp('/login');
          });
        }
      });
    }
  }

  save() {
    if (this.frmCierres.invalid) {
      this.statusForm = false;
      this.helperService.showMessage(MessageType.WARNING, Messages.EMPTYFIELD);
      return;
    }
    let data = {
      id: this.id ?? 0,
      ...this.frmCierres.value,
    };
    this.helperService.showLoading();
    this.service.save('Cierre', this.id, data).subscribe(
      (response) => {
        if (response.status) {
          this.helperService.showMessage(
            MessageType.SUCCESS,
            Messages.SAVESUCCESS
          );
          this.ImprimirCierre(response.data.id);
        }
      },
      (error) => {
        this.helperService.showMessage(MessageType.ERROR, error.error.message);
      }
    );
  }

  cancel() {
    this.helperService.redirectApp('/dashboard/operativo/cierres');
  }

  ImprimirCierre(id: any) {
    this.service.GetArchivo('Cierre', id).subscribe((data: any) => {
      this.openPdfInNewTab(data.data.content);
    });
  }

  openPdfInNewTab(pdfContent: string) {
    try {
      const byteCharacters = atob(pdfContent);
      const byteNumbers = new Array(byteCharacters.length);
      for (let i = 0; i < byteCharacters.length; i++) {
        byteNumbers[i] = byteCharacters.charCodeAt(i);
      }
      const byteArray = new Uint8Array(byteNumbers);
      const blob = new Blob([byteArray], { type: 'application/pdf' });
      const objectUrl = URL.createObjectURL(blob);

      setTimeout(() => {
        this.helperService.hideLoading();
      }, 200);

      const newWindow = window.open(objectUrl, '_blank');

      if (newWindow) {
        newWindow.document.title = 'Cierre';
        newWindow.print();
      }

      setTimeout(() => {
        this.helperService.redirectApp(`/dashboard/operativo/cierres`);
      }, 500);
    } catch (error) {
      console.error('Error decoding PDF content:', error);
    }
  }
}
@NgModule({
  declarations: [CierresFormComponent],
  imports: [CommonModule, GeneralModule],
})
export class CierresFormModule { }
