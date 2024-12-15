import { Base } from '../../../../generic/base.module';

export interface OrdenDetalle extends Base {
    codigo: string;
    cantidad: number;
    precio: number;
    observaciones: string;
    ordenId: number;
    productoId: number;
    estadoId: number;
    orden: string;
    producto: string;
    estado: string;
    subTotal: number;
}
