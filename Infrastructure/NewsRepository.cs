using System.Data;
using Dapper;
using Domain;
using Domain.DTOs;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure;

public class AuthRepository(DpContext dpContext) : IAuthRepository {
  public Task<int> AddUser(UserAddDto param, CancellationToken cancellationToken = default) {
    var passwordHash = BCrypt.Net.BCrypt.HashPassword(param.Password);

    var user = new User {
      Email = param.Email,
      Username = param.Username,
      CreatedAt = DateTime.Now,
      PasswordHash = passwordHash,
    };
    
    throw new NotImplementedException();
  }
  
  public Task CheckUser(CheckUserDto user, CancellationToken cancellationToken = default) {
    throw new NotImplementedException();
  }

  public Task GetUser(int userId, CancellationToken cancellationToken = default) {
    throw new NotImplementedException();
  }
}