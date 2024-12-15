import { Generic } from '../../../../generic/generic.module';

export interface Salon extends Generic {
    zonaId: number;
    descripcion: string;
    zona: string;
}
