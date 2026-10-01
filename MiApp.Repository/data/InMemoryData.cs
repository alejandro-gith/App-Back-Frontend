using System.Collections.Generic;
using MiApp.Domain.Entities;
using MiApp.Domain.Dtos;

namespace MiApp.Repository.Data;

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
            Image = "https://via.placeholder.com/150"
        },
        new Product
        {
            Id = 2,
            Title = "Smartphone Pro",
            Price = 800.00m,
            Category = "Tecnología",
            Description = "Teléfono con cámara de alta definición",
            Image = "https://via.placeholder.com/150"
        },
        new Product
        {
            Id = 3,
            Title = "Playera de Algodón",
            Price = 25.00m,
            Category = "Ropa",
            Description = "Playera cómoda 100% algodón",
            Image = "https://via.placeholder.com/150"
        },
        new Product
        {
            Id = 4,
            Title = "Tenis Deportivos",
            Price = 90.00m,
            Category = "Ropa",
            Description = "Tenis ideales para correr",
            Image = "https://via.placeholder.com/150"
        }
    };

    public static List<CartDto> Carts { get; set; } = new()
    {
        new CartDto
        {
            Id = 1,
            UserId = 1,
            Date = "2026-10-01",
            Products = new List<CartProductDto>
            {
                new CartProductDto { ProductId = 1, Quantity = 1, ProductName = "Laptop Gamer" },
                new CartProductDto { ProductId = 3, Quantity = 2, ProductName = "Playera de Algodón" }
            }
        },
        new CartDto
        {
            Id = 2,
            UserId = 2,
            Date = "2026-10-01",
            Products = new List<CartProductDto>
            {
                new CartProductDto { ProductId = 2, Quantity = 1, ProductName = "Smartphone Pro" }
            }
        }
    };
}