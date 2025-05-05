import { Component, OnInit,  ViewChild, ElementRef } from '@angular/core';

@Component({
  standalone: false,
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {
  user = {
    name: 'Tonaxe Guapo',
    role: 'admin'
  };

  stats = {
    pacientes: 152,
    odontologos: 7,
    visitasHoy: 18
  };

  constructor() {}

  ngOnInit(): void {
  }
}