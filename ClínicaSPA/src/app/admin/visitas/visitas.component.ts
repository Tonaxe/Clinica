import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-visitas',
  standalone: false,
  templateUrl: './visitas.component.html',
  styleUrl: './visitas.component.css'
})
export class VisitasComponent implements OnInit {
  visitas: any[] = [];
  visitaForm!: FormGroup;

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    this.visitaForm = this.fb.group({
      paciente: ['', Validators.required],
      odontologo: ['', Validators.required],
      fecha: ['', Validators.required],
      motivo: ['', Validators.required],
      observaciones: ['']
    });

    // Datos simulados
    this.visitas = [
      {
        id: 1,
        paciente: 'Juan Pérez',
        odontologo: 'Dra. Ramírez',
        fecha: '2025-05-11',
        motivo: 'Revisión general',
        observaciones: 'Sin problemas detectados.'
      }
    ];
  }

  agregarVisita(): void {
    if (this.visitaForm.invalid) return;

    const nuevaVisita = {
      id: this.visitas.length + 1,
      ...this.visitaForm.value
    };

    this.visitas.unshift(nuevaVisita);
    this.visitaForm.reset();
  }

  eliminarVisita(id: number): void {
    this.visitas = this.visitas.filter(v => v.id !== id);
  }

  editarVisita(id: number): void {
    console.log(`Editar visita con ID ${id}`);
  }
}
