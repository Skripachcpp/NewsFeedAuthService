using System.ComponentModel.DataAnnotations;
using Web.Application;

namespace Web.Entity;

public record RegisterRequest
{
  [Validate(Required = true, Min = 1, Max = 100)]
  public required string Name { get; init; } 
  [Validate(Required = true, Min = 1, Max = 254)]
  public required string Email { get; init; }
  [Validate(Required = true)]
  public required string Password { get; init; }
}