import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Rol } from '../models/rol.model';

@Injectable({
  providedIn: 'root'
})
export class RolService {
  private baseUrl = 'https://localhost:7242/api/Rol'; // Reemplaza esto con la URL de tu API

  constructor(private http: HttpClient) { }

  getAllRoles(): Observable<Rol[]> {
    return this.http.get<Rol[]>(`${this.baseUrl}`);
  }

  createRol(rol: Rol): Observable<Rol> {
    return this.http.post<Rol>(`${this.baseUrl}`, rol);
  }

  updateRol(id: number, rol: Rol): Observable<Rol> {
    return this.http.put<Rol>(`${this.baseUrl}/${id}`, rol);
  }

  deleteRol(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
