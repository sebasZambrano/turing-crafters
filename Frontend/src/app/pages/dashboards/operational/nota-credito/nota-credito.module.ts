import { Base } from '../../../../generic/base.module';

export interface NotaCredito extends Base {
    codigo: string;
    concepto: string;
    metodoCredito: string;
    total: number;
    pagoCaja: boolean;
    motivoId: number;
    estadoId: number;
    facturaId: number;
    empleadoId: number;
    medioPagoId: number;
    motivo: string;
    estado: string;
    factura: string;
    empleado: string;
    medioPago: string;
    createAt: Date;
}
