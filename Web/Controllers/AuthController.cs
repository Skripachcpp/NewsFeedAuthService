using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Web.Application;
using Web.Entity;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(IAuthRepository authRepository, IJwtToken jwtToken) : BaseController {
  [HttpPost("register")]
  public async Task<ActionResult<string>> Register([FromBody] RegisterRequest request, CancellationToken cancellationToken = default) {
    var email = request.Email;
    var name = request.Username;
    var password = request.Password;
    
    var userExists = await authRepository.CheckLoginAndEmail(name, email, cancellationToken);
    if (userExists) return BadRequest("Пользователь с таким логином или email уже существует");

    var id = await authRepository.AddUser(name, email, password, cancellationToken);
    var token = jwtToken.Generate(id, name, email);
    
    return OkResult(token);
  }
  
  [HttpPost("login")]
  public async Task<ActionResult<string>> Login(LoginRequest request, CancellationToken cancellationToken = default) {
    // await authRepository.GetUser(user, cancellationToken);
    return Ok();
  }
  
  [HttpPost("validate")]
  public async Task<ActionResult> ValidateToken([FromBody] string token, CancellationToken cancellationToken = default) {
    return Ok();
  }
}