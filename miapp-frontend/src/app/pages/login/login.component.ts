import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html'
})
export class LoginComponent {
  private authService = inject(AuthService);
  private router = inject(Router);

  username = '';
  password = '';
  errorMessage = '';

  onSubmit(): void {
    if (!this.username.trim() || !this.password.trim()) {
      this.errorMessage = 'Por favor ingresa usuario y contraseña';
      return;
    }

    this.authService.login({ username: this.username, password: this.password }).subscribe({
      next: () => {
        this.errorMessage = '';
        this.router.navigate(['/home'], { replaceUrl: true });
      },
      error: (err) => {
        this.errorMessage = err.error?.message || 'Usuario o contraseña inválidos';
      }
    });
  }
}
