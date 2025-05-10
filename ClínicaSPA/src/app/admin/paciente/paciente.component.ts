import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-paciente',
  standalone: false,
  templateUrl: './paciente.component.html',
  styleUrl: './paciente.component.css'
})
export class PacienteComponent implements OnInit {
  
    pacientes = [
    {
      id: 1,
      nombre: 'Juan',
      apellido: 'Pérez',
      fechaNacimiento: '1990-06-15',
      telefono: '123-456-789',
      email: 'juan.perez@mail.com',
      tipoPago: 'PARTICULAR',
      responsable: null,
      imagen: 'https://via.placeholder.com/80'
    },
    {
      id: 2,
      nombre: 'María',
      apellido: 'González',
      fechaNacimiento: '2010-03-22',
      telefono: '987-654-321',
      email: 'maria.gonzalez@mail.com',
      tipoPago: 'MUTUA',
      responsable: {
        nombre: 'Carlos González',
        parentesco: 'Padre',
        telefono: '987-654-000',
        email: 'carlos.gonzalez@mail.com'
      },
      imagen: 'https://via.placeholder.com/80'
    },
  ];

  constructor() { }

  ngOnInit(): void {
  }

  eliminarPaciente(id: number): void {
    this.pacientes = this.pacientes.filter(paciente => paciente.id !== id);
  }

  editarPaciente(id: number): void {
    console.log('Editar paciente con id:', id);
  }
}