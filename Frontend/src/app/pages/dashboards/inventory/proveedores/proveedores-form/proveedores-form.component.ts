import { Component, NgModule, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Router, ActivatedRoute } from '@angular/router';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../../generic/general.service';
import { NgbNavModule } from '@ng-bootstrap/ng-bootstrap';
import { DataSelectDto } from '../../../../../generic/dataSelectDto';
import { GeneralParameterFormComponent } from '../../../general-parameter/general-parameter-form/general-parameter-form.component'
import { ProveedoresInsumosComponent } from '../../proveedores-insumos/proveedores-insumos.component';
import { EmpresaFormComponent } from '../../../operational/empresa/empresa-form/empresa-form.component';
import { AutocompleteLibModule } from 'angular-ng-autocomplete';

@Component({
  selector: 'app-proveedores-form',
  standalone: false,
  templateUrl: './proveedores-form.component.html',
  styleUrl: './proveedores-form.component.css'
})
export class ProveedoresFormComponent implements OnInit {
  frmProveedores: FormGroup;
  statusForm: boolean = true;
  id!: number;
  botones = ['btn-guardar', 'btn-cancelar'];
  title = 'Crear Proveedor';
  breadcrumb = [{ name: `Inicio`, icon: `fa-duotone fa-house` }, { name: "Inventario", icon: "fa-duotone fa-boxes-stacked" }, { name: "Proveedores", icon: "fa-duotone fa-people-carry-box" }, { name: 'Crear', icon: "fa-duotone fa-octagon-plus" }];
  listEmpresas = signal<DataSelectDto[]>([]);
  listBancos = signal<DataSelectDto[]>([]);

  constructor(
    public routerActive: ActivatedRoute,
    private service: GeneralParameterService,
    private helperService: HelperService,
    private modalService: NgbModal,
    private router: Router,
  ) {
    this.frmProveedores = new FormGroup({
      NumeroCuenta: new FormControl("", Validators.required),
      EmpresaId: new FormControl(null, Validators.required),
      BancoId: new FormControl(null, Validators.required),
      Activo: new FormControl(true, Validators.required),
    });
    this.routerActive.params.subscribe((l) => (this.id = l['id']));
  }

  ngOnInit(): void {
    this.cargarEmpresas(false);
    this.cargarBancos(false);

    if (this.id != undefined && this.id != null) {
      this.title = 'Editar Proveedor';
      this.breadcrumb = [{ name: `Inicio`, icon: `fa-duotone fa-house` }, { name: "Inventario", icon: "fa-duotone fa-boxes-stacked" }, { name: "Proveedores", icon: "fa-duotone fa-people-carry-box" }, { name: 'Editar', icon: "fa-duotone fa-pen-to-square" }];
      this.service.getById("Proveedor", this.id).subscribe((l) => {
        this.frmProveedores.controls['NumeroCuenta'].setValue(l.data.numeroCuenta);
        this.frmProveedores.controls['EmpresaId'].setValue(l.data.empresaId);
        this.frmProveedores.controls['BancoId'].setValue(l.data.bancoId);
        this.frmProveedores.controls['Activo'].setValue(l.data.activo);
      });
    }
  }

  cargarEmpresas(nuevo: boolean) {
    this.service.getAll('Empresa').subscribe((res) => {
      res.data.forEach((item: any) => {
        this.listEmpresas.update(listEmpresas => {
          const DataSelectDto: DataSelectDto = {
            id: item.id,
            activo: item.activo,
            textoMostrar: `${item.nit} - ${item.razonSocial}`
          };

          return [...listEmpresas, DataSelectDto];
        });

        if (nuevo) {
          this.frmProveedores.controls['EmpresaId'].setValue(item.id);
        }
      });
    });
  }

  cargarBancos(nuevo: boolean) {
    this.service.getAll('Banco').subscribe((res) => {
      res.data.forEach((item: any) => {
        this.listBancos.update(listBancos => {
          const DataSelectDto: DataSelectDto = {
            id: item.id,
            activo: item.activo,
            textoMostrar: `${item.codigo} - ${item.nombre}`
          };

          return [...listBancos, DataSelectDto];
        });

        if (nuevo) {
          this.frmProveedores.controls['BancoId'].setValue(item.id);
        }
      });
    });
  }

  save() {
    if (this.frmProveedores.invalid) {
      this.statusForm = false;
      this.helperService.showMessage(MessageType.WARNING, Messages.EMPTYFIELD);
      return;
    }
    let data = {
      id: this.id ?? 0,
      ...this.frmProveedores.value,
    };
    this.service.save("Proveedor", this.id, data).subscribe(
      (response) => {
        if (response.status) {
          this.helperService.showMessage(MessageType.SUCCESS, Messages.SAVESUCCESS);

          var ruta: string[] = this.router.url.toString().split('/');

          if (ruta[2] != 'inventario') {
            this.modalService.dismissAll();
          } else {
            this.helperService.redirectApp(`/dashboard/inventario/proveedores/editar/${response.data.id}`);
          }
        }
      },
      (error) => {
        this.helperService.showMessage(MessageType.ERROR, error.error.message);
      }
    );
  }

  cancel() {
    var ruta: string[] = this.router.url.toString().split('/');

    if (ruta[2] != 'inventario') {
      this.modalService.dismissAll();
    } else {
      this.helperService. redirectApp('/dashboard/inventario/proveedores');
    }
  }

  nuevaEmpresa() {
    let modal = this.modalService.open(EmpresaFormComponent, { size: 'xl', keyboard: false, backdrop: false, centered: true });
    modal.result.finally(() => {
      this.listEmpresas = signal<DataSelectDto[]>([]);

      setTimeout(() => {
        this.cargarEmpresas(true);
      }, 200);
    });
  }

  nuevoBanco() {
    let modal = this.modalService.open(GeneralParameterFormComponent, { size: 'md', keyboard: false, backdrop: false, centered: true });
    modal.componentInstance.titleData = "Banco";
    modal.componentInstance.serviceName = "Banco";

    modal.result.then(res => {
      if (res) {
        this.listBancos = signal<DataSelectDto[]>([]);

        setTimeout(() => {
          this.cargarBancos(true);
        }, 200);
      }
    })
  }
}
@NgModule({
  declarations: [
    ProveedoresFormComponent,
    ProveedoresInsumosComponent
  ],
  imports: [
    CommonModule,
    GeneralModule,
    NgbNavModule,
    AutocompleteLibModule
  ],
})
export class ProveedoresFormModule { }