import { Component, OnInit } from '@angular/core';
import { User } from '../../models/user.model';
import { Router } from '@angular/router';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-perfil',
  standalone: false,
  templateUrl: './perfil.component.html',
  styleUrl: './perfil.component.css'
})
export class PerfilComponent implements OnInit{
 usuario: User = {
    id: 0,
    nombre: '',
    apellido: '',
    email: '',
    rol: '',
    imagen: ''
  };

  editando: boolean = false;

  constructor(private apiService: ApiService, private router: Router){}

  ngOnInit(): void {
    const userData = sessionStorage.getItem('user');
    if (userData) {
      const parsedData = JSON.parse(userData);
      this.usuario.id = parsedData.id || 0;
      this.usuario.nombre = parsedData.nombre || 'Usuario';
      this.usuario.apellido = parsedData.apellido || 'Usuario';
      this.usuario.email = parsedData.email || 'usuario@gmaiil.com';
      this.usuario.rol = parsedData.rol || 'odontologo';
      this.usuario.imagen = parsedData.imagen || '';
    }
  }

  onFileSelected(event: Event): void {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files.length > 0) {
      const reader = new FileReader();
      reader.onload = () => {
        this.usuario.imagen = (reader.result as string).split(',')[1];
      };
      reader.readAsDataURL(input.files[0]);
    }
  }

  guardarCambios(): void {
    this.editando = false;
    if (this.usuario !== null) {
      this.apiService.updateUser(this.usuario).subscribe(() => {
        sessionStorage.setItem('user', JSON.stringify(this.usuario));
        window.location.reload();
        this.router.navigate(['admin/perfil']);
      });
    }
  }
}