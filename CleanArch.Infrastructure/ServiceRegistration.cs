using CleanArch.Infrastructure.Services;
using CleanArch.Infrastructure.Services.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client.Extensions.Msal;
using Microsoft.IdentityModel.Tokens;

namespace CleanArch.Infrastructure;

public static class ServiceRegistration
{
    // Diğer servislerin eklenmesi
    public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
    {

        serviceCollection.AddScoped<ITokenHandler, CustomTokenHandler>();
        serviceCollection.AddScoped<IMailService, MailService>();
        serviceCollection.AddScoped<IApplicationService, ApplicationService>();
    }

    // Generic olarak storage türünü kabul eden metot
    public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
    {
        serviceCollection.AddScoped<IStorage, T>();
    }
}
