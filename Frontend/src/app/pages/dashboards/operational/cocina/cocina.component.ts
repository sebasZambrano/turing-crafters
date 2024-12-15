import { Component, NgModule, OnInit, signal } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { ActivatedRoute } from '@angular/router';
import { HelperService, MessageType } from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../generic/general.service';
import { DatatableParameter } from '../../../../admin/datatable.parameters';
import { OrdenDetalle } from './cocina.module';

@Component({
    selector: 'app-cocina-form',
    standalone: false,
    templateUrl: './cocina.component.html',
    styleUrl: './cocina.component.css',
})
export class CocinaFormComponent implements OnInit {
    date: Date = new Date();
    horaActual = "";
    title = "";
    meses: string[] = ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'];
    listOrdenesDetalles = signal<OrdenDetalle[]>([]);

    constructor(
        public routerActive: ActivatedRoute,
        private service: GeneralParameterService,
        private helperService: HelperService,
        private datePipe: DatePipe
    ) {
        this.title = `Pedidos en cocina ${this.date.getDay()} de ${this.meses[this.date.getMonth()]} del ${this.date.getFullYear()}`;
    }

    ngOnInit(): void {
        this.actualizarHora();
        this.cargarListaInicial();
        this.refrescarTabla();
        setInterval(() => {
            this.actualizarHora();
        }, 1000);
    }

    refrescarTabla() {
        setInterval(() => {
            this.cargarLista();
        }, 5000)
    }

    cargarListaInicial() {
        this.getData().then((datos) => {
            datos.data.forEach((item: any) => {
                var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = item.id; data.nameForeignKey = "OrdenId";

                this.service.datatableKey("OrdenDetalle", data).subscribe((datosDetalle: any) => {
                    datosDetalle.data.forEach((detalle: any) => {
                        if (detalle.estado == "PREPARACIÓN") {
                            const newOrdenDetalle: OrdenDetalle = {
                                id: detalle.id,
                                activo: detalle.activo,
                                cantidad: detalle.cantidad,
                                producto: detalle.producto,
                                observaciones: detalle.observaciones,
                                empleado: item.empleado,
                                mesa: item.mesa,
                                createAt: detalle.createAt,
                                time: this.calculateDifference(detalle.createAt),
                                minutos: this.calculateDifferenceMinutes(detalle.createAt),
                            };

                            this.listOrdenesDetalles().push(newOrdenDetalle);
                        }
                    });
                });
            });
        }).catch((error) => {
            console.error('Error al obtener los datos:', error);
        });
    }

    cargarLista() {
        this.getData().then((datos) => {
            datos.data.forEach((item: any) => {
                var data = new DatatableParameter();
                data.pageNumber = "";
                data.pageSize = "";
                data.filter = "";
                data.columnOrder = "";
                data.directionOrder = "";
                data.foreignKey = item.id;
                data.nameForeignKey = "OrdenId";

                this.service.datatableKey("OrdenDetalle", data).subscribe((datosDetalle: any) => {
                    datosDetalle.data.forEach((detalle: any) => {
                        if (detalle.estado == "PREPARACIÓN") {
                            const existingDetail = this.listOrdenesDetalles().find(d => d.id === detalle.id);

                            if (existingDetail) {
                                // Actualizar los datos del detalle existente
                                existingDetail.activo = detalle.activo;
                                existingDetail.cantidad = detalle.cantidad;
                                existingDetail.producto = detalle.producto;
                                existingDetail.observaciones = detalle.observaciones;
                                existingDetail.empleado = item.empleado;
                                existingDetail.mesa = item.mesa;
                                existingDetail.createAt = detalle.createAt;
                                existingDetail.time = this.calculateDifference(detalle.createAt);
                                existingDetail.minutos = this.calculateDifferenceMinutes(detalle.createAt);
                            } else {
                                // Agregar un nuevo detalle si no existe
                                const newOrdenDetalle: OrdenDetalle = {
                                    id: detalle.id,
                                    activo: detalle.activo,
                                    cantidad: detalle.cantidad,
                                    producto: detalle.producto,
                                    observaciones: detalle.observaciones,
                                    empleado: item.empleado,
                                    mesa: item.mesa,
                                    createAt: detalle.createAt,
                                    time: this.calculateDifference(detalle.createAt),
                                    minutos: this.calculateDifferenceMinutes(detalle.createAt),
                                };

                                this.listOrdenesDetalles().push(newOrdenDetalle);
                                this.notificacion();
                            }
                        }
                    });
                });
            });
        }).catch((error) => {
            console.error('Error al obtener los datos:', error);
        });
    }

