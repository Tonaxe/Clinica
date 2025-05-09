import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-usuarios',
  standalone: false,
  templateUrl: './usuarios.component.html',
  styleUrl: './usuarios.component.css'
})
export class UsuariosComponent implements OnInit {
  usuarios = [
    { id: 1, nombre: 'Juan', apellido: 'Pérez', email: 'juan@dominio.com', rol: 'admin' },
    { id: 2, nombre: 'María', apellido: 'Gómez', email: 'maria@dominio.com', rol: 'odontologo' },
    { id: 3, nombre: 'Carlos', apellido: 'Sánchez', email: 'carlos@dominio.com', rol: 'odontologo' },
  ];

  constructor(private router: Router) { }

  ngOnInit(): void {
    // Aquí podrías realizar alguna inicialización si es necesario
  }

  editarUsuario(id: number): void {
    this.router.navigate([`/admin/usuarios/editar/${id}`]);
  }

  eliminarUsuario(id: number): void {
    if (confirm('¿Estás seguro de eliminar este usuario?')) {
      this.usuarios = this.usuarios.filter(usuario => usuario.id !== id);
    }
  }
}