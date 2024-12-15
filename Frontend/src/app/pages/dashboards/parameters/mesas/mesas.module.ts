import { Generic } from '../../../../generic/generic.module';
import { Orden } from '../../operational/ordenes-resto/orden.module';

export interface Mesa extends Generic {
    descripcion: string;
    cupo: number;
    salonId: number;
    salon: string;
    estadoId: number;
    estado: string;
    orden: Orden;
}
