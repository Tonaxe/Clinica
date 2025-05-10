import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from '../../../services/api.service';
import { User } from '../../../models/user.model';

@Component({
  selector: 'app-usario-editar',
  standalone: false,
  templateUrl: './usario-editar.component.html',
  styleUrl: './usario-editar.component.css'
})
export class UsarioEditarComponent implements OnInit {

  userForm: FormGroup;
  userId: number;
  imageUrl: string | ArrayBuffer | null = null;
  originalImageBase64: string | null = null;

  constructor(
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private apiService: ApiService,
    private router: Router
  ) {
    this.userForm = this.fb.group({
      nombre: ['', Validators.required],
      apellido: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      rol: ['', Validators.required],
      imagen: ['']
    });
    this.userId = 0;
  }

  ngOnInit(): void {
    this.userId = Number(this.route.snapshot.paramMap.get('id'));
    this.apiService.getUserById(this.userId).subscribe((res: any) => {
      const user = res.usuario[0];
      this.userForm.patchValue({
        nombre: user.nombre || '',
        apellido: user.apellido || '',
        email: user.email || '',
        rol: user.rol || '',
        imagen: user.imagen || ''
      });

      if (user.imagen) {
        this.originalImageBase64 = user.imagen;
        this.imageUrl = 'data:image/jpeg;base64,' + user.imagen;
      }
    });
  }

  guardar(): void {
    if (this.userForm.valid) {
      const user: User = {
        id: this.userId,
        nombre: this.userForm.value.nombre,
        apellido: this.userForm.value.apellido,
        email: this.userForm.value.email,
        rol: this.userForm.value.rol,
        imagen: this.userForm.value.imagen,
      };
      this.apiService.updateUser(user).subscribe(() => {
        this.router.navigate(['/admin/usuarios']);
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
      };
      reader.readAsDataURL(file);
    }
  }

  cancelar(): void {
    this.router.navigate(['/admin/usuarios']);
  }
}