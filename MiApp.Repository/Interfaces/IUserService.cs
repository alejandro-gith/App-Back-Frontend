using MiApp.Domain.Dtos;

namespace MiApp.Service.Interfaces;

public interface IUserService
{
    List<UserDto> GetAllUsers();
}