import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { routes } from './app.routes';
import { FormsModule } from '@angular/forms'; 
import { HttpClientModule } from '@angular/common/http';
import { HeaderComponent } from './header/header.component';
import { LoginComponent } from './login/login.component';
import { SidebarComponent } from './sidebar/sidebar.component';
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

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    LoginComponent,
    SidebarComponent,
    DashboardComponent,
    UsuariosComponent,
    UsarioEditarComponent,
    NuevoUsuarioComponent,
    PacienteComponent,
    VisitasComponent,
    NuevoPacienteComponent,
    PerfilComponent,
    PacienteEditarComponent,
    EditarVisitaComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes),
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
