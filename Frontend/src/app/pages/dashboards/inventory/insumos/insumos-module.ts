import { Generic } from '../../../../generic/generic.module';

export interface Insumo extends Generic {
    descripcion: string;
    unidadMedidaId: number;
    unidadMedida: string;
}