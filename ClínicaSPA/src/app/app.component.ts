import { Component} from '@angular/core';
import { Router } from '@angular/router';

@Component({
  standalone: false,
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent{
  title = 'Clínica';

  constructor(private router: Router) {
  }

  shouldShowHeader(): boolean {
    const isLoginPage = this.router.url === '/login';
    return !isLoginPage;
  }
}
