namespace Apsoft.Libs.Architecture.Esb;
public interface IServiceBus
{
    Task Publish<TEvent>(TEvent ev,
        CancellationToken cancellationToken = default(CancellationToken))
        where TEvent : IEvent;

    Task<TResponse> Send<TCommand, TResponse>(TCommand command, CancellationToken cancellationToken = default(CancellationToken))
            where TCommand : ICommand<TResponse>;

    Task<TResponse> Send<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default);

}