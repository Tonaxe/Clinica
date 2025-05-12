import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './admin/dashboard/dashboard.component';
import { UsuariosComponent } from './admin/usuarios/usuarios.component';
import { UsarioEditarComponent } from './admin/usuarios/usario-editar/usario-editar.component';
import { NuevoUsuarioComponent } from './admin/usuarios/nuevo-usuario/nuevo-usuario.component';
import { PacienteComponent } from './admin/paciente/paciente.component';
import { VisitasComponent } from './admin/visitas/visitas.component';
import { NuevoPacienteComponent } from './admin/paciente/nuevo-paciente/nuevo-paciente.component';

export const routes: Routes = [
    { path: 'admin/dashboard', component: DashboardComponent },
    { path: 'admin/usuarios', component: UsuariosComponent },
    { path: 'admin/usuarios/editar/:id', component: UsarioEditarComponent },
    { path: 'admin/usuarios/nuevo', component: NuevoUsuarioComponent },
    { path: 'admin/pacientes', component: PacienteComponent },
    { path: 'login', component: LoginComponent },
    { path: 'admin/visitas', component: VisitasComponent },
    {path: 'admin/pacientes/nuevo-paciente', component: NuevoPacienteComponent},
    { path: '', redirectTo: '/login', pathMatch: 'full' }
];
