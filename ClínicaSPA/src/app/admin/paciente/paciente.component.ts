import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from '../../services/api.service';
import { Paciente } from '../../models/paciente.model';

@Component({
  selector: 'app-paciente',
  standalone: false,
  templateUrl: './paciente.component.html',
  styleUrl: './paciente.component.css'
})
export class PacienteComponent implements OnInit {
  pacientes: any[] = [];

  constructor(private apiService: ApiService, private router: Router) { }

  ngOnInit(): void {
    this.apiService.getAllPacientes().subscribe({
      next: (res) => {
        this.pacientes = res.pacientes;
      },
      error: (err) => {
        console.error('Error al obtener pacientes:', err);
      }
    });
  }

  eliminarPaciente(id: number): void {
    this.apiService.deletePaciente(id).subscribe(
      (res) => {
        this.pacientes = this.pacientes.filter(paciente => paciente.id !== id);
      },
      (error) => {
        console.error(error);
      }
    );
  }

  editarPaciente(id: number): void {
    this.router.navigate([`/admin/pacientes/editar/${id}`]);
  }

  irANuevoPaciente(): void {
    this.router.navigate(['/admin/pacientes/nuevo-paciente']);
  }
}
