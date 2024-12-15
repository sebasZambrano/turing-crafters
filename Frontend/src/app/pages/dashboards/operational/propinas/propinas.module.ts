import { Base } from '../../../../generic/base.module';

export interface Propina extends Base {
  valor: number;
  porcentaje: number;
  liquidado: boolean;
  updateAt: Date;
  empleadoId: number;
  facturaId: number;
  medioPagoId: number;
  empleado: string;
  factura: string;
  medioPago: string;
}
