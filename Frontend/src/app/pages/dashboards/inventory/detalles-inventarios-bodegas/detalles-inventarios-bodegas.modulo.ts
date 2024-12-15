import { Base } from '../../../../generic/base.module';

export interface DetalleInventarioBodega extends Base {
    cantidad: number;
    bodegaId: number;
    bodega: string;
    inventarioDetalleId: number;
    inventarioDetalle: string;
}