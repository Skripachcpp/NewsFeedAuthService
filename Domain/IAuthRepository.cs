using Domain.DTOs;

namespace Domain;

public interface IAuthRepository {
  Task<int> AddUser(UserAddDto user, CancellationToken cancellationToken = default);
  Task<bool> CheckLoginAndEmail(string userName, string userEmail, CancellationToken cancellationToken = default);
  Task<UserDto> GetUser(string userName, string password, CancellationToken cancellationToken = default);
}