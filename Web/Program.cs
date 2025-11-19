var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddOpenApiDocument(); // swagger

builder.Services.AddOpenApi();

var app = builder.Build();

// свагер пусть будет и в продакшене
app.UseOpenApi();
app.UseSwaggerUi();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();