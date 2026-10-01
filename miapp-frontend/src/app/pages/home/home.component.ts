import {
  Component,
  ChangeDetectorRef,
  DestroyRef,
  OnInit,
  inject
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { finalize, timeout } from 'rxjs';
import { AuthService } from '../../services/auth.service';
import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product.model';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, ScrollingModule],
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
  private authService = inject(AuthService);
  private productService = inject(ProductService);
  private destroyRef = inject(DestroyRef);
  private changeDetector = inject(ChangeDetectorRef);

  user = this.authService.getUser();
  products: Product[] = [];
  loading = false;
  errorMessage = '';

  ngOnInit(): void {
    this.loadProducts();
  }

  loadProducts(): void {
    if (this.loading) {
      return;
    }

    this.loading = true;
    this.errorMessage = '';

    this.productService.getProducts().pipe(
      timeout(15000),
      takeUntilDestroyed(this.destroyRef),
      finalize(() => {
        this.loading = false;

        if (!this.destroyRef.destroyed) {
          this.changeDetector.markForCheck();
        }
      })
    ).subscribe({
      next: (products: Product[]) => {
        this.products = products;
      },
      error: () => {
        this.errorMessage =
          'No pudimos cargar los productos. Intenta nuevamente.';
      }
    });
  }

  trackByProductId(index: number, product: Product): number {
    return product.id;
  }

  onLogout(): void {
    this.authService.logout();
  }
}