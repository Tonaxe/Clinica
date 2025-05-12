import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../../../services/api.service';
import { Router } from '@angular/router';
import { Paciente } from '../../../models/paciente.model';

@Component({
  selector: 'app-nuevo-paciente',
  standalone: false,
  templateUrl: './nuevo-paciente.component.html',
  styleUrls: ['./nuevo-paciente.component.css'] // corregido también aquí (plural)
})
export class NuevoPacienteComponent implements OnInit {
  pacienteForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private apiService: ApiService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.pacienteForm = this.fb.group({
      nombre: ['', Validators.required],
      apellido: ['', Validators.required],
      fecha_nacimiento: ['', Validators.required],
      telefono: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      tipo_pago: ['PARTICULAR', Validators.required],
      responsable_id: [null]
    });
  }

  onSubmit(): void {
    if (this.pacienteForm.valid) {
      const nuevoPaciente: Paciente = this.pacienteForm.value;
      this.apiService.crearPaciente(nuevoPaciente).subscribe({
        next: () => {
          this.router.navigate(['admin/pacientes']);
        },
        error: (err) => {
          console.error('Error al crear paciente:', err);
        }
      });
    } else {
    }
  }

  cancelar(): void {
    this.router.navigate(['admin/pacientes']);
  }
}
