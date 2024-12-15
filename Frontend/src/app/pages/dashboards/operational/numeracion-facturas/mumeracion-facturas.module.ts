import { Base } from '../../../../generic/base.module';

export interface NumeracionFacturas extends Base {
  codigo: string;
  nombre: string;
  prefijo: string;
  numInicial: number;
  numFinal: number;
  numActual: number;
  resolucion: string;
  autorizacion: string;
}
