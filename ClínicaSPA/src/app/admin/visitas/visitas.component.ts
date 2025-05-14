import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../../services/api.service';
import { Visita } from '../../models/visit.model';
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
 

  constructor(private router: Router ,private fb: FormBuilder, private apiService: ApiService) {}

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

    const nuevaVisita = {
      id: this.visitas.length + 1,
      ...this.visitaForm.value
    };

    this.visitas.unshift(nuevaVisita);
    this.visitaForm.reset();
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
}
