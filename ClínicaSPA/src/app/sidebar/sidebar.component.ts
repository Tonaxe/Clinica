import { Component, Input } from '@angular/core';
import { User } from '../models/user.model';

@Component({
  selector: 'app-sidebar',
  standalone: false,
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.css'
})
export class SidebarComponent {
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
