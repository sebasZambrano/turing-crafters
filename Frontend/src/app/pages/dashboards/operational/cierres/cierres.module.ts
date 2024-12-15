import { Base } from '../../../../generic/base.module'

export interface Cierre extends Base {
    fechaInicial: Date;
    fechaFinal: Date;
    totalIngreso: number;
    totalEgreso: number;
    saldoCaja: number;
    saldoEmpleado: number;
    base: number;
    observacion: string;
    empleadoId: number;
    empleado: string;
}