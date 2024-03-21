import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cargo } from '../models/cargo.model';

@Injectable({
  providedIn: 'root'
})
export class CargoService {
  private baseUrl = 'https://localhost:7242/api/Cargo'; 

  constructor(private http: HttpClient) { }

  getAllCargos(): Observable<Cargo[]> {
    return this.http.get<Cargo[]>(`${this.baseUrl}`);
  }

  createCargo(cargo: Cargo): Observable<Cargo> {
    return this.http.post<Cargo>(`${this.baseUrl}`, cargo);
  }

  updateCargo(id: number, cargo: Cargo): Observable<Cargo> {
    return this.http.put<Cargo>(`${this.baseUrl}/${id}`, cargo);
  }

  deleteCargo(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
