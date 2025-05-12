export interface PacienteResponse {
    pacientes: Paciente[],
    message: string,
}


export interface Paciente {
  id?: number;
  nombre: string;
  apellido: string;
  email: string;
  telefono: string;
  fecha_nacimiento: string;
  tipo_pago: string;
  responsable_nombre: string;
  responsable_apellido: string;
  responsable_email: string;
}