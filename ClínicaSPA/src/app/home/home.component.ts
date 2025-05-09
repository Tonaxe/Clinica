import { Component, OnInit,  ViewChild, ElementRef } from '@angular/core';

@Component({
  standalone: false,
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {
  user = {
    nombre: '',
    apellido: '',
    rol: '',
  };

  stats = {
    pacientes: 152,
    odontologos: 7,
    visitasHoy: 18
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
    }
  }
}