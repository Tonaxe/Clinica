import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './admin/dashboard/dashboard.component';
import { UsuariosComponent } from './admin/usuarios/usuarios.component';
import { UsarioEditarComponent } from './admin/usuarios/usario-editar/usario-editar.component';
import { NuevoUsuarioComponent } from './admin/usuarios/nuevo-usuario/nuevo-usuario.component';
import { PacienteComponent } from './admin/paciente/paciente.component';
import { VisitasComponent } from './admin/visitas/visitas.component';
import { NuevoPacienteComponent } from './admin/paciente/nuevo-paciente/nuevo-paciente.component';
import { PerfilComponent } from './admin/perfil/perfil.component';
import { PacienteEditarComponent } from './admin/paciente/paciente-editar/paciente-editar.component';
import { EditarVisitaComponent } from './admin/visitas/editar-visita/editar-visita.component';

export const routes: Routes = [
    { path: 'admin/dashboard', component: DashboardComponent },
    { path: 'admin/usuarios', component: UsuariosComponent },
    { path: 'admin/usuarios/editar/:id', component: UsarioEditarComponent },
    { path: 'admin/usuarios/nuevo', component: NuevoUsuarioComponent },
    { path: 'admin/pacientes', component: PacienteComponent },
    { path: 'admin/pacientes/editar/:id', component: PacienteEditarComponent },
    { path: 'login', component: LoginComponent },
    { path: 'admin/visitas', component: VisitasComponent },
    { path: 'admin/pacientes/nuevo-paciente', component: NuevoPacienteComponent },
    { path: 'admin/perfil', component: PerfilComponent },
    { path: 'admin/visitas/editar/:id', component: EditarVisitaComponent },
    { path: '', redirectTo: '/login', pathMatch: 'full' }
];
