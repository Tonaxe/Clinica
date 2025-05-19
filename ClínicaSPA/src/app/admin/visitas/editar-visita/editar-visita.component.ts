import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from '../../../services/api.service';

@Component({
  selector: 'app-editar-visita',
  standalone: false,
  templateUrl: './editar-visita.component.html',
  styleUrl: './editar-visita.component.css'
})
export class EditarVisitaComponent implements OnInit {

  visitaForm: FormGroup;
  visitaId!: number;

  constructor(
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private apiService: ApiService,
    private router: Router
  ) {
    this.visitaForm = this.fb.group({
      fecha_hora: ['', Validators.required],
      motivo: ['', Validators.required],
      observaciones: [''],
      tratamiento_prescrito: [''],
      paciente_nombre: [''],
      paciente_apellido: [''],
      odontologo_nombre: [''],
      odontologo_apellido: ['']
    });
  }

  ngOnInit(): void {
    this.visitaId = Number(this.route.snapshot.paramMap.get('id'));
    this.cargarDatosVisita(this.visitaId);
  }

  cargarDatosVisita(id: number): void {
    this.apiService.getVisitaById(id).subscribe({
      next: (data: any) => {
        this.visitaForm.patchValue({
          fecha_hora: this.toLocalDateTime(data.fecha_hora),
          motivo: data.motivo,
          observaciones: data.observaciones,
          tratamiento_prescrito: data.tratamiento_prescrito,
          paciente_nombre: data.paciente.nombre,
          paciente_apellido: data.paciente.apellido,
          odontologo_nombre: data.odontologo.nombre,
          odontologo_apellido: data.odontologo.apellido
        });
      },
      error: (err) => {
        console.error('Error al cargar la visita:', err);
      }
    });
  }

  toLocalDateTime(fecha: string): string {
    const date = new Date(fecha);
    const tzOffset = date.getTimezoneOffset() * 60000;
    return new Date(date.getTime() - tzOffset).toISOString().slice(0, 16);
  }

  onSubmit(): void {
    if (this.visitaForm.valid) {
      const visitaActualizada = {
        paciente_id: this.visitaId,
        fecha_hora: new Date(this.visitaForm.value.fecha_hora).toISOString(),
        motivo: this.visitaForm.value.motivo,
        observaciones: this.visitaForm.value.observaciones,
        tratamiento_prescrito: this.visitaForm.value.tratamiento_prescrito
      };

      this.apiService.updateVisita(this.visitaId, visitaActualizada).subscribe({
        next: () => {
          this.router.navigate(['/admin/visitas']);
        },
        error: (err) => {
          console.error('Error al guardar la visita:', err);
        }
      });
    }
  }

  cancelar(): void {
    this.router.navigate(['/admin/visitas']);
  }
}