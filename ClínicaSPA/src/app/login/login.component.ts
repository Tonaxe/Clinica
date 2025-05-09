import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../services/api.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm: FormGroup;

  constructor(private fb: FormBuilder, private apiService: ApiService, private router: Router) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]]
    });
  }

  onSubmit() {
    if (this.loginForm.valid) {
      const form = {
        email: this.loginForm.value.email,
        password: this.loginForm.value.password
      };

      this.apiService.logIn(form).subscribe(
        (res) => {
          sessionStorage.setItem('user', JSON.stringify(res.user));
          if (res.user.rol === 'admin') {
            this.router.navigate(['/admin/dashboard']);
          }  
          else if (res.user.rol === 'odontologo') {
            this.router.navigate(['/odontologo/dashboard']);
          }
        },
        (error) => {
          console.error('Error de login', error);
        }
      );
    } else {
      console.log('Formulario inválido');
    }
  }
}
