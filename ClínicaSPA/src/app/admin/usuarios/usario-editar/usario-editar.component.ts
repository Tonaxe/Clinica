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
    this.apiService.getUserById(this.userId).subscribe((res: User) => {
      this.userForm.patchValue(res);
    });
  }

  guardar(): void {
    // if (this.userForm.valid) {
    //   this.apiService.updateUser(this.userId, this.userForm.value).subscribe(() => {
    //     alert('Usuario actualizado correctamente');
    //     this.router.navigate(['/admin/usuarios']);
    //   });
    // }
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