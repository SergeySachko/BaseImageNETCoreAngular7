using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Application.BLL;
using Application.BLLInterfaces;
using Application.DAL;
using Application.Entities;

namespace Application.Server.Extentsions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomDevDbContext(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Startup.Configuration["Data:Dev:SqlServerConnectionString"], b => b.MigrationsAssembly("Application.DAL"));
            });

            return services;
        }

        public static IServiceCollection AddCustomProdDbContext(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Startup.Configuration["Data:Prod:SqlServerConnectionString"], b => b.MigrationsAssembly("Application.DAL"));
            });

            return services;
        }

        public static IServiceCollection AddCustomIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequiredLength = 1;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;             
                options.User.AllowedUserNameCharacters = null;
            })
           .AddEntityFrameworkStores<ApplicationDbContext>()
           .AddDefaultTokenProviders();

            return services;
        }

        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

            services.AddScoped<IDbContextFactory, DbContextFactory>();

            return services;
        }
    }   
}
