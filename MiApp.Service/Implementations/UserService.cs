using MiApp.Domain.Dtos;
using MiApp.Repository.Interfaces;
using MiApp.Service.Interfaces;

namespace MiApp.Service.Implementations;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public List<UserDto> GetAllUsers()
    {
        return _userRepository.GetAll();
    }
}