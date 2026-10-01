using MiApp.Domain.Dtos;

namespace MiApp.Service.Interfaces;

public interface ICartService
{
    List<CartDto> GetAllCarts();
}