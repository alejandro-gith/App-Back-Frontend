using System.Collections.Generic;
using MiApp.Domain.Dtos;

namespace MiApp.Service.Interfaces
{
    public interface IProductService
    {
        List<ProductResponseDto> GetAll();
    }
}