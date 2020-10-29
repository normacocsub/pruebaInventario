import { Inject, Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Insumo } from '../Inventario/models/insumo';


@Injectable({
  providedIn: 'root'
})
export class InsumoService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService
  ) { this.baseUrl = baseUrl; }

  post(insumo: Insumo): Observable<Insumo> {
    return this.http.post<Insumo>(this.baseUrl + 'api/Insumo', insumo).pipe(
      tap(_ => this.handleErrorService.log('datos enviados')),
      catchError(this.handleErrorService.handleError<Insumo>('Registrar Insumo', null))
    );
  }

  get(): Observable<Insumo[]> {
    return this.http.get<Insumo[]>(this.baseUrl + 'api/Insumo').pipe(
      tap(_ => this.handleErrorService.log('Datos')),
      catchError(this.handleErrorService.handleError<Insumo[]>('Consulta Insumos', null))
    );
  }

}
