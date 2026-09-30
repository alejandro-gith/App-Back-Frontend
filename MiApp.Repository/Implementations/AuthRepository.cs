using System;
using System.Linq;
using MiApp.Domain.Entities;
using MiApp.Repository.Data;
using MiApp.Repository.Interfaces;

namespace MiApp.Repository.Implementations
{
    public class AuthRepository : IAuthRepository
    {
        public User? GetUserByCredentials(string usernameOrEmail, string password)
        {
            // Busca en InMemoryData.Users por Username o Email
            return InMemoryData.Users.FirstOrDefault(u =>
                (u.Username.Equals(usernameOrEmail, StringComparison.OrdinalIgnoreCase) ||
                 u.Email.Equals(usernameOrEmail, StringComparison.OrdinalIgnoreCase)) &&
                u.Password == password
            );
        }
    }
}