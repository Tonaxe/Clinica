import { Component } from '@angular/core';

@Component({
  selector: 'app-editar-visita',
  standalone: false,
  templateUrl: './editar-visita.component.html',
  styleUrl: './editar-visita.component.css'
})
export class EditarVisitaComponent {
visita = {
  fecha_hora: '2025-06-01T10:00:00',
  motivo: 'Molestia persistente',
  observaciones: 'Se observa inflamación en encías',
  tratamiento_prescrito: 'Antiinflamatorio por 7 días',
  paciente_id: 17,
  odontologo_id: 5
};

}
