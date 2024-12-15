import { Base } from '../../../../generic/base.module';

export interface ProductoInsumo extends Base {
    adicional: boolean;
    cantidad: number;
    insumoId: number;
    insumo: string;
    productoId: number;
    producto: string;
    unidadMedidaId: number;
    unidadMedida: string;    
}