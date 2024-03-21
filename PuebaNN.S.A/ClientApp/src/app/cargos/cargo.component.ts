// cargo.component.ts

import { Component, OnInit } from '@angular/core';
import { Cargo } from '../models/cargo.model';
import { CargoService } from '../cargos/cargo.service';

@Component({
  selector: 'app-cargo',
  templateUrl: './cargo.component.html',
  styleUrls: ['./cargo.component.css']
})
export class CargoComponent implements OnInit {
  cargos: Cargo[] = [];
  nuevoCargo: Cargo = { id: 0, nombre: '' }; // Inicialización con valores predeterminados

  constructor(private cargoService: CargoService) { }

  ngOnInit(): void {
    this.getAllCargos();
  }

  getAllCargos(): void {
    this.cargoService.getAllCargos().subscribe(
      cargos => this.cargos = cargos,
      error => console.error(error)
    );
  }

  crearCargo(): void {
    this.cargoService.createCargo(this.nuevoCargo).subscribe(
      cargo => {
        this.cargos.push(cargo);
        this.nuevoCargo = { id: 0, nombre: '' }; // Limpiar el formulario
      },
      error => console.error(error)
    );
  }

  actualizarCargo(id: number, cargo: Cargo): void {
    this.cargoService.updateCargo(id, cargo).subscribe(
      updatedCargo => {
        const index = this.cargos.findIndex(c => c.id === id);
        if (index !== -1) {
          this.cargos[index] = updatedCargo;
        }
      },
      error => console.error(error)
    );
  }

  eliminarCargo(id: number): void {
    this.cargoService.deleteCargo(id).subscribe(
      () => {
        this.cargos = this.cargos.filter(c => c.id !== id);
      },
      error => console.error(error)
    );
  }
}
