﻿using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Application;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection collection)
    {
        collection.AddMediatR(typeof(ServiceRegistration));
        collection.AddHttpClient();
    }
}
