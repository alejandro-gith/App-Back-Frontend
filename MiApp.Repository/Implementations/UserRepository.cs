using System.Collections.Generic;
using System.Linq;
using MiApp.Domain.Dtos;
using MiApp.Repository.Interfaces;
using MiApp.Repository.Data;

namespace MiApp.Repository.Implementations;

public class UserRepository : IUserRepository
{
    public List<UserDto> GetAll()
    {
        return InMemoryData.Users.Select(u => new UserDto
        {
            Id = int.TryParse(u.Id, out var id) ? id : 0,
            Username = u.Username ?? string.Empty,
            Email = u.Email ?? string.Empty,
            Name = u.Username ?? string.Empty,
            Phone = string.Empty
        }).ToList();
    }
}