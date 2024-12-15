import { Generic } from '../../../../generic/generic.module';

export interface BitacoraInventario extends Generic {
    cantidad: number;
    createAt: Date;
    observacion: string;
    empleadoId: number;
    empleado: string;
    insumoId: number;    
    insumo: string;    
}