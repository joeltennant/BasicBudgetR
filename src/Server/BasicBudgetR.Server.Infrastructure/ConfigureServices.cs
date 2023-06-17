using BasicBudgetR.Server.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BasicBudgetR.Server.Infrastructure;

public static class ConfigureServices
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        services.AddDbContext<BbrDbContext>(options => options.UseSqlServer(connectionString));
        //services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddEntityFrameworkStores<BbrDbContext>();

        services.AddIdentityServer()
            .AddApiAuthorization<User, BbrDbContext>();
    }
}
