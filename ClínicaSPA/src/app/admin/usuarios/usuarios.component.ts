import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../../models/user.model';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-usuarios',
  standalone: false,
  templateUrl: './usuarios.component.html',
  styleUrl: './usuarios.component.css'
})
export class UsuariosComponent implements OnInit {

  usuarios: User[] = [];

  constructor(private router: Router, private apiService: ApiService) { }

  ngOnInit(): void {
    this.apiService.getAllUsers().subscribe(
      (res) => {
        this.usuarios = res.usuarios;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  editarUsuario(id: number): void {
    this.router.navigate([`/admin/usuarios/editar/${id}`]);
  }

  eliminarUsuario(id: number): void {
    this.apiService.deleteUser(id).subscribe(
      (res) => {
        this.usuarios = this.usuarios.filter(usuario => usuario.id !== id);
      },
      (error) => {
        console.error(error);
      }
    );
  }
}