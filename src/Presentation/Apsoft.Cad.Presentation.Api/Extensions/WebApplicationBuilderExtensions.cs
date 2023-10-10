using Apsoft.Cad.Infrastructure;
using Microsoft.EntityFrameworkCore;
using LanguageExt;
using static LanguageExt.Prelude;

namespace Apsoft.Cad.Presentation.Api;

public static class HostExtensions
{
    public static IHost SeedDatabase(this IHost host)
    {
        var test = use(() => host.Services.CreateScope(), Seed);
        return host;
    }

    private static Unit Seed(IServiceScope scope) =>
        Try(() => scope.ServiceProvider)
            .Bind(services => Try(GetDbContext(services)))
            .Bind(ctx => Try(Migrate(ctx)))
            .Bind(ctx => Try(InitializeDb(ctx)))
            .IfFail(ex => LogException(ex, scope.ServiceProvider));

    private static AppDbContext GetDbContext(IServiceProvider provider) =>
        provider.GetRequiredService<AppDbContext>();

    private static AppDbContext Migrate(AppDbContext context)
    {
        context.Database.Migrate();
        return context;
    }

    private static Unit InitializeDb(AppDbContext context) =>
        DbInitializer.Initialize(context);

    private static Unit LogException(Exception ex, IServiceProvider provider)
    {
        provider.GetRequiredService<ILogger<Program>>()
            .LogError(ex, "Error occurred while seeding database");
        return Unit.Default;
    }
}
