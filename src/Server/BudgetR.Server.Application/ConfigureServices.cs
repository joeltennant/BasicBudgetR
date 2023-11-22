﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BudgetR.Server.Application;

public static class ConfigureServices
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}