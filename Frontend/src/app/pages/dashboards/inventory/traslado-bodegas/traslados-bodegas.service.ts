import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class TrasladoBodegasService {

  private url = environment.url;
  private header = new HttpHeaders();

  constructor(private http: HttpClient) {
    this.header.set("Content-Type", "application/json");
  }

  public trasladoBodegas(ruta: String, data: any): Observable<any> {
    return this.http.post<any>(`${this.url}${ruta}/trasladoBodegas`, data, { headers: this.header });
  }
}
