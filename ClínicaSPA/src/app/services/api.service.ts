import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LogInRequest, LogInResponse } from '../models/logIn.model';
import { AllUsersResponse } from '../models/allUsers.model';
import { User } from '../models/user.model';
import { CreateUser } from '../models/register.model';
import { Paciente, PacienteResponse } from '../models/paciente.model';
import { crearVisita, Visita, VisitaEditarRequest, VisitaResponse } from '../models/visit.model';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private baseUrl = 'https://localhost:44355/api/Clinica/';
  private headers = { 'Content-Type': 'application/json' };

  constructor(private http: HttpClient) { }

  logIn(logInRequest: LogInRequest): Observable<LogInResponse> {
    return this.http.post<LogInResponse>(`${this.baseUrl}login`, logInRequest, { headers: this.headers });
  }

  logOut(logOutRequest: string): Observable<string> {
    return this.http.post<string>(`${this.baseUrl}logout`, JSON.stringify(logOutRequest), { headers: this.headers });
  }

  getAllUsers(): Observable<AllUsersResponse> {
    return this.http.get<AllUsersResponse>(`${this.baseUrl}usuarios`, { headers: this.headers });
  }

  getUserById(id: number): Observable<User> {
    return this.http.get<User>(`${this.baseUrl}usuario/` + id, { headers: this.headers });
  }

  updateUser(user: User): Observable<User> {
    return this.http.patch<User>(`${this.baseUrl}editarUsuario`, user, { headers: this.headers });
  }

  deleteUser(id: number): Observable<boolean> {
    return this.http.delete<boolean>(`${this.baseUrl}eliminarUsuario/${id}`, { headers: this.headers });
  }

  crearUsuario(user: CreateUser): Observable<boolean> {
    return this.http.post<boolean>(`${this.baseUrl}crearUsuario`, user, { headers: this.headers });
  }

  getAllPacientes(): Observable<PacienteResponse> {
    return this.http.get<PacienteResponse>(`${this.baseUrl}pacientes`, { headers: this.headers });
  }

  crearPaciente(paciente: Paciente): Observable<boolean> {
    return this.http.post<boolean>(`${this.baseUrl}crearPaciente`, paciente, { headers: this.headers, });
  }

  deletePaciente(id: number): Observable<boolean> {
    return this.http.delete<boolean>(`${this.baseUrl}eliminarPaciente/${id}`, { headers: this.headers });
  }

  getPacienteById(id: number): Observable<Paciente> {
    return this.http.get<Paciente>(`${this.baseUrl}paciente/` + id, { headers: this.headers });
  }

  updatePaciente(user: Paciente): Observable<Paciente> {
    return this.http.patch<Paciente>(`${this.baseUrl}editarPaciente`, user, { headers: this.headers });
  }

  getAllVisitas(): Observable<VisitaResponse> {
    return this.http.get<VisitaResponse>(`${this.baseUrl}visitas`, { headers: this.headers });
  }

  eliminarVisita(id: number): Observable<boolean> {
    return this.http.delete<boolean>(`${this.baseUrl}visitas/${id}`, { headers: this.headers });
  }

  crearVisita(visita: crearVisita): Observable<boolean> {
    return this.http.post<boolean>(`${this.baseUrl}visitas`, visita, { headers: this.headers, });
  }

  getVisitaById(id: number): Observable<VisitaResponse> {
    return this.http.get<VisitaResponse>(`${this.baseUrl}visitas/${id}`, { headers: this.headers });
  }

  updateVisita(id: number, visitaActualizada: VisitaEditarRequest): Observable<VisitaEditarRequest> {
    return this.http.put<VisitaEditarRequest>(`${this.baseUrl}visitas/${id}`, visitaActualizada, {headers: this.headers});
  }

  getAllVisitasByOdontologo(odontologo_id: number): Observable<VisitaResponse> {
    return this.http.get<VisitaResponse>(`${this.baseUrl}visitas/odontolog/${odontologo_id}`, { headers: this.headers });
  }
}