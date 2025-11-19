namespace Infrastructure;

public class GenerateJwtToken {
  // private readonly IConfiguration _configuration;
  //
  // public string Generate() {
  //   var jwtSettings = _configuration.GetSection("JwtSettings");
  //   var secretKey = jwtSettings["SecretKey"]!;
  //   var expirationMinutes = int.Parse(jwtSettings["ExpirationMinutes"] ?? "60");
  //
  //   var claims = new[] {
  //     new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
  //     new Claim(ClaimTypes.Name, user.Username),
  //     new Claim(ClaimTypes.Email, user.Email)
  //   };
  //
  //   var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
  //   var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
  //
  //   var token = new JwtSecurityToken(
  //     issuer: jwtSettings["Issuer"],
  //     audience: jwtSettings["Audience"],
  //     claims: claims,
  //     expires: DateTime.UtcNow.AddMinutes(expirationMinutes),
  //     signingCredentials: credentials
  //   );
  //
  //   return new JwtSecurityTokenHandler().WriteToken(token);
  }
  
}