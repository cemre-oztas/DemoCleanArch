using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;

namespace CleanArch.Application;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection collection)
    {
        var assembly = Assembly.GetExecutingAssembly();
        collection.AddMediatR(assembly);
    }
}
