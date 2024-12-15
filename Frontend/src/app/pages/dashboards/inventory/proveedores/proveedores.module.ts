import { Base } from '../../../../generic/base.module';

export interface Proveedor extends Base {
    numeroCuenta: string;
    empresaId: number;
    empresa: string;
    bancoId: number;
    banco: string;
}