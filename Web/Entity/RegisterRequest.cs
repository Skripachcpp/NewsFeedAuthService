using System.ComponentModel.DataAnnotations;
using Web.Application;

namespace Web.Entity;

public record RegisterRequest
{
  [Required(ErrorMessage = "имя пользователя обязательно")]
  [StringLength(100, MinimumLength = 1, ErrorMessage = "Заголовок должен быть от 1 до 500 символов")]
  public required string Name { get; init; } 
  [Required(ErrorMessage = "email обязателен")]
  public required string Email { get; init; }
  [Required(ErrorMessage = "пароль обязателен")]
  public required string Password { get; init; }
}