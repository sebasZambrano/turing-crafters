import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DatatableParameter } from '../../../../admin/datatable.parameters';
import { environment } from '../../../../../environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class FacturasService {

  private url = environment.url;
  private header = new HttpHeaders();

  constructor(private http: HttpClient) {
    this.header.set("Content-Type", "application/json");
  }

  public GetArchivoById(id: any): Observable<any> {
    return this.http.get<any>(`${this.url}Factura/getArchivoById/${id}`, { headers: this.header });
  }

  public anular(id: any, empleadoId: any): Observable<any> {
    return this.http.put<any>(`${this.url}Factura/anular/${id}/${empleadoId}`, { headers: this.header });
  }
}
