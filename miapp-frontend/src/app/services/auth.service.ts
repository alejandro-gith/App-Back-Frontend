import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable, tap } from 'rxjs';
import { environment } from '../../environments/environment';
import { LoginRequest, LoginResponse, LogoutResponse } from '../models/auth.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private http = inject(HttpClient);
  private router = inject(Router);
  private apiUrl = `${environment.apiUrl}/auth`;

  // === US01: LOGIN ===
  login(credentials: LoginRequest): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(`${this.apiUrl}/login`, credentials).pipe(
      tap((response) => {
        localStorage.setItem('token', response.token);
        localStorage.setItem('user', JSON.stringify(response));
      })
    );
  }

  // === US02: LOGOUT Y LIMPIEZA PROFUNDA ===
  logout(): void {
    const user = this.getUser();
    const userId = user ? user.id : '';

    this.http.post<LogoutResponse>(`${this.apiUrl}/logout?userId=${userId}`, {}).subscribe({
      next: () => this.clearSessionAndRedirect(),
      error: () => this.clearSessionAndRedirect() // Limpia almacenamiento local aunque falle red
    });
  }

  private clearSessionAndRedirect(): void {
    // 1. Borrado de credenciales locales
    localStorage.clear();
    sessionStorage.clear();

    // 2. Redirección destruyendo la pila de navegación para inactivar botón 'Atrás'
    this.router.navigate(['/login'], { replaceUrl: true });
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  getUser(): LoginResponse | null {
    const userJson = localStorage.getItem('user');
    return userJson ? JSON.parse(userJson) : null;
  }
}
