using MiApp.Domain.Dtos;

namespace MiApp.Repository.Interfaces;

public interface IUserRepository
{
    List<UserDto> GetAll();
}