namespace Domain.DTOs;

public class UserDto {
  public required string Username { get; init; }
  public required string Email { get; init; }
  public required string PasswordHash { get; init; }
  public required DateTime CreatedAt { get; init; }
}