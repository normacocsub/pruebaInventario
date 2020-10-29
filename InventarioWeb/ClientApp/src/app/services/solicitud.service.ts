import { Inject, Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Solicitud } from '../Inventario/models/solicitud';

@Injectable({
  providedIn: 'root'
})
export class SolicitudService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService
  ) { this.baseUrl = baseUrl; }


  post(solicitud: Solicitud): Observable<Solicitud> {
    return this.http.post<Solicitud>(this.baseUrl + 'api/Solicitud', solicitud).pipe(
      tap(_ => this.handleErrorService.log('datos enviados')),
      catchError(this.handleErrorService.handleError<Solicitud>('Registrar Solicitud', null))
    );
  }
}
