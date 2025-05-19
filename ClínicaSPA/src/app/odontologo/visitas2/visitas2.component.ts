import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Visita } from '../../models/visit.model';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-visitas2',
  standalone: false,
  templateUrl: './visitas2.component.html',
  styleUrl: './visitas2.component.css'
})
export class Visitas2Component implements OnInit {
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

    const userId = JSON.parse(sessionStorage.getItem('user') || '{}')?.id;

    this.apiService.getAllVisitasByOdontologo(userId).subscribe(
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
    this.apiService.crearVisita(this.visitaForm.value).subscribe(
      (response) => {
        window.location.reload();
      },
      (error) => {
        console.error(error);
      }
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