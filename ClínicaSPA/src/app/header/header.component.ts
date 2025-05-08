import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: false,
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  user = {
    nombre: '',
    apellido: '',
    rol: '',
    imagen: ''
  };

  constructor() {}

  ngOnInit(): void {
    const userData = sessionStorage.getItem('user');
    if (userData) {
      const parsedData = JSON.parse(userData);
      console.log(parsedData);
      this.user.nombre = parsedData.nombre || 'Usuario';
      this.user.apellido = parsedData.apellido || 'Usuario';
      this.user.rol = parsedData.rol || 'odontologo';
      this.user.imagen = parsedData.imagen || '';
    }
  }

  logout() {
    sessionStorage.clear();
  }
}
