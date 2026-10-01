using System.Collections.Generic;
using global::MiApp.Domain.Entities;

namespace MiApp.Repository.Data
{
    public static class InMemoryData
    {
        public static List<User> Users { get; set; } = new()
        {
            new User
            {
                Id = "1",
                Username = "admin",
                Email = "admin@miapp.com",
                Password = "123"
            },
            new User
            {
                Id = "2",
                Username = "juan",
                Email = "juan@miapp.com",
                Password = "123"
            }
        };

        public static List<Product> Products { get; set; } = new()
        {
            new Product
            {
                Id = 1,
                Title = "Laptop Gamer",
                Price = 1200.00m,
                Category = "Tecnología",
                Description = "Laptop potente para desarrollo y juegos",
                Image = "https://images.unsplash.com/photo-1496181133206-80ce9b88a853?auto=format&fit=crop&w=400&q=80"
            },
            new Product
            {
                Id = 2,
                Title = "Smartphone Pro",
                Price = 800.00m,
                Category = "Tecnología",
                Description = "Teléfono con cámara de alta definición",
                Image = "https://images.unsplash.com/photo-1511707171634-5f897ff02aa9?auto=format&fit=crop&w=400&q=80"
            },
            new Product
            {
                Id = 3,
                Title = "Playera de Algodón",
                Price = 25.00m,
                Category = "Ropa",
                Description = "Playera cómoda 100% algodón",
                Image = "https://images.unsplash.com/photo-1521572163474-6864f9cf17ab?auto=format&fit=crop&w=400&q=80"
            },
            new Product
            {
                Id = 4,
                Title = "Tenis Deportivos",
                Price = 90.00m,
                Category = "Ropa",
                Description = "Tenis ideales para correr",
                Image = "https://images.unsplash.com/photo-1542291026-7eec264c27ff?auto=format&fit=crop&w=400&q=80"
            }
        };
    }
}