import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DatatableParameter } from '../../../../admin/datatable.parameters';
import { environment } from '../../../../../environments/environment.prod';

@Injectable({
    providedIn: 'root'
})
export class OrdenesService {

    private url = environment.url;
    private header = new HttpHeaders();

    constructor(private http: HttpClient) {
        this.header.set("Content-Type", "application/json");
    }

    public getOrdenDetalle(data: DatatableParameter): Observable<any> {
        return this.http.get<any>(`${this.url}InsumoProducto/getOrdenDetalle?PageSize=${data.pageSize}&PageNumber=${data.pageNumber}&Filter=${data.filter}&ColumnOrder=${data.columnOrder}&DirectionOrder=${data.directionOrder}&ForeignKey=${data.foreignKey}&NameForeignKey=${data.nameForeignKey}`, { headers: this.header });
    }
}
