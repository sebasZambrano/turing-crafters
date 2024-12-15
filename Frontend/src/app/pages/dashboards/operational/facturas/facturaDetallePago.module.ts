import { Base } from '../../../../generic/base.module'

export interface FacturaDetallePago extends Base {
  valor: number;
  observacion: string;
  empleadoId: number;
  medioPagoId: number;
  medioPago: string;
  facturaId: number;
}