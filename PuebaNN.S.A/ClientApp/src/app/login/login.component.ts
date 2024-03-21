import { Component } from '@angular/core';
import { LoginRequest } from './login-request';
import { AuthService } from './auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginRequest: LoginRequest = { usuario: '', contrasena: '' };
  errorMessage: string = '';

  constructor(private authService: AuthService) {}

  login() {
    this.authService.login(this.loginRequest).subscribe(
      () => {
        // Redirigir al usuario a la página principal o a donde corresponda después del inicio de sesión exitoso
      },
      error => {
        this.errorMessage = error.message || 'Error al iniciar sesión';
      }
    );
  }
}
