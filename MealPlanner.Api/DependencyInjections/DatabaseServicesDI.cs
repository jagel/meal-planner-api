using MealPlanner.Infrastructure.DataProvider.Context;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.Api.DependencyInjections
{
    public static class DatabaseServicesDI
    {
        public static void AddMySQLDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            //TODO: create ConfigurationProvider
            var dbConnectionStr = configuration.GetValue<string>(ConfigVar.DatabaseConnecion);
            services.AddDbContext<DbMealPlannerContext>(options => options.UseMySql(dbConnectionStr, ServerVersion.AutoDetect(dbConnectionStr)));
        }
    }
}
