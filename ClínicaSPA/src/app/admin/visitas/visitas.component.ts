import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../../services/api.service';
import { crearVisita, Visita } from '../../models/visit.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-visitas',
  standalone: false,
  templateUrl: './visitas.component.html',
  styleUrl: './visitas.component.css'
})
export class VisitasComponent implements OnInit {
  visitas: Visita[] = [];
  visitaForm!: FormGroup;


  constructor(private router: Router, private fb: FormBuilder, private apiService: ApiService) { }

  ngOnInit(): void {
    this.visitaForm = this.fb.group({
      paciente: ['', Validators.required],
      odontologo: ['', Validators.required],
      fecha: ['', Validators.required],
      motivo: ['', Validators.required],
      observaciones: ['']
    });

    this.apiService.getAllVisitas().subscribe(
      (response) => {
        this.visitas = response.visitas;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  agregarVisita(): void {
    if (this.visitaForm.invalid) return;

    const formValue = this.visitaForm.value;

    const visita: crearVisita = {
      paciente: formValue.paciente,
      odontologo: formValue.odontologo,
      motivo: formValue.motivo,
      observaciones: formValue.observaciones,
      fechaYhora: new Date(formValue.fecha).toISOString()
    };

    this.apiService.crearVisita(visita).subscribe(
      () => window.location.reload(),
      (error) => console.error(error)
    );
  }


  eliminarVisita(id: number): void {
    this.apiService.eliminarVisita(id).subscribe(
      (response) => {
        this.visitas = this.visitas.filter(visitas => visitas.id !== id);
      },
      (error) => {
        console.error(error);
      }
    );
  }

  editarVisita(id: number): void {
    this.router.navigate([`/admin/visitas/editar/${id}`]);
  }


  formatearFecha(fechaStr: string): string {
    const fecha = new Date(fechaStr);

    const dia = fecha.getDate();
    const mes = fecha.getMonth() + 1;
    const anio = fecha.getFullYear() % 100;
    const horas = fecha.getHours();
    const minutos = fecha.getMinutes();

    const minutosStr = minutos < 10 ? '0' + minutos : minutos;

    return `${dia}/${mes}/${anio} ${horas}:${minutosStr}h`;
  }
}