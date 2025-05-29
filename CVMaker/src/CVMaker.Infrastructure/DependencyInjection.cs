using CVMaker.Application.Abstractions;
using CVMaker.Application.Abstractions.Data;
using CVMarker.Infrastructure.Context.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CVMaker.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AppDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork>(sp =>
                sp.GetRequiredService<AppDBContext>());

            services.AddScoped<IApplicationDBContext>(provider => provider.GetRequiredService<AppDBContext>());

            return services;
        }
    }
}
