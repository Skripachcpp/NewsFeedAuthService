using System.ComponentModel.DataAnnotations;
using Web.Application;

namespace Web.Entity;

public record LoginRequest
{
  [Validate(Required = true)]
  public required string Username { get; init; } 
  [Validate(Required = true)]
  public required string Password { get; init; }
}