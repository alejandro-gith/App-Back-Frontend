using MiApp.Domain.Entities;

namespace MiApp.Repository.Interfaces
{
    public interface IAuthRepository
    {
        User? GetUserByCredentials(string usernameOrEmail, string password);
    }
}