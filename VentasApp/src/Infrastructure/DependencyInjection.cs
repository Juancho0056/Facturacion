using VentasApp.Application.Common.Interfaces;
using VentasApp.Infrastructure.Persistence;
using VentasApp.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Domain.Entities.Application;

namespace VentasApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("VENTASAPP.APIDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddScoped<IReadOnlyRepository, EntityFrameworkReadOnlyRepository<ApplicationDbContext>>();
            services.AddTransient<IIdentityService, IdentityService>();
            //services.AddDefaultIdentity<ApplicationUser>(u => u.SignIn.RequireConfirmedAccount = true)
            services.AddDefaultIdentity<ApplicationUser>()
                    .AddEntityFrameworkStores<ApplicationDbContext>();
            //services.AddIdentity<ApplicationUser, ApplicationRole>()
            //        .AddEntityFrameworkStores<ApplicationDbContext>();


            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();
            services.AddSingleton<IMvcControllerDiscovery, MvcControllerDiscovery>();
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddAuthentication()
                .AddIdentityServerJwt();
            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<EmailOptions>(configuration.GetSection("EmailOptions"));
            services.AddTransient<IUtilService, UtilService>();
            return services;
        }
    }
}
