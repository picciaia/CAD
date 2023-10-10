namespace Apsoft.Libs.Esb.MediatR;

public class MediatorBus : IServiceBus
{
    private readonly IMediator _mediator;

    public MediatorBus(IMediator mediator)
    {
        _mediator = mediator;
    }

    public Task Publish<TNotification>(TNotification notification,
        CancellationToken cancellationToken = default(CancellationToken))
        where TNotification : IEvent =>
        _mediator
            .Publish(new Event<TNotification>(notification), cancellationToken);


    public async Task<TResponse> Send<TCommand, TResponse>(TCommand command, CancellationToken cancellationToken = default)
        where TCommand : ICommand<TResponse>
    {
        var cmd = new Command<TCommand, TResponse>(command);
        return await _mediator.Send(cmd, cancellationToken);
    }

    public async Task<TResponse> Send<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default) =>
        await ((Task<TResponse>)
            this.GetType().GetMethods().Where(m => m.Name == nameof(MediatorBus.Send) && m.GetGenericArguments().Count() == 2).SingleOrDefault()
            .MakeGenericMethod(command.GetType(), typeof(TResponse))
            .Invoke(this, new[] { command, null }));
}