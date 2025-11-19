using Domain;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// bd _
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (connectionString == null) throw new Exception("Отсутствует connection string");
builder.Services.AddDbContext<EfContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddScoped<DpContext>(_ => new DpContext(connectionString));
// bd ^

builder.Services.AddCors(options => {
  options.AddDefaultPolicy(policy => {
    policy.AllowAnyOrigin()
      .AllowAnyMethod()
      .AllowAnyHeader();
  });
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IJwtToken, JwtToken>();

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddOpenApiDocument(); // swagger

builder.Services.AddOpenApi();

var app = builder.Build();

// автозапуск миграций
using (var scope = app.Services.CreateScope()) {
  var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
  var context = scope.ServiceProvider.GetRequiredService<EfContext>();
  
  try {
    logger.LogInformation("Применение миграций базы данных");
    context.Database.Migrate();
    logger.LogInformation("Миграции успешно применены.");
  }
  catch (Exception ex) {
    logger.LogError(ex, "Ошибка при применении миграций");
    throw;
  }
}

// свагер пусть будет и в продакшене
app.UseOpenApi();
app.UseSwaggerUi();

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();