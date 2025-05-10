import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../../../services/api.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nuevo-usuario',
  standalone: false,
  templateUrl: './nuevo-usuario.component.html',
  styleUrl: './nuevo-usuario.component.css'
})
export class NuevoUsuarioComponent {
  userForm: FormGroup;
  imageUrl: string | ArrayBuffer | null = null;
  imageBase64: string = '';

  constructor(
    private fb: FormBuilder,
    private apiService: ApiService,
    private router: Router
  ) {
    this.userForm = this.fb.group({
      nombre: ['', Validators.required],
      apellido: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      contrasena: ['', Validators.required],
      rol: ['', Validators.required],
      imagen: ['']
    });
  }

  guardar(): void {
    if (this.userForm.invalid) return;

    const payload = {
      ...this.userForm.value,
      imagen: this.imageBase64
    };

    this.apiService.crearUsuario(payload).subscribe((res: any) => {
      this.router.navigate(['admin/usuarios']);
    });
  }

  onImageSelected(event: Event): void {
    const input = event.target as HTMLInputElement;
    if (!input.files || !input.files[0]) return;

    const file = input.files[0];
    const reader = new FileReader();
    reader.onload = () => {
      this.imageUrl = reader.result;
      this.imageBase64 = (reader.result as string)
        .split(',')[1] ?? '';
    };
    reader.readAsDataURL(file);
  }
  cancelar(): void {
    this.router.navigate(['admin/usuarios']);
  }
}