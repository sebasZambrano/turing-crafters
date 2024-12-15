import { Component, NgModule, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { ActivatedRoute } from '@angular/router';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { HelperService } from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../../generic/general.service';
import { Generic } from '../../../../../generic/generic.module'
import { DatatableParameter } from 'src/app/admin/datatable.parameters';

@Component({
    selector: 'app-modificaciones-index',
    standalone: false,
    templateUrl: './modificaciones.component.html',
    styleUrl: './modificaciones.component.css'
})
export class ModificacionesComponent implements OnInit {
    botones = ['btn-guardar'];
    observaciones = "";
    listModificaciones = signal<Generic[]>([]);
    listObservaciones = signal<Generic[]>([]);

    constructor(
        public routerActive: ActivatedRoute,
        private service: GeneralParameterService,
        private helperService: HelperService,
        private modalActive: NgbActiveModal
    ) {
    }

    ngOnInit(): void {
        this.cargarLista();
    }

    cargarLista() {
        this.getData().then((datos) => {
            datos.data.forEach((item: any) => {
                this.listModificaciones.update(listModificaciones => {
                    const Generic: Generic = {
                        id: item.id,
                        activo: item.activo,
                        codigo: item.codigo,
                        nombre: item.nombre,
                    };

                    return [...listModificaciones, Generic];
                });
            });
            setTimeout(() => {
                this.cargarModificaciones();
            }, 200);

        }).catch((error) => {
            console.error('Error al obtener los datos:', error);
        });
    }

    cargarModificaciones() {
        const elementos = this.observaciones.split(',').map(item => item.trim());
        elementos.forEach(nombre => {
            if (nombre) {
                var observacion = this.listModificaciones().find(item => item.nombre === nombre);

                this.listObservaciones.update((listObservaciones) => {
                    if (observacion !== undefined) {
                        return [...listObservaciones, observacion];
                    }
                    return listObservaciones;
                });

                if (observacion !== undefined) {
                    $(`#${observacion.id}`).prop("checked", true);
                }
            }
        });
    }

    getData(): Promise<any> {
        var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = "";
        return new Promise((resolve, reject) => {
            this.service.datatable("ModificacionProducto", data).subscribe(
                (datos) => {
                    resolve(datos);
                },
                (error) => {
                    reject(error);
                }
            )
        });
    }

    save() {
        this.modalActive.close(this.observaciones);
    }

    onChange(event: any, item: Generic) {
        if (event.target.checked) {
            this.agregar(item);
        } else {
            this.eliminar(item);
        }
    }

    agregar(item: Generic) {
        const observacion = {
            id: item.id,
            activo: item.activo,
            codigo: item.codigo,
            nombre: item.nombre,
        }

        this.listObservaciones.update((listObservaciones) => [...listObservaciones, observacion]);

        setTimeout(() => {
            this.armarTextoObservacion();
        }, 200);
    }

    eliminar(item: Generic) {
        this.listObservaciones.update((listObservaciones) => listObservaciones.filter((detalle) => detalle.id !== item.id));
        setTimeout(() => {
            this.armarTextoObservacion();
        }, 200);
    }

    armarTextoObservacion() {
        this.observaciones = "";
        for (let i = 0; i < this.listObservaciones().length; i++) {
            this.observaciones += this.listObservaciones()[i].nombre;
            if (i < this.listObservaciones().length - 1) {
                this.observaciones += ", ";
            }
        }
    }
}
@NgModule({
    declarations: [
        ModificacionesComponent,
    ],
    imports: [
        CommonModule,
        GeneralModule
    ]
})
export class ModificacionesModule { }