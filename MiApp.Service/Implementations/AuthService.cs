using MiApp.Domain.Dtos;
using MiApp.Repository.Interfaces;
using MiApp.Service.Interfaces;

namespace MiApp.Service.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public LoginResponseDto? Login(LoginRequestDto request)
        {
            var user = _authRepository.GetUserByCredentials(request.Username, request.Password);

            if (user == null)
            {
                return null;
            }

            // Asignación de rol según el ID
            string role = GetRoleById(user.Id);

            return new LoginResponseDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Role = role,
                Token = $"fake-jwt-token-for-user-{user.Id}" // Token de acceso devuelto al cliente
            };
        }

        private static string GetRoleById(string id)
        {
            // Regla de negocio: IDs 1 y 2 = Administrador, ID 3 = Auditor, demás = Cliente
            return id switch
            {
                "1" or "2" => "Administrador",
                "3" => "Auditor",
                _ => "Cliente"
            };
        }
    }
}