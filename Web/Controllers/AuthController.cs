using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Web.Application;
using Web.Entity;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(IAuthRepository authRepository) : BaseController {
  [HttpPost("register")]
  public async Task<ActionResult> Register([FromBody] RegisterRequest request, CancellationToken cancellationToken = default) {
    var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
    
    var user = new UserDto {
      Email = request.Email,
      Username = request.Username,
      CreatedAt = DateTime.Now,
      PasswordHash = passwordHash,
    };

    var userId = await authRepository.AddUser(user, cancellationToken);
    
    return Ok();
  }
  
  [HttpPost("login")]
  public async Task<ActionResult> Login(LoginRequest request, CancellationToken cancellationToken = default) {
    // await authRepository.AddUser(user, cancellationToken);
    
    return Ok();
  }
  
  [HttpPost("validate")]
  public async Task<ActionResult> ValidateToken([FromBody] string token, CancellationToken cancellationToken = default) {
    return Ok();
  }
}