using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
#if !DEBUG
        using var scope = app.ApplicationServices.CreateScope();

        using var dbContext =
            scope.ServiceProvider.GetRequiredService<DataContext>();

        dbContext.Database.Migrate();
#endif
    }
}