using CVMaker.Application.Abstractions;
using CVMaker.Application.Abstractions.Authentication;
using CVMaker.Application.Abstractions.Data;
using CVMarker.Infrastructure.Context.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using System.Text;



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

            
        
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(Options =>
    {
        Options.RequireHttpsMetadata = false;
        Options.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Secret"])),
            ValidIssuer = configuration["JwtSettings:Issuer"],
            ValidAudience = configuration["JwtSettings:Audience"],
            ClockSkew = TimeSpan.Zero
        };
    });

        services.AddScoped<IPasswordHasher, PasswordHasher>();
            return services;
    }
}
}