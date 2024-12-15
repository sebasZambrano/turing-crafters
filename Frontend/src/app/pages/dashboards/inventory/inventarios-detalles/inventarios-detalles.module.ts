import { Base } from '../../../../generic/base.module';

export interface InventarioDetalle extends Base {
    cantidadTotal: number;
    cantidadUsada: number;
    cantidadIngresada: number;
    cantidadPendienteAsignar: number;
    inventarioId: number;
    productoId: number;
    inventario: string;
    producto: string;
}