using EFCore.AutomaticMigrations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FluxoCaixa.Application.Common
{
    public class DataContextAutomaticMigrationStartupFilter<T> : IStartupFilter where T : DbContext
    {
        /// <inheritdoc />
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    scope.ServiceProvider.GetRequiredService<T>().MigrateToLatestVersion(new DbMigrationsOptions 
                    { AutomaticMigrationsEnabled = false , ResetDatabaseSchema = false, AutomaticMigrationDataLossAllowed = false });

                }
                next(app);
            };
        }
    }
}
