import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../../../services/api.service';
import { Router } from '@angular/router';
import { Paciente } from '../../../models/paciente.model';

@Component({
  selector: 'app-nuevo-paciente',
  standalone: false,
  templateUrl: './nuevo-paciente.component.html',
  styleUrls: ['./nuevo-paciente.component.css']
})
export class NuevoPacienteComponent implements OnInit {
  pacienteForm!: FormGroup;
  imageUrl: string | ArrayBuffer | null = null;

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
      esMenorEdad: [false],
      responsable_nombre: [''],
      responsable_apellido: [''],
      responsable_email: [''],
      imagen: [''],
    });

    this.pacienteForm.get('esMenorEdad')?.valueChanges.subscribe((isMinor) => {
      this.toggleResponsableValidators(isMinor);
    });
  }

  onImageSelected(event: Event): void {
    const file = (event.target as HTMLInputElement).files?.[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = () => {
        const result = reader.result as string;
        const base64SinEncabezado = result.replace(/^data:image\/[a-z]+;base64,/, '');

        this.imageUrl = result;
        this.pacienteForm.patchValue({ imagen: base64SinEncabezado });
      };
      reader.readAsDataURL(file);
    }
  }

  toggleResponsableValidators(isMinor: boolean): void {
    if (isMinor) {
      this.pacienteForm.get('responsable_nombre')?.setValidators([Validators.required]);
      this.pacienteForm.get('responsable_apellido')?.setValidators([Validators.required]);
      this.pacienteForm.get('responsable_email')?.setValidators([Validators.required, Validators.email]);
    } else {
      this.pacienteForm.get('responsable_nombre')?.clearValidators();
      this.pacienteForm.get('responsable_apellido')?.clearValidators();
      this.pacienteForm.get('responsable_email')?.clearValidators();
    }
    this.pacienteForm.get('responsable_nombre')?.updateValueAndValidity();
    this.pacienteForm.get('responsable_apellido')?.updateValueAndValidity();
    this.pacienteForm.get('responsable_email')?.updateValueAndValidity();
  }

  onSubmit(): void {
    if (this.pacienteForm.valid) {
      const telefonoString = this.pacienteForm.value.telefono.toString();
      const formValue = { ...this.pacienteForm.value, telefono: telefonoString };
      delete formValue.esMenorEdad;

      this.apiService.crearPaciente(formValue).subscribe({
        next: () => {
          this.router.navigate(['admin/pacientes']);
        },
        error: (err) => {
          console.error('Error al crear paciente:', err);
        }
      });
    }
  }

  cancelar(): void {
    this.router.navigate(['admin/pacientes']);
  }
}
