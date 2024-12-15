import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DatatableParameter } from '../admin/datatable.parameters';
import { environment } from '../../environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class GeneralParameterService {

  private url = environment.url;
  private header = new HttpHeaders();

  constructor(private http: HttpClient) {
    this.header.set("Content-Type", "application/json");
  }

  public datatable(ruta: String, data: DatatableParameter): Observable<any> {
    return this.http.get<any>(`${this.url}${ruta}/datatable?PageNumber=${data.pageNumber}&PageSize=${data.pageSize}&Filter=${data.filter}&ColumnOrder=${data.columnOrder}&DirectionOrder=${data.directionOrder}`, { headers: this.header })
  }

  public datatableKey(ruta: String, data: DatatableParameter): Observable<any> {
    return this.http.get<any>(`${this.url}${ruta}/datatable?PageSize=${data.pageSize}&PageNumber=${data.pageNumber}&Filter=${data.filter}&ColumnOrder=${data.columnOrder}&DirectionOrder=${data.directionOrder}&ForeignKey=${data.foreignKey}&NameForeignKey=${data.nameForeignKey}`, { headers: this.header });
  }

  public datatableDate(ruta: String, data: DatatableParameter): Observable<any> {
    return this.http.get<any>(`${this.url}${ruta}/datatable?PageSize=${data.pageSize}&PageNumber=${data.pageNumber}&Filter=${data.filter}&ColumnOrder=${data.columnOrder}&DirectionOrder=${data.directionOrder}&FechaInicio=${data.fechaInicio}&FechaFin=${data.fechaFin}`, { headers: this.header });
  }

  public getById(ruta: String, id: any): Observable<any> {
    return this.http.get<any>(`${this.url}${ruta}/${id}`, { headers: this.header });
  }

  public getByCode(ruta: String, code: any): Observable<any> {
    return this.http.get<any>(`${this.url}${ruta}/code/${code}`, { headers: this.header });
  }

  public getAll(ruta: String): Observable<any> {
    return this.http.get<any>(`${this.url}${ruta}/select`, { headers: this.header });
  }

  public save(ruta: String, id: any, data: any): Observable<any> {
    if (id) {
      return this.http.put<any>(`${this.url}${ruta}`, data, { headers: this.header });
    }
    return this.http.post<any>(`${this.url}${ruta}`, data, { headers: this.header });
  }

  public saveDetalles(ruta: String, data: any): Observable<any> {
    return this.http.post<any>(`${this.url}${ruta}/saveDetalles`, data, { headers: this.header });
  }

  public updateDetalles(ruta: String, data: any): Observable<any> {
    return this.http.post<any>(`${this.url}${ruta}/updateDetalles`, data, { headers: this.header });
  }

  public generarFactura(ruta: String, id: any): Observable<any> {
    return this.http.post<any>(`${this.url}${ruta}/generarFactura/${id}`, id, { headers: this.header });
  }

  public delete(ruta: String, id: any): Observable<any> {
    return this.http.delete<any>(`${this.url}${ruta}/${id}`, { headers: this.header });
  }

  public limpiar(ruta: String, id: any): Observable<any> {
    return this.http.delete<any>(`${this.url}${ruta}/limpiar/${id}`, { headers: this.header });
  }

  public deleteEmpleado(ruta: String, id: any, idEmpleado: any): Observable<any> {
    return this.http.delete<any>(`${this.url}${ruta}/${id}/${idEmpleado}`, { headers: this.header });
  }

  public GetArchivo(ruta: String, id: any): Observable<any> {
    return this.http.get<any>(`${this.url}${ruta}/GetArchivoCierre/${id}`, { headers: this.header });
  }

  //DashBoard
  public getSalesDate(ruta: String, data: any, parameter: String): Observable<any> {
    return this.http.get<any>(`${this.url}${ruta}/getSalesDate/${parameter}?PageNumber=${data.pageNumber}&PageSize=${data.pageSize}&Filter=${data.filter}&ColumnOrder=${data.columnOrder}&DirectionOrder=${data.directionOrder}`, { headers: this.header })
  }

  public getSalesCalendar(ruta: String, data: any, parameter: String): Observable<any> {
    return this.http.get<any>(`${this.url}${ruta}/getSalesCalendar/${parameter}?PageNumber=${data.pageNumber}&PageSize=${data.pageSize}&Filter=${data.filter}&ColumnOrder=${data.columnOrder}&DirectionOrder=${data.directionOrder}`, { headers: this.header })
  }

  public getBillsDate(ruta: String, data: any, parameter: String): Observable<any> {
    return this.http.get<any>(`${this.url}${ruta}/getBillsDate/${parameter}?PageNumber=${data.pageNumber}&PageSize=${data.pageSize}&Filter=${data.filter}&ColumnOrder=${data.columnOrder}&DirectionOrder=${data.directionOrder}`, { headers: this.header })
  }

  public getBillsCalendar(ruta: String, data: any, parameter: String): Observable<any> {
    return this.http.get<any>(`${this.url}${ruta}/getBillsCalendar/${parameter}?PageNumber=${data.pageNumber}&PageSize=${data.pageSize}&Filter=${data.filter}&ColumnOrder=${data.columnOrder}&DirectionOrder=${data.directionOrder}`, { headers: this.header })
  }

  public getDebtsDate(ruta: String, data: any, parameter: String): Observable<any> {
    return this.http.get<any>(`${this.url}${ruta}/getDebtsDate/${parameter}?PageNumber=${data.pageNumber}&PageSize=${data.pageSize}&Filter=${data.filter}&ColumnOrder=${data.columnOrder}&DirectionOrder=${data.directionOrder}`, { headers: this.header })
  }

  public getDebtsCalendar(ruta: String, data: any, parameter: String): Observable<any> {
    return this.http.get<any>(`${this.url}${ruta}/getDebtsCalendar/${parameter}?PageNumber=${data.pageNumber}&PageSize=${data.pageSize}&Filter=${data.filter}&ColumnOrder=${data.columnOrder}&DirectionOrder=${data.directionOrder}`, { headers: this.header })
  }
}