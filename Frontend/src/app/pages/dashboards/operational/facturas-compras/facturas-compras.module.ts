import { Base } from '../../../../generic/base.module'

export interface FacturaCompra extends Base {
  numeroFactura: string;
  fecha: Date;
  total: number;
  descuento: number;
  iva: number;
  proveedorId: number;
  proveedor: string;
  estadoId: number;
  estado: string;
  empleadoId: number;
  empleado: string;
}