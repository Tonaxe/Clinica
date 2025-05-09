import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LogInRequest, LogInResponse } from '../models/logIn.model';
import { AllUsersResponse } from '../models/allUsers.model';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private baseUrl = 'https://localhost:44355/api/Clinica/';
  private headers = { 'Content-Type': 'application/json' };

  constructor(private http: HttpClient) { }

  logIn(logInRequest: LogInRequest): Observable<LogInResponse> {
    return this.http.post<LogInResponse>(`${this.baseUrl}login`, logInRequest);
  }

  logOut(logOutRequest: string): Observable<string> {
    return this.http.post<string>(`${this.baseUrl}logout`, JSON.stringify(logOutRequest), { headers : this.headers });
  }

  getAllUsers(): Observable<AllUsersResponse> {
    return this.http.get<AllUsersResponse>(`${this.baseUrl}usuarios`, { headers: this.headers });
  }

  getUserById(id: number): Observable<User> {
    return this.http.get<User>(`${this.baseUrl}usuario/` + id, { headers: this.headers });
  }
}