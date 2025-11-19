using System.Data;
using Dapper;
using Domain;
using Domain.DTOs;
using Infrastructure.Data;

namespace Infrastructure;

public class AuthRepository(DpContext dpContext) : IAuthRepository {
  
  public Task<int> AddUser(UserDto user, CancellationToken cancellationToken = default) {
    throw new NotImplementedException();
  }

  public Task GetUser(int userId, CancellationToken cancellationToken = default) {
    throw new NotImplementedException();
  }
}