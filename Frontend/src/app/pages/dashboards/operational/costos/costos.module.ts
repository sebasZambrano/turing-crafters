import { Base } from '../../../../generic/base.module'

export interface Costo extends Base {
    descripcion: string;
    fechaCosto: Date;
    valor: number;
    pagoCaja: boolean;
    numeroFactura: string;
    tipoCostoId: number;
    tipoCosto: string;
    empleadoId: number;
    empleado: string;
    proveedorId: number;
    proveedor: string;
    cajaId: number;
    caja: string;
}