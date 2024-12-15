import { Base } from '../../../../generic/base.module';

export interface InsumoProveedor extends Base {
    proveedorId: number;
    proveedor: string;
    insumoId: number;
    insumo: string;
}