using api.Interfaces;
using api.Mapping;
using api.Persistence.Data;
using api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Sprache;
using Swashbuckle.AspNetCore.Filters;

namespace api.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddScoped<IBossService, BossService>();
            services.AddScoped<IScalingService, ScalingService>();
            services.AddScoped<IAttackService, AttackService>();
            services.AddScoped<IFirearmService, FirearmService>();
            services.AddScoped<ITricksterWeaponService, TricksterWeaponService>();
            services.AddScoped<IDamageService, DamageService>();
            services.AddScoped<IOriginService, OriginService>();
            services.AddScoped<IEchoesPerLevelService, EchoesPerLevelService>();

            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            return services;
        }

        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
            services.AddScoped<DataSeeder>();

            return services;
        }

        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            var authority = Environment.GetEnvironmentVariable("AUTHORITY");
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Bloodborne API",
                    Version = "1.0.0",
                    Description = "Bloodborne API for calculator purposes"
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter JWT token"
                });
                c.OperationFilter<AuthorizeCheckOperationFilter>();
                c.ExampleFilters();
                c.EnableAnnotations();
            });

            return services;
        }

        public static IServiceCollection AddCorsOptions(this IServiceCollection services)
        {

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200")
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    });
            });

            return services;
        }
    }
}
