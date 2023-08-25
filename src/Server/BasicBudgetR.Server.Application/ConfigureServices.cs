using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BasicBudgetR.Server.Application;

public static class ConfigureServices
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}