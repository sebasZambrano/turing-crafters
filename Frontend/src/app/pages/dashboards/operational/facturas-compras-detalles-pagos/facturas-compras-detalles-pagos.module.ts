import { Base } from '../../../../generic/base.module'

export interface FacturaCompraDetallePago extends Base {
  valor: number;
  pagoCaja: boolean;
  observacion: string;
  empleadoId: number;
  empleado: string;
  medioPagoId: number;
  medioPago: string;
  facturaCompraId: number;
  facturaCompra: string;
  createAt: Date;
}