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
    var userExists = await authRepository.CheckLoginAndEmail(request.Username, request.Email, cancellationToken);
    if (userExists) return BadRequest("Пользователь с таким логином или email уже существует");

    var userId = await authRepository.AddUser(new UserAddDto {
      Email = request.Email,
      Username = request.Username,
      Password = request.Password,
    }, cancellationToken);
    
    
    
    return Ok();
  }
  
  [HttpPost("login")]
  public async Task<ActionResult> Login(LoginRequest request, CancellationToken cancellationToken = default) {
    // await authRepository.GetUser(user, cancellationToken);
    return Ok();
  }
  
  [HttpPost("validate")]
  public async Task<ActionResult> ValidateToken([FromBody] string token, CancellationToken cancellationToken = default) {
    return Ok();
  }
}