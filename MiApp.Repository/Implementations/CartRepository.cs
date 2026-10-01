using MiApp.Domain.Dtos;
using MiApp.Repository.Interfaces;
using MiApp.Repository.Data;

namespace MiApp.Repository.Implementations;

public class CartRepository : ICartRepository
{
    public List<CartDto> GetAll()
    {
        return InMemoryData.Carts;
    }
}