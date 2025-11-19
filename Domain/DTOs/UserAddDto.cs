namespace Domain.DTOs;

public class UserAddDto {
  public required string Username { get; init; }
  public required string Email { get; init; }
  public required string Password { get; init; }
}