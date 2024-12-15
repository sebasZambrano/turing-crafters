import { Base } from '../../../../generic/base.module';

export interface FacturaDetallePago extends Base {
  createAt: Date;
  numeroFactura: string;
  subTotal: number;
  total: number;
  descuento: number;
  iva: number;
  observacion: string;
  remision: boolean;
  clienteId: number;
  estadoId: number;
  empleadoId: number;
  numeracionFacturaId: number;
}
