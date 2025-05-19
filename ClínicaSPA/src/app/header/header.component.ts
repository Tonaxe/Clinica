import { Component, HostListener, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: false,
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  showDropdown = false;
  user = {
    nombre: '',
    apellido: '',
    rol: '',
    imagen: ''
  };

  constructor(private router: Router) {}

  ngOnInit(): void {
    const userData = sessionStorage.getItem('user');
    if (userData) {
      const parsedData = JSON.parse(userData);
      this.user.nombre = parsedData.nombre || 'Usuario';
      this.user.apellido = parsedData.apellido || 'Usuario';
      this.user.rol = parsedData.rol || 'odontologo';
      this.user.imagen = parsedData.imagen || '';
    }
  }

  logout() {
    sessionStorage.clear();
  }
 toggleDropdown() {
  console.log('Toggle clicked');
  this.showDropdown = !this.showDropdown;
}



editarPerfil() {
  if (this.user.rol === 'admin') {
    this.router.navigate(['/admin/perfil']);
  } 
  else if (this.user.rol === 'odontologo') {
    this.router.navigate(['/odontologo/perfil']);
  }
  else {
    console.warn('Rol desconocido:', this.user.rol);
   
    this.router.navigate(['/login']);
  }

  this.showDropdown = false; 
}

 cerrarSesion() {
  sessionStorage.clear();
  this.router.navigate(['/login']);
}


}
