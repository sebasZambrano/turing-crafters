import { Base } from '../../../../generic/base.module';

export interface Orden extends Base {
    codigo: string;
    descripcion: string;
    cantidadPersonas: number;
    total: number;
    mesaId: number;
    empleadoId: number;
    estadoId: number;
    mesa: string;
    empleado: string;
    estado: string;
    createAt?: Date;
}
