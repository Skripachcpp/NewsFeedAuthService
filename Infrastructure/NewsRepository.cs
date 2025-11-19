using System.Data;
using Dapper;
using Domain;
using Domain.DTOs;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure;

public class UserRepository(DpContext dpContext) : IUserRepository {
  public async Task<int> AddUserAsync(string name, string email, string password, CancellationToken cancellationToken = default) {
    var createdAt = DateTime.Now;
    var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

    // language=PostgreSQL
    var id = await dpContext.QuerySingleAsync<int>(
      @"
        INSERT INTO users (user_name, email, password_hash, created_at) 
        VALUES (@Name, @Email, @PasswordHash, @CreatedAt)
        RETURNING id;",
      parameters: new {Name = name, Email = email, PasswordHash = passwordHash, CreatedAt = createdAt},
      cancellationToken: cancellationToken
    );

    return id;
  }
  
  public async Task<bool> CheckLoginAndEmailAsync(string name, string email, CancellationToken cancellationToken = default) {
    // language=PostgreSQL
    var id = await dpContext.QueryFirstOrDefaultAsync<int?>(
      @"SELECT id FROM users WHERE email = @Email and user_name = @Name",
      parameters: new {Email = name, Name = name},
      cancellationToken: cancellationToken
    );

    return id != null;
  }

  public async Task<UserDto?> GetUserAsync(string name, string password, CancellationToken cancellationToken = default) {
    throw new NotImplementedException();
  }
}