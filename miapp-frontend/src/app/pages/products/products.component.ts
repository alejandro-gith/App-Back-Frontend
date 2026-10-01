import { Component, OnInit, inject, signal } from '@angular/core';
import { CurrencyPipe } from '@angular/common';
import { Product } from '../../models/product.model';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [CurrencyPipe],
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent implements OnInit {
  private productService = inject(ProductService);

  private readonly friendlyError =
    'No pudimos cargar el catálogo. Revisa tu conexión e inténtalo de nuevo.';

  categories = signal<string[]>([]);
  products = signal<Product[]>([]);
  selectedCategory = signal<string | null>(null);
  loading = signal(false);
  errorMessage = signal('');

  // Ids de productos cuya imagen no cargó
  failedImages = signal<ReadonlySet<number>>(new Set());

  ngOnInit(): void {
    this.selectCategory(null);
    this.loadCategories();
  }

  private loadCategories(): void {
    this.productService.getCategories().subscribe({
      next: (categories) => this.categories.set(categories),
      error: () => this.errorMessage.set(this.friendlyError)
    });
  }

  // category = null significa "Ver todos"
  selectCategory(category: string | null): void {
    this.selectedCategory.set(category);
    this.products.set([]); // limpiar el arreglo anterior antes de cada petición
    this.errorMessage.set('');
    this.loading.set(true);

    const request = category === null
      ? this.productService.getAll()
      : this.productService.getByCategory(category);

    request.subscribe({
      next: (products) => {
        this.products.set(products);
        this.loading.set(false);
      },
      error: () => {
        this.errorMessage.set(this.friendlyError);
        this.loading.set(false);
      }
    });
  }

  // Botón "Reintentar": repite la petición actual y las categorías si faltan
  retry(): void {
    this.selectCategory(this.selectedCategory());
    if (this.categories().length === 0) {
      this.loadCategories();
    }
  }

  onImageError(productId: number): void {
    this.failedImages.update((ids) => new Set(ids).add(productId));
  }
}
