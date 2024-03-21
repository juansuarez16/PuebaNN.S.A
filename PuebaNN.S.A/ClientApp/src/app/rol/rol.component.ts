import { Component, OnInit } from '@angular/core';
import { Rol } from '../models/rol.model';
import { RolService } from '../services/rol.service';

@Component({
  selector: 'app-rol',
  templateUrl: './rol.component.html',
  styleUrls: ['./rol.component.css']
})
export class RolComponent implements OnInit {
  roles: Rol[] = [];
  nuevoRol: Rol = { id: 0, rolName: '' };

  constructor(private rolService: RolService) { }

  ngOnInit(): void {
    this.getAllRoles();
  }

  getAllRoles(): void {
    this.rolService.getAllRoles().subscribe(
      roles => this.roles = roles,
      error => console.error(error)
    );
  }

  crearRol(): void {
    this.rolService.createRol(this.nuevoRol).subscribe(
      rol => {
        this.roles.push(rol);
        this.nuevoRol = { id: 0, rolName: '' };
      },
      error => console.error(error)
    );
  }

  actualizarRol(id: number, rol: Rol): void {
    this.rolService.updateRol(id, rol).subscribe(
      updatedRol => {
        const index = this.roles.findIndex(r => r.id === id);
        if (index !== -1) {
          this.roles[index] = updatedRol;
        }
      },
      error => console.error(error)
    );
  }

  eliminarRol(id: number): void {
    this.rolService.deleteRol(id).subscribe(
      () => {
        this.roles = this.roles.filter(r => r.id !== id);
      },
      error => console.error(error)
    );
  }
}
