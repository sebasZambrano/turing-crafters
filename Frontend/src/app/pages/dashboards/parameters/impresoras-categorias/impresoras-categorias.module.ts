import { Base } from '../../../../generic/base.module';

export interface ImpresoraCategoria extends Base {
    categoriaId: number;
    categoria: string;
    impresoraId: number;
    impresora: string;
    salonId: number;
    salon: string;
}