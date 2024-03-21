import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Empleado } from '../models/empleado.model';
import { SolicitudCrearEmpleado } from '../models/solicitud-crear-empleado.model';
@Injectable({
  providedIn: 'root'
})
export class EmpleadoService {
  private baseUrl = 'https://localhost:7242/api/Empleado'; // Reemplaza esto con la URL de tu API

  constructor(private http: HttpClient) { }

  getAllEmpleados(): Observable<Empleado[]> {
    return this.http.get<Empleado[]>(`${this.baseUrl}`);
  }

  createEmpleado(solicitud: SolicitudCrearEmpleado): Observable<Empleado> {
    return this.http.post<Empleado>(`${this.baseUrl}`, solicitud);
  }

  updateEmpleado(id: number, empleado: Empleado): Observable<Empleado> {
    return this.http.put<Empleado>(`${this.baseUrl}/${id}`, empleado);
  }

  deleteEmpleado(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