    getData(): Promise<any> {
        var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = "";
        return new Promise((resolve, reject) => {
            this.service.datatable("Orden", data).subscribe(
                (datos) => {
                    resolve(datos);
                },
                (error) => {
                    reject(error);
                }
            )
        });
    }

    actualizarHora() {
        const ahora = new Date();
        this.horaActual = ahora.toLocaleTimeString('en-US', { hour: 'numeric', minute: 'numeric', second: 'numeric', hour12: true });
    }

    calculateDifference(dateString: any): string {
        const date2 = new Date(dateString);
        const timeDifference = Math.abs(date2.getTime() - new Date().getTime());

        // Calcular horas y minutos
        const hours = Math.floor(timeDifference / (1000 * 60 * 60));
        const minutes = Math.floor((timeDifference % (1000 * 60 * 60)) / (1000 * 60));
        const seconds = Math.floor((timeDifference % (1000 * 60)) / 1000);
        const formattedminutes = minutes.toString().padStart(2, '0');
        const formattedSeconds = seconds.toString().padStart(2, '0');

        var tiempo = "";
        if (hours == 0) {
            tiempo = `${formattedminutes}:${formattedSeconds}`;
        } else {
            tiempo = `${hours}:${formattedminutes}:${formattedSeconds}`;
        }
        return tiempo;
    }

    calculateDifferenceMinutes(dateString: any): number {
        const date2 = new Date(dateString);
        const milisegundos = Math.abs(date2.getTime() - new Date().getTime());
        const segundos = milisegundos / 1000;
        const minutos = segundos / 60;
        return Math.floor(minutos);
    }

    Atender(id: number) {
        this.helperService.showLoading();
        this.service.getById("OrdenDetalle", id).subscribe((detalle) => {
            this.service.getByCode("Estado", "07").subscribe((estado) => {
                var data = {
                    Id: detalle.data.id,
                    Activo: detalle.data.activo,
                    Codigo: detalle.data.codigo,
                    Cantidad: detalle.data.cantidad,
                    Precio: detalle.data.precio,
                    Observaciones: detalle.data.observaciones,
                    OrdenId: detalle.data.ordenId,
                    ProductoId: detalle.data.productoId,
                    EstadoId: estado.data.id,
                }
                this.service.save("OrdenDetalle", id, data).subscribe(
                    (response) => {
                        if (response.status) {
                            setTimeout(() => {
                                this.helperService.hideLoading();
                            }, 200);
                            this.helperService.showMessage(MessageType.SUCCESS, "Pedido atendido");
                            this.listOrdenesDetalles.update(listOrdenesDetalles => listOrdenesDetalles.filter(detalle => detalle.id !== id));
                        } else {
                            setTimeout(() => {
                                this.helperService.hideLoading();
                            }, 200);
                        }
                    },
                    (error) => {
                        setTimeout(() => {
                            this.helperService.hideLoading();
                        }, 200);
                        this.helperService.showMessage(MessageType.WARNING, error);
                    }
                )
            });
        });
    }

    notificacion() {
        const audio = new Audio('../../../../../assets/sound.mp3');
        audio.play();
    }
}
@NgModule({
    declarations: [CocinaFormComponent],
    imports: [CommonModule, GeneralModule],
})
export class CocinaFormModule { }
