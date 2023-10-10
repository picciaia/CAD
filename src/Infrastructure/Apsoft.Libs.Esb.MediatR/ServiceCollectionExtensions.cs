using Microsoft.Extensions.DependencyInjection;

namespace Apsoft.Libs.Esb.MediatR;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEvent<TEvent, TEventListener>(this IServiceCollection services)
        where TEvent : class, IEvent
        where TEventListener : class =>
        services
            .AddScoped(typeof(IEventHandler<TEvent>), typeof(TEventListener))
            .AddScoped(typeof(INotificationHandler<Event<TEvent>>), typeof(EventHandler<Event<TEvent>, TEvent>));


    public static IServiceCollection AddCommand<TCommand, TResult, TCommandListener>(this IServiceCollection services)
        where TCommand : class, ICommand<TResult>
        where TCommandListener : class
        =>
        services
            .AddScoped(typeof(ICommandHandler<TCommand, TResult>), typeof(TCommandListener))
            .AddScoped(typeof(IRequestHandler<Command<TCommand, TResult>, TResult>), typeof(CommandHandler<Command<TCommand, TResult>, TCommand, TResult>))
        ;


    public static IServiceCollection AddMediatRBase(this IServiceCollection services) =>
        services
            .AddScoped<IServiceBus, MediatorBus>()
            .AddMediatR(typeof(EventHandler<,>))
            .AddMediatR(typeof(CommandHandler<,,>));
}