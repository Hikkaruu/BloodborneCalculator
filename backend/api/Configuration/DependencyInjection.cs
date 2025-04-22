using api.Interfaces;
using api.Mapping;
using api.Persistence.Data;
using api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Bloodborne API",
                    Version = "1.0.0",
                    Description = "Bloodborne API for calculator purposes"
                });
            });

            return services;
        }

    }
}
