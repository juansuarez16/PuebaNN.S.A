import { Empleado } from "./empleado.model";
import { Usuario } from "./usuario.model";

export interface SolicitudCrearEmpleado {
    empleado: Empleado;
    usuario: Usuario;
    rol: number;
  }