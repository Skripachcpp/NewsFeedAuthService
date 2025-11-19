using Domain;
using Microsoft.AspNetCore.Mvc;
using Web.Application;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(IAuthRepository authRepository) : BaseController {
  
  [HttpPost("register")]
  public async Task<ActionResult> Register(CancellationToken cancellationToken = default) {
    return Ok();
  }
  
  [HttpPost("login")]
  public async Task<ActionResult> Login(CancellationToken cancellationToken = default) {
    return Ok();
  }
  
  [HttpPost("validate")]
  public async Task<ActionResult> ValidateToken(CancellationToken cancellationToken = default) {
    return Ok();
  }
}