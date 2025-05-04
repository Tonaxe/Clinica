import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: false,
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  user = {
    name: 'Tonaxe Guapo',
    role: 'odontologo' // Cambiar a 'odontologo' para probar otro menú
  };
  rol: 'administrativo' | 'odontologo' = 'administrativo';

  constructor(private router: Router) {}
  
  logout() {
    console.log('Sesión cerrada');
    this.router.navigate(['/login']);
  }
}
