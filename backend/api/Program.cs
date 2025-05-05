using DotNetEnv;
using Npgsql;
using api.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using static System.Net.WebRequestMethods;
using api.Helpers;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Variables for database connection from .env file
Env.Load(".env");

var clientId = Environment.GetEnvironmentVariable("CLIENT_ID");
var clientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET");
var authority = Environment.GetEnvironmentVariable("AUTHORITY");
var audience = Environment.GetEnvironmentVariable("AUDIENCE");

var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbUser = Environment.GetEnvironmentVariable("DB_USER");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
var connectionString = $"Host={dbHost};Database={dbName};Username={dbUser};Password={dbPassword};Ssl Mode=Require;Timeout=30;";

// Add services to the container.

builder.Services.AddInfrastructureLayer(connectionString!);
builder.Services.AddApplicationLayer();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocumentation();
builder.Services.AddSwaggerExamplesFromAssemblyOf<DeviceCodeExample>();
builder.Services.AddCorsOptions();
builder.Services.AddMvc().AddNewtonsoftJson();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = authority;
    options.Audience = audience;

    options.Events = new JwtBearerEvents()
    { 
        OnAuthenticationFailed = context =>
        {
            context.NoResult();
            context.Response.StatusCode = 401;
            context.Response.ContentType = "text/plain";
            return context.Response.WriteAsync(context.Exception.ToString());
        } 
    };
});


var app = builder.Build();

// DB connection test
try
{
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

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngular");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();