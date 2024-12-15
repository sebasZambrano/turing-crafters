import { Component, NgModule, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../../generic/general.service';
import { NgbNavModule } from '@ng-bootstrap/ng-bootstrap';
import { InventariosDetallesComponent } from '../../impresoras-categorias/impresoras-categorias.component';

@Component({
    selector: 'app-impresoras-form',
    standalone: false,
    templateUrl: './impresoras-form.component.html',
    styleUrl: './impresoras-form.component.css'
})
export class ImpresorasFormComponent implements OnInit {
    frmImpresoras: FormGroup;
    statusForm: boolean = true
    id!: number;
    botones = ['btn-guardar', 'btn-cancelar'];
    title = "Crear Impresora";
    breadcrumb = [
        { name: `Inicio`, icon: `fa-duotone fa-house` },
        { name: 'Parametros', icon: 'fa-duotone fa-gears' },
        { name: 'Impresoras', icon: 'fa-duotone fa-print' },
        { name: 'Crear', icon: 'fa-duotone fa-octagon-plus' },
    ];
    listaTamano: any[] = [{ nombre: 58 }, { nombre: 80 }];

    constructor(
        public routerActive: ActivatedRoute,
        private service: GeneralParameterService,
        private helperService: HelperService,
    ) {
        this.frmImpresoras = new FormGroup({
            Codigo: new FormControl(null, [Validators.required, Validators.maxLength(20)]),
            Nombre: new FormControl(null, [Validators.required, Validators.maxLength(100)]),
            Descripcion: new FormControl(""),
            Tamaño: new FormControl(null, [Validators.required]),
            Activo: new FormControl(true, Validators.required)
        });
        this.routerActive.params.subscribe((l) => (this.id = l['id']));
    }

    ngOnInit(): void {
        if (this.id != undefined && this.id != null) {
            this.title = "Editar Impresora";
            this.breadcrumb = [
                { name: `Inicio`, icon: `fa-duotone fa-house` },
                { name: 'Parametros', icon: 'fa-duotone fa-gears' },
                { name: 'Impresoras', icon: 'fa-duotone fa-print' },
                { name: 'Editar', icon: 'fa-duotone fa-pen-to-square' },
            ];
            this.service.getById("Impresora", this.id).subscribe(l => {
                this.frmImpresoras.controls['Codigo'].setValue(l.data.codigo);
                this.frmImpresoras.controls['Nombre'].setValue(l.data.nombre);
                this.frmImpresoras.controls['Descripcion'].setValue(l.data.descripcion);
                this.frmImpresoras.controls['Tamaño'].setValue(l.data.tamaño);
                this.frmImpresoras.controls['Activo'].setValue(l.data.activo);
            })
        }
    }

    save() {
        if (this.frmImpresoras.invalid) {
            this.statusForm = false
            this.helperService.showMessage(MessageType.WARNING, Messages.EMPTYFIELD);
            return;
        }
        let data = {
            id: this.id ?? 0,
            ...this.frmImpresoras.value
        };
        this.service.save("Impresora", this.id, data).subscribe(
            (response) => {
                if (response.status) {
                    this.helperService.showMessage(MessageType.SUCCESS, Messages.SAVESUCCESS);
                    this.helperService.redirectApp('dashboard/parametros/impresoras');
                }
            },
            (error) => {
                this.helperService.showMessage(MessageType.WARNING, error.error.message);
            }
        )
    }

    cancel() {
        this.helperService.redirectApp('dashboard/parametros/impresoras');
    }
}

@NgModule({
    declarations: [
        ImpresorasFormComponent,
        InventariosDetallesComponent
    ],
    imports: [
        CommonModule,
        GeneralModule,
        NgbNavModule
    ]
})
export class ImpresorasFormModule { }