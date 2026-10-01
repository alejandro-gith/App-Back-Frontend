using MiApp.Domain.Dtos;

namespace MiApp.Repository.Interfaces;

public interface ICartRepository
{
    List<CartDto> GetAll();
}