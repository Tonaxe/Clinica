import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { OdontologosComponent } from './odontologos/odontologos.component';
import { PacienteComponent } from './paciente/paciente.component';
import { PacienteGestionComponent } from './paciente-gestion/paciente-gestion.component';

export const routes: Routes = [
    { path: 'home', component: HomeComponent },
    { path: 'odontologos', component: OdontologosComponent },
    { path: 'paciete', component: PacienteComponent },
    { path: 'login', component: LoginComponent },
    { path: 'pacientes/:modo', component: PacienteGestionComponent },
    { path: 'pacientes/:modo/:id', component: PacienteGestionComponent },
    { path: '', redirectTo: '/login', pathMatch: 'full' }
];
