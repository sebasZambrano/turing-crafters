import { Base } from '../../../../generic/base.module';

export interface Cierre extends Base {
  codigo: string;
  nombre: string;
  personaId: number;
  persona: string;
}
