import { Base } from '../../../../generic/base.module'

export interface FacturaCompraDetalle extends Base {
  codigo: string;
  cantidad: number;
  subTotal: number;
  precioCosto: number;
  descuento: number;
  iva: number;
  facturaCompraId: number;
  facturaCompra: string;
  insumoId: number;
  insumo: string;
}