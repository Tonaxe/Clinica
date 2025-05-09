import { Component } from '@angular/core';
import { User } from '../../models/logIn.model';

@Component({
  selector: 'app-dashboard',
  standalone: false,
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent {
  user: User = {
    id: 0,
    nombre: '',
    apellido: '',
    email: '',
    rol: '',
    imagen: '',
  };

  ngOnInit(): void {
    const userData = sessionStorage.getItem('user');
    if (userData) {
      this.user = JSON.parse(userData);
    }
  }
}
