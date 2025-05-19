import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { VisitaEditarRequest } from '../../../models/visit.model';
import { ApiService } from '../../../services/api.service';

@Component({
  selector: 'app-editar-visitas2',
  standalone: false,
  templateUrl: './editar-visitas2.component.html',
  styleUrl: './editar-visitas2.component.css'
})
export class EditarVisitas2Component implements OnInit {

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
      paciente: ['', Validators.required],
      odontologo: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.visitaId = Number(this.route.snapshot.paramMap.get('id'));
    this.cargarDatosVisita(this.visitaId);
  }

  cargarDatosVisita(id: number): void {
    this.apiService.getVisitaById(id).subscribe({
      next: (response: any) => {
        const data = response.visitas;

        this.visitaForm.patchValue({
          fecha_hora: this.toLocalDateTime(data.fecha_hora),
          motivo: data.motivo,
          observaciones: data.observaciones,
          tratamiento_prescrito: data.tratamiento_prescrito,
          paciente: data.paciente.nombre + " " + data.paciente.apellido,
          odontologo: data.odontologo.nombre + " " + data.odontologo.apellido,
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
      const raw = this.visitaForm.getRawValue();
      const visitaActualizada: VisitaEditarRequest = {
        paciente: typeof raw.paciente === 'string' ? raw.paciente.split(' ')[0] : raw.paciente,
        odontologo: typeof raw.odontologo === 'string' ? raw.odontologo.split(' ')[0] : raw.odontologo,
        fechaYhora: new Date(this.visitaForm.value.fecha_hora).toISOString(),
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