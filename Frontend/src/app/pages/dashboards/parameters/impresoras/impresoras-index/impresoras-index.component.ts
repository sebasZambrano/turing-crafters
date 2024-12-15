import { Component, OnInit, NgModule, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../../generic/general.service';
import { DatatableParameter } from '../../../../../admin/datatable.parameters';
import { Impresora } from '../impresoras.module';
import { LANGUAGE_DATATABLE } from 'src/app/admin/datatable.language';

@Component({
    selector: 'app-impresoras-index',
    standalone: false,
    templateUrl: './impresoras-index.component.html',
    styleUrl: './impresoras-index.component.css'
})
export class ImpresorasIndexComponent implements OnInit {
    API_URL: any;
    title = "Listado de Impresoras";
    breadcrumb!: any[];
    botones: String[] = ['btn-nuevo'];
    listImpresoras = signal<Impresora[]>([]);

    constructor(
        private service: GeneralParameterService,
        private helperService: HelperService
    ) {
        this.breadcrumb = [{ name: `Inicio`, icon: `fa-duotone fa-house` }, { name: "Parametros", icon: "fa-duotone fa-gears" }, { name: "Impresoras", icon: "fa-duotone fa-print" }];
    }

    ngOnInit(): void {
        this.cargarLista();
    }

    nuevo() {
        this.helperService.redirectApp('/dashboard/parametros/impresoras/crear');
    }

    update(id: any) {
        this.helperService.redirectApp(`/dashboard/parametros/impresoras/editar/${id}`);
    }

    refrescarTabla() {
        $("#datatable").DataTable().destroy();
        this.listImpresoras = signal<Impresora[]>([]);
        this.cargarLista();
    }

    cargarLista() {
        this.getData().then((datos) => {
            datos.data.forEach((item: any) => {
                this.listImpresoras.update(listImpresoras => {
                    const Impresora: Impresora = {
                        id: item.id,
                        activo: item.activo,
                        codigo: item.codigo,
                        nombre: item.nombre,
                        tamano: item.tamaño,
                    };

                    return [...listImpresoras, Impresora];
                });
            });

            setTimeout(() => {
                $("#datatable").DataTable({
                    destroy: true,
                    language: LANGUAGE_DATATABLE,
                    processing: true,
                    dom: 'Blfrtip'
                });
            }, 200);
        })
            .catch((error) => {
                console.error('Error al obtener los datos:', error);
            });
    }

    getData(): Promise<any> {
        var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = "";
        return new Promise((resolve, reject) => {
            this.service.datatable("Impresora", data).subscribe(
                (datos) => {
                    resolve(datos);
                },
                (error) => {
                    reject(error);
                }
            )
        });
    }

    deleteGeneric(id: any) {
        this.helperService.confirmDelete(() => {
            this.service.delete("Impresora", id).subscribe(
                (response) => {
                    if (response.status) {
                        this.helperService.showMessage(MessageType.SUCCESS, Messages.DELETESUCCESS);
                        this.refrescarTabla();
                    }
                },
                (error) => {
                    this.helperService.showMessage(MessageType.WARNING, error.error.message);
                }
            )
        });
    }
}

@NgModule({
    declarations: [
        ImpresorasIndexComponent,
    ],
    imports: [
        CommonModule,
        GeneralModule,
    ]
})
export class ImpresorasIndexModule { }