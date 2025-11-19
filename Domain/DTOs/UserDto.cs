namespace Domain.DTOs;

public class UserDto {
  public int Id { get; init; }
  public required string Username { get; init; }
  public required string Email { get; init; }
}