import { Component, OnInit, NgModule, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { HelperService } from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../../generic/general.service';
import { DatatableParameter } from '../../../../../admin/datatable.parameters';
import { Propina } from '../propinas.module';
import { LANGUAGE_DATATABLE } from 'src/app/admin/datatable.language';


@Component({
    selector: 'app-propinas-index',
    standalone: false,
    templateUrl: './propinas-index.component.html',
    styleUrl: './propinas-index.component.css'
})
export class PropinasIndexComponent implements OnInit {
    title = "Listado de Propinas";
    breadcrumb!: any[];
    botones: String[] = ['btn-nuevo'];
    listPropinas = signal<Propina[]>([]);

    constructor(
        private service: GeneralParameterService,
        public helperService: HelperService
    ) {
        this.breadcrumb = [{ name: `Inicio`, icon: `fa-duotone fa-house` }, { name: "Operativo", icon: "fa-duotone fa-shop" }, { name: "Propinas", icon: "fa-duotone fa-dollar-sign" }];
    }

    ngOnInit(): void {
        this.cargarLista();
    }

    cargarLista() {
        this.getData()
            .then((datos) => {
                datos.data.forEach((item: any) => {
                    this.listPropinas.update(listPropinas => {
                        const Propina: Propina = {
                            id: item.id,
                            valor: item.valor,
                            porcentaje: item.porcentaje,
                            liquidado: item.liquidado,
                            updateAt: item.updateAt,
                            empleadoId: item.empleadoId,
                            facturaId: item.facturaId,
                            medioPagoId: item.medioPagoId,
                            empleado: item.empleado,
                            factura: item.factura,
                            medioPago: item.medioPago,
                            activo: item.activo,
                        };

                        return [...listPropinas, Propina];
                    });
                });

                setTimeout(() => {
                    $("#datatable").DataTable({
                        dom: 'Blfrtip',
                        destroy: true,
                        language: LANGUAGE_DATATABLE,
                        processing: true
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
            this.service.datatable("Propina", data).subscribe(
                (datos) => {
                    resolve(datos);
                },
                (error) => {
                    reject(error);
                }
            )
        });
    }

    refrescarTabla() {
        $("#datatable").DataTable().destroy();
        this.listPropinas = signal<Propina[]>([]);
        this.cargarLista();
    }
}
@NgModule({
    declarations: [
        PropinasIndexComponent,
    ],
    imports: [
        CommonModule,
        GeneralModule,
    ]
})
export class PropinasIndexModule { }