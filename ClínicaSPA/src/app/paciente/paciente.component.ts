import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-paciente',
  standalone: false,
  templateUrl: './paciente.component.html',
  styleUrl: './paciente.component.css'
})

export class PacienteComponent {
  pacientes = [
    { id: 1, nombre: 'Juan Pérez', edad: 28, tipoPago: 'Efectivo', responsable: 'No Aplica', historial: [] },
    { id: 2, nombre: 'Ana López', edad: 15, tipoPago: 'Tarjeta', responsable: 'Pedro López', historial: ['Visita 1', 'Visita 2'] },
    { id: 3, nombre: 'María Gómez', edad: 34, tipoPago: 'Seguro', responsable: 'No Aplica', historial: [] }
  ];
  modo: string = '';

  constructor(private router: Router) {}

  setModo(modo: string): void {
    this.modo = modo;
    if (modo === 'alta') {
      this.router.navigate(['/pacientes/alta']);
    } else if (modo === 'modificar') {
      this.router.navigate(['/pacientes/modificar']);
    } else if (modo === 'baja') {
      this.router.navigate(['/pacientes/baja']);
    } else if (modo === 'historial') {
      this.router.navigate(['/pacientes/historial']);
    }
  }
}