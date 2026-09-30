using System.Collections.Generic;
using MiApp.Domain.Dtos;

namespace MiApp.Service.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductResponseDto> GetAll();
        IEnumerable<string> GetCategories();
        IEnumerable<ProductResponseDto>? GetByCategory(string category);
    }
}
