import { Component, OnInit } from '@angular/core';
import { Empleado } from '../models/empleado.model';
import { EmpleadoService } from '../services/empleado.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-empleado',
  templateUrl: './empleado.component.html',
  styleUrls: ['./empleado.component.css']
})
export class EmpleadoComponent implements OnInit {
  empleados: Empleado[] = [];
  

  constructor(private empleadoService: EmpleadoService, private router: Router ) { }

  ngOnInit(): void {
    this.getAllEmpleados();
  }

  getAllEmpleados(): void {
    this.empleadoService.getAllEmpleados().subscribe(
      empleados => this.empleados = empleados,
      error => console.error(error)
    );
  }
  nuevoEmpleadoForm(): void {
    this.router.navigate(['/crearEmpleado']); // Redirige al usuario al formulario de creación de empleados
  }
  

  actualizarEmpleado(empleado: Empleado): void {
    this.empleadoService.updateEmpleado(empleado.cedula, empleado).subscribe(
        updatedEmpleado => {
            const index = this.empleados.findIndex(e => e.cedula === empleado.cedula);
            if (index !== -1) {
                this.empleados[index] = updatedEmpleado;
            }
        },
        error => console.error(error)
    );
  }

  eliminarEmpleado(cedula: number): void {
    this.empleadoService.deleteEmpleado(cedula).subscribe(
        () => {
            this.empleados = this.empleados.filter(e => e.cedula !== cedula);
        },
        error => console.error(error)
    );
  }

}
