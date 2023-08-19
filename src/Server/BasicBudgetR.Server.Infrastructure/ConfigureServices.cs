using BasicBudgetR.Server.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BasicBudgetR.Server.Infrastructure;

public static class ConfigureServices
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BudgetRDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }
}
