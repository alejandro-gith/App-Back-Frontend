using MiApp.Domain.Dtos;

namespace MiApp.Service.Interfaces
{
    public interface IAuthService
    {
        LoginResponseDto? Login(LoginRequestDto request);
    }
}