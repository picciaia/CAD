
using Apsoft.Cad.Application;
using Apsoft.Cad.Domain;
using Apsoft.Cad.Infrastructure;
using Apsoft.Libs.Esb.MediatR;
using LanguageExt;
using Microsoft.AspNetCore.Authorization;

using System.Reflection;
using System.Transactions;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services) =>
      services
          .AddMediatRHandlers()
          .AddAuthorizationConfig()
          .AddDependencies();

    private static IServiceCollection AddMediatRHandlers(this IServiceCollection services) =>
        services
            .AddCommand<GetAllMessages, Option<IEnumerable<MessageReadModel>>, GetAllMessagesHandler>()
            .AddCommand<CreateMessage, Either<DomainError, Guid>, CreateMessageHandler>()
            .AddCommand<ProcessMessage, Either<DomainError, Message>, ProcessMessageHandler>()
            .AddMediatRBase();


    private static IServiceCollection AddAuthorizationConfig(this IServiceCollection services) =>
        services
            .AddSingleton<IAuthorizationPolicyProvider, CustomAuthorizationPolicyProvider>()
            .AddScoped<IAuthorizationHandler, UserOperationAuthorizationHandler>();


    private static IServiceCollection AddDependencies(this IServiceCollection services) =>
        services
            .AddScoped<IMessageTranslator, MessageTranslator>()
            .AddScoped<IMessageRepository, MessageRepository>()
        ;

}