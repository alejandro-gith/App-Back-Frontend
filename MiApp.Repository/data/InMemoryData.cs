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
                Image = "https://placehold.co/600x600/4f46e5/ffffff?text=Laptop+Gamer"
            },
            new Product
            {
                Id = 2,
                Title = "Smartphone Pro",
                Price = 800.00m,
                Category = "Tecnología",
                Description = "Teléfono con cámara de alta definición",
                Image = "https://placehold.co/600x600/6366f1/ffffff?text=Smartphone+Pro"
            },
            new Product
            {
                Id = 3,
                Title = "Playera de Algodón",
                Price = 25.00m,
                Category = "Ropa",
                Description = "Playera cómoda 100% algodón",
                Image = "https://placehold.co/600x600/db2777/ffffff?text=Playera"
            },
            new Product
            {
                Id = 4,
                Title = "Tenis Deportivos",
                Price = 90.00m,
                Category = "Ropa",
                Description = "Tenis ideales para correr",
                Image = "https://placehold.co/600x600/9333ea/ffffff?text=Tenis"
            }
        };
    }
}