import { Base } from '../../../../generic/base.module';

export interface NotaCreditoDetalle extends Base {
    notaCreditoId: number;
    facturaDetalleId: number;
    cantidad: number;
    notaCredito: string;
    facturaDetalle: string;
    select: boolean;
    codigo: string;
    producto: string;
    precioProducto: number;
    subTotal: number;
    productoId: number;
}
