using Domain.DTOs;

namespace Domain;

public interface IAuthRepository {
  Task<int> AddUser(string name, string email, string password, CancellationToken cancellationToken = default);
  Task<bool> CheckLoginAndEmail(string name, string email, CancellationToken cancellationToken = default);
  Task<UserDto> GetUser(string name, string password, CancellationToken cancellationToken = default);
}