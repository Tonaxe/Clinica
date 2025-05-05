import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-paciente-gestion',
  standalone: false,
  templateUrl: './paciente-gestion.component.html',
  styleUrl: './paciente-gestion.component.css'
})

export class PacienteGestionComponent implements OnInit {
  modo: string = '';
  paciente: any = null;
  pacientes = [
    { id: 1, nombre: 'Juan Pérez', edad: 28, tipoPago: 'Efectivo', responsable: 'No Aplica', historial: [] },
    { id: 2, nombre: 'Ana López', edad: 15, tipoPago: 'Tarjeta', responsable: 'Pedro López', historial: ['Visita 1', 'Visita 2'] },
    { id: 3, nombre: 'María Gómez', edad: 34, tipoPago: 'Seguro', responsable: 'No Aplica', historial: [] }
  ];

  constructor(private route: ActivatedRoute, private router: Router) {}

  ngOnInit(): void {
    this.modo = this.route.snapshot.paramMap.get('modo') || 'alta';
    const id = +this.route.snapshot.paramMap.get('id')!;

    if (id) {
      this.paciente = this.pacientes.find(p => p.id === id);
    } else {
      this.paciente = { nombre: '', edad: null, tipoPago: '', responsable: '', historial: [] };
    }
  }

  registrarPaciente(): void {
    if (this.paciente.nombre && this.paciente.edad && this.paciente.tipoPago) {
      const nuevoPaciente = { ...this.paciente, id: this.pacientes.length + 1 };
      this.pacientes.push(nuevoPaciente);
      alert('Paciente registrado con éxito');
      this.router.navigate(['/pacientes']);
    } else {
      alert('Por favor complete todos los campos.');
    }
  }

  guardarCambios(): void {
    if (this.paciente.nombre && this.paciente.edad && this.paciente.tipoPago) {
      const index = this.pacientes.findIndex(p => p.id === this.paciente.id);
      if (index !== -1) {
        this.pacientes[index] = this.paciente;
        alert('Paciente modificado con éxito');
        this.router.navigate(['/pacientes']);
      }
    } else {
      alert('Por favor complete todos los campos.');
    }
  }

  eliminarPaciente(): void {
    const index = this.pacientes.findIndex(p => p.id === this.paciente.id);
    if (index !== -1) {
      this.pacientes.splice(index, 1);
      alert('Paciente eliminado con éxito');
      this.router.navigate(['/pacientes']);
    }
  }
}