using Microsoft.EntityFrameworkCore;
using AztroWebApplication.Data;
using AztroWebApplication.Services;
using DotNetEnv; // Importar DotNetEnv para leer .env

var builder = WebApplication.CreateBuilder(args);

Env.Load();

var host = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";
var port = Environment.GetEnvironmentVariable("DB_PORT") ?? "5432";
var database = Environment.GetEnvironmentVariable("DB_NAME") ?? "aztro";
var username = Environment.GetEnvironmentVariable("DB_USER") ?? "postgres";
var password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "postgres";

var connectionString = $"Host={host};Port={port};Database={database};Username={username};Password={password};";

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy => policy.WithOrigins(
            builder.Configuration.GetSection("CORS:AllowedOrigins").Get<string[]>() ?? Array.Empty<string>()
        )
        .AllowAnyHeader()
        .AllowAnyMethod());
});

// Configurar la conexión a PostgreSQL con las variables de entorno
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();

// Agregar servicios al contenedor
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

// Aplicar CORS antes de los controladores y la autorización
app.UseCors("AllowSpecificOrigin");

// Configurar el pipeline de la aplicación
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
