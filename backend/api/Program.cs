using DotNetEnv;
using Npgsql;
using api.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Variables for database connection from .env file
Env.Load(".env");
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbUser = Environment.GetEnvironmentVariable("DB_USER");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
var connectionString = $"Host={dbHost};Database={dbName};Username={dbUser};Password={dbPassword}";

// Add services to the container.

builder.Services.AddInfrastructureLayer(connectionString);
builder.Services.AddApplicationLayer();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocumentation();
builder.Services.AddCorsOptions();

var app = builder.Build();

// DB connection test
try
{
    if (dbHost == null || dbName == null || dbUser == null || dbPassword == null)
    {
        throw new Exception("\nError: Database connection variables are not set in the .env file.");
    }
    Console.WriteLine($"Connection string: {connectionString}");
    using var conn = new NpgsqlConnection(connectionString);
    await conn.OpenAsync();
    Console.WriteLine("\nConnection Successful: " + conn.Host);

    await using var cmd = new NpgsqlCommand("SELECT current_user", conn);
    await using var reader = await cmd.ExecuteReaderAsync();
    if (await reader.ReadAsync())
    {
        Console.WriteLine("Logged as: " + reader.GetString(0));
    }
}
catch (Exception ex)
{
    Console.WriteLine($"\nConnection Error: {ex.Message}");
}

// Db Seeder
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var seeder = services.GetRequiredService<DataSeeder>();
        await seeder.SeedAsync();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngular");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();