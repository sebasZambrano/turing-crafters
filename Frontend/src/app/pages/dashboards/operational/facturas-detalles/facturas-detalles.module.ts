import { Base } from '../../../../generic/base.module';

export interface FacturaDetalle extends Base {
   codigo : string;
   cantidad : number;
   subTotal : number;
   precioProducto : number;
   descuento : number;
   iva : number;
   facturaId : number;
   factura : string;
   productoId : number;
   producto : string;
}