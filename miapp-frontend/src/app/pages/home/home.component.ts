import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './home.component.html'
})
export class HomeComponent {
  private authService = inject(AuthService);
  user = this.authService.getUser();

  onLogout(): void {
    this.authService.logout();
  }
}
