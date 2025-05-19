export interface VisitaResponse {
  visitas: Visita[];
  message: string;
}

export interface Visita {
  id: number;
  fecha_hora: string;
  motivo: string;
  observaciones: string;
  tratamiento_prescrito: string;
  paciente: Paciente;
  odontologo: Odontologo;
}

export interface Paciente {
  nombre: string;
  apellido: string;
}

export interface Odontologo {
  nombre: string;
  apellido: string;
}

export interface crearVisita {
  paciente: string;
  odontologo: string;
  fechaYhora: string;
  motivo: string;
  observaciones: string;
}

export interface VisitaEditarRequest {
  paciente_id: number;
  odontologo_id: number;
  fecha_hora: string;
  motivo: string;
  observaciones: string;
  tratamiento_prescrito: string;
}
