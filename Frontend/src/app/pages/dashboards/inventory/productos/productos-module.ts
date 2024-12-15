import { Generic } from '../../../../generic/generic.module';

export interface Producto extends Generic {
    descripcionCorta: string;
    descripcionLarga: string;
    precio: number;
    precioCosto: number;
    descuento: number;
    iva: number;
    categoriaId: number;
    categoria: string;
    imagen?: any;
}