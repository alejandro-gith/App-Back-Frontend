using System.Collections.Generic;
using MiApp.Domain.Entities;

namespace MiApp.Repository.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAll();
    }
}