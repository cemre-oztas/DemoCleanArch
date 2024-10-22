using CleanArch.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client.Extensions.Msal;
using Microsoft.IdentityModel.Tokens;

namespace CleanArch.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IStorageService, StorageService>();
        serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
        serviceCollection.AddScoped<IMailService, MailService>();
        serviceCollection.AddScoped<IApplicationService, ApplicationService>();

    }
    public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
    {
        serviceCollection.AddScoped<IStorage, T>();
    }
    public static void AddStorage(this IServiceCollection serviceCollection, StorageType storageType)
    {
        switch (storageType)
        {
            case StorageType.Local:
                serviceCollection.AddScoped<IStorage, LocalStorage>();
                break;
            case StorageType.Azure:
                serviceCollection.AddScoped<IStorage, AzureStorage>();
                break;
            case StorageType.AWS:

                break;
            default:
                serviceCollection.AddScoped<IStorage, LocalStorage>();
                break;
        }
    }
}
