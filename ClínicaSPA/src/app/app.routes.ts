import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './admin/dashboard/dashboard.component';
import { UsuariosComponent } from './admin/usuarios/usuarios.component';
import { UsarioEditarComponent } from './admin/usuarios/usario-editar/usario-editar.component';

export const routes: Routes = [
    { path: 'admin/dashboard', component: DashboardComponent },
    { path: 'admin/usuarios', component: UsuariosComponent },
    { path: 'admin/usuarios/editar/:id', component: UsarioEditarComponent },
    { path: 'login', component: LoginComponent },
    { path: '', redirectTo: '/login', pathMatch: 'full' }
];
