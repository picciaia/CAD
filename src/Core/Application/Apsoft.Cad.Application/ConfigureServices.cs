using Apsoft.Cad.Application;
using Apsoft.Cad.Application.Mapping;
using FluentValidation;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) =>
        services
            .AddAutoMapper(Assembly.GetExecutingAssembly())
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
            .AddMapping()
            .AddScoped<ICreateMessageValidator, CreateMessageValidator>()
            .AddScoped<IProcessMessageValidator, ProcessMessageValidator>()
            ;



    private static IServiceCollection AddMapping(this IServiceCollection services) =>
        services
            .AddAutoMapper(c =>
            {
                c.AddProfile<ApplicationProfile>();
            });



}