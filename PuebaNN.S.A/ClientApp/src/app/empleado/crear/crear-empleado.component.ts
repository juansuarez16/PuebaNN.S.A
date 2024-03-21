import { Component, OnInit } from '@angular/core';
import { EmpleadoService } from '../../services/empleado.service';
import { CargoService } from '../../cargos/cargo.service';
import { RolService } from '../../services/rol.service';
import { Empleado } from '../../models/empleado.model';
import { Cargo } from '../../models/cargo.model';
import { Rol } from '../../models/rol.model';
import { Router } from '@angular/router';
import { SolicitudCrearEmpleado } from 'src/app/models/solicitud-crear-empleado.model';
@Component({
  selector: 'app-crear-empleado',
  templateUrl: './crear-empleado.component.html',
  styleUrls: ['./crear-empleado.component.css']
})
export class CrearEmpleadoComponent implements OnInit {
    nuevaSolicitud: SolicitudCrearEmpleado = {
        empleado: {
          updateDate: new Date(),
          createDate: new Date(),
          cedula: 0,
          nombre: '',
          rutaFoto: '',
          fechaIngreso: new Date(),
          cargoId: 0,
          rolId: 0
        },
        usuario: {
          updateDate: new Date(),
          createDate: new Date(),
          usuario: '',
          contrasena: ''
        },
        rol: 0
      };
  cargos: Cargo[] = [];
    roles: Rol[] = [];

  constructor(
    private empleadoService: EmpleadoService,
    private cargoService: CargoService,
    private rolService: RolService,
    private router: Router
  ) {}

  ngOnInit(): void {
    // Obtener la lista de cargos
    this.cargoService.getAllCargos().subscribe(cargos => this.cargos = cargos);
    // Obtener la lista de roles
    this.rolService.getAllRoles().subscribe(roles => this.roles = roles);
  }
  volver(): void {
    this.router.navigate(['/empleados']); // Redirige al usuario al formulario de creación de empleados
  }
  crearEmpleado(): void {
    // Llamar al servicio para crear un nuevo empleado
    console.log('Empleado creado:', this.nuevaSolicitud);
    this.empleadoService.createEmpleado(this.nuevaSolicitud).subscribe(
      empleadoCreado => {
        console.log('Empleado creado:', empleadoCreado);
        // Aquí podrías agregar lógica adicional, como redirigir a la página de lista de empleados
      },
      error => {
        console.error('Error al crear empleado:', error);
        // Aquí podrías manejar el error de alguna manera (por ejemplo, mostrar un mensaje al usuario)
      }
    );
  }

  // Método para manejar la selección de un archivo para la foto
  onFileSelected(event: any): void {
    const file: File = event.target.files[0];
    // Aquí puedes agregar lógica para convertir el archivo a base64 y asignarlo al campo de la ruta de la foto
  }
}
