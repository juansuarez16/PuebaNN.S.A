import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Router } from '@angular/router'; // Importa el servicio de enrutamiento

import { LoginRequest } from './login-request';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'https://localhost:7242/api/auth/login';
  private isLoggedInSubject = new BehaviorSubject<boolean>(false); // Subject para almacenar el estado de inicio de sesión
  isLoggedIn$ = this.isLoggedInSubject.asObservable(); // Observable para acceder al estado de inicio de sesión

  constructor(
    private http: HttpClient,
    private router: Router // Inyecta el servicio de enrutamiento
  ) {}

  // Método para iniciar sesión
  login(loginRequest: LoginRequest): Observable<any> {
    return this.http.post<any>(this.apiUrl, loginRequest).pipe(
      tap(response => {
        console.log(response);
        
        // Verificar si el inicio de sesión fue exitoso
        if (response && response.success) {
          // Actualizar el estado de inicio de sesión a true
          this.isLoggedInSubject.next(true);
          // Redirigir al usuario a la página de inicio
          this.router.navigateByUrl('/home');
        } else {
          // Manejar caso de inicio de sesión fallido
          console.error('Inicio de sesión fallido. Por favor, revise sus credenciales.');
        }
      })
    );
  }

  // Método para cerrar sesión
  logout(): void {
    // Aquí puedes realizar cualquier lógica adicional necesaria para cerrar sesión, como eliminar tokens JWT, limpiar el almacenamiento local, etc.
    this.isLoggedInSubject.next(false); // Actualiza el estado de inicio de sesión a false al cerrar sesión
  }

  // Método para obtener el estado de inicio de sesión de manera síncrona
  isLoggedIn(): boolean {
    return this.isLoggedInSubject.value;
  }
}
