import { Asignatura } from "./asignatura";
import { Detalles } from "./detalles";

export class Solicitud {
    numero: string;
    
    identificacion: string;​

    nombre: string;​

    sexo: string;​

    edad: number;​

    detalles: Detalles[];

    asignatura: Asignatura;
}
