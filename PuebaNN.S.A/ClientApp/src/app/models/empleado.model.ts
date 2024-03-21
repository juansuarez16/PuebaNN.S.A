// empleado.model.ts

export interface Empleado {
    cedula: number;
    updateDate: Date;
    createDate: Date;
    nombre: string;
    rutaFoto: string;
    fechaIngreso: Date;
    cargoId: number;
    rolId: number;
  }
  