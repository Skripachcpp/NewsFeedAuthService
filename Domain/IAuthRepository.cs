using Domain.DTOs;

namespace Domain;

public interface IAuthRepository {
  Task<int> AddUser(UserDto user, CancellationToken cancellationToken = default);
  Task GetUser(int userId, CancellationToken cancellationToken = default);
}