import { Component, OnInit,  ViewChild, ElementRef } from '@angular/core';
import { ApiService } from '../services/api.service';
import { Router } from '@angular/router';

@Component({
  standalone: false,
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
//holagit

export class HomeComponent implements OnInit {
  user = {
    name: 'Tonaxe Guapo',
    role: 'odontologo' // El rol vendría de la sesión o de un servicio
  };

  constructor(private apiService: ApiService, private router: Router) {}

  ngOnInit(): void {
    // Aquí puedes cargar los datos del usuario, si es necesario
    // ejemplo: this.user = this.apiService.getUserData();
  }
}