using MiApp.Domain.Dtos;
using MiApp.Repository.Interfaces;
using MiApp.Service.Interfaces;

namespace MiApp.Service.Implementations;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;

    public CartService(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public List<CartDto> GetAllCarts()
    {
        return _cartRepository.GetAll();
    }
}