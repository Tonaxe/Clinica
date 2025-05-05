import { Component, OnInit } from '@angular/core';
import { Odontologo } from '../models/odontologo.model';

@Component({
  selector: 'app-odontologos',
  standalone: false,
  templateUrl: './odontologos.component.html',
  styleUrl: './odontologos.component.css'
})

export class OdontologosComponent {
  odontologos: Odontologo[] = [
    { id: 1, nombre: 'Carlos Pérez', especialidad: 'Ortodoncia', horarioAtencion: 'Lunes a Viernes: 8:00 - 15:00' },
    { id: 2, nombre: 'Ana Gómez', especialidad: 'Endodoncia', horarioAtencion: 'Lunes a Viernes: 9:00 - 17:00' },
    { id: 3, nombre: 'Luis Martínez', especialidad: 'Periodoncia', horarioAtencion: 'Lunes a Viernes: 10:00 - 18:00' }
  ];

  newOdontologo: Odontologo = { id: null, nombre: '', especialidad: '', horarioAtencion: '' }; // El id puede ser null inicialmente
  showForm = false;

  toggleForm() {
    this.showForm = !this.showForm;
    if (!this.showForm) {
      // Reseteamos el formulario al cerrar
      this.newOdontologo = { id: null, nombre: '', especialidad: '', horarioAtencion: '' };
    }
  }

  addOdontologo() {
    // Si es un odontólogo nuevo (id == null), lo añadimos
    if (this.newOdontologo.id === null) {
      this.newOdontologo.id = this.odontologos.length + 1; // Asignar un id único
      this.odontologos.push({ ...this.newOdontologo });
    } else {
      // Si estamos editando, actualizamos el odontólogo
      const index = this.odontologos.findIndex(o => o.id === this.newOdontologo.id);
      if (index !== -1) {
        this.odontologos[index] = { ...this.newOdontologo };
      }
    }
    this.cancelEdit(); // Cerrar el formulario
  }

  editOdontologo(index: number) {
    // Cargar el odontólogo para editarlo
    this.newOdontologo = { ...this.odontologos[index] };
    this.showForm = true;
  }

  deleteOdontologo(id: number | null) {
    if (id !== null) {
      const index = this.odontologos.findIndex(o => o.id === id);
      if (index !== -1) {
        this.odontologos.splice(index, 1); // Eliminar odontólogo
      }
    }
  }

  cancelEdit() {
    this.showForm = false;
    this.newOdontologo = { id: null, nombre: '', especialidad: '', horarioAtencion: '' }; // Resetear formulario
  }
}
