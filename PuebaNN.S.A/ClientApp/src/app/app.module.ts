import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { LoginComponent } from './login/login.component';
import { EmpleadoComponent } from './empleado/empleado.component';
import { CargoComponent } from './cargos/cargo.component';
import { RolComponent } from './rol/rol.component';
import { CrearEmpleadoComponent } from './empleado/crear/crear-empleado.component'; // Importa los componentes de Cargo y Rol

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    LoginComponent,
    EmpleadoComponent,
    CargoComponent, // Agrega el componente CargoComponent
    RolComponent ,
    CrearEmpleadoComponent   // Agrega el componente RolComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', redirectTo: '/login', pathMatch: 'full' }, // Redirige al componente LoginComponent por defecto
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'login', component: LoginComponent },
      { path: 'home', component: HomeComponent },       // Agrega una ruta para el componente HomeComponent (ruta protegida)
      { path: 'empleados', component: EmpleadoComponent },
      { path: 'cargos', component: CargoComponent },   // Agrega una ruta para el componente CargoComponent
      { path: 'roles', component: RolComponent } ,       // Agrega una ruta para el componente RolComponent
      { path: 'crearEmpleado', component: CrearEmpleadoComponent } 
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
