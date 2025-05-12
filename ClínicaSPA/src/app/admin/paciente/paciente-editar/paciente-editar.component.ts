import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from '../../../services/api.service';
import { Paciente } from '../../../models/paciente.model';

@Component({
  selector: 'app-paciente-editar',
  standalone: false,
  templateUrl: './paciente-editar.component.html',
  styleUrls: ['./paciente-editar.component.css']
})
export class PacienteEditarComponent implements OnInit {

  pacienteForm: FormGroup;
  pacienteId: number;
  imageUrl: string | ArrayBuffer | null = null;
  originalImageBase64: string | null = null;

  constructor(
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private apiService: ApiService,
    private router: Router
  ) {
    this.pacienteForm = this.fb.group({
      nombre: ['', Validators.required],
      apellido: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      telefono: ['', Validators.required],
      fecha_nacimiento: ['', Validators.required],
      tipo_pago: ['', Validators.required],
      esMenorEdad: [false],
      responsable_nombre: [''],
      responsable_apellido: [''],
      responsable_email: [''],
      imagen: ['']
    });
    this.pacienteId = 0;
  }

  ngOnInit(): void {
    this.pacienteId = Number(this.route.snapshot.paramMap.get('id'));
    this.apiService.getPacienteById(this.pacienteId).subscribe((res: any) => {
      console.log(res);
      const paciente = res.pacientes[0];
      this.pacienteForm.patchValue({
        nombre: paciente.nombre || '',
        apellido: paciente.apellido || '',
        email: paciente.email || '',
        telefono: paciente.telefono || '',
        fecha_nacimiento: paciente.fecha_nacimiento || '',
        tipo_pago: paciente.tipo_pago || '',
        responsable_nombre: paciente.responsable_nombre || '',
        responsable_apellido: paciente.responsable_apellido || '',
        responsable_email: paciente.responsable_email || '',
        imagen: paciente.imagen || '',
        esMenorEdad: !!(paciente.responsable_nombre || paciente.responsable_email)
      });

      if (paciente.imagen) {
        this.originalImageBase64 = paciente.imagen;
        this.imageUrl = 'data:image/jpeg;base64,' + paciente.imagen;
      }
    });
  }

  onSubmit(): void {
    if (this.pacienteForm.valid) {
      const paciente: Paciente = {
        id: this.pacienteId,
        nombre: this.pacienteForm.value.nombre,
        apellido: this.pacienteForm.value.apellido,
        email: this.pacienteForm.value.email,
        telefono: this.pacienteForm.value.telefono.toString(),
        fecha_nacimiento: this.pacienteForm.value.fecha_nacimiento,
        tipo_pago: this.pacienteForm.value.tipo_pago,
        responsable_nombre: this.pacienteForm.value.esMenorEdad ? this.pacienteForm.value.responsable_nombre : '',
        responsable_apellido: this.pacienteForm.value.esMenorEdad ? this.pacienteForm.value.responsable_apellido : '',
        responsable_email: this.pacienteForm.value.esMenorEdad ? this.pacienteForm.value.responsable_email : '',
        imagen: this.pacienteForm.value.imagen,
      };

      this.apiService.updatePaciente(paciente).subscribe(() => {
        this.router.navigate(['/admin/pacientes']);
      });
    }
  }

  onImageSelected(event: Event): void {
    const input = event.target as HTMLInputElement;
    if (input && input.files && input.files[0]) {
      const file = input.files[0];
      const reader = new FileReader();
      reader.onload = () => {
        this.imageUrl = reader.result;
        this.pacienteForm.patchValue({ imagen: (reader.result as string).split(',')[1] });
      };
      reader.readAsDataURL(file);
    }
  }

  cancelar(): void {
    this.router.navigate(['/admin/pacientes']);
  }
}
