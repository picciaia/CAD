namespace Apsoft.Libs.Esb.MediatR;

public class CommandHandler<TCommandImpl, TCommand, TResponse> : IRequestHandler<TCommandImpl, TResponse>
    where TCommandImpl : Command<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
    private readonly IEnumerable<ICommandHandler<TCommand, TResponse>> _commandHandlers;

    public CommandHandler(IEnumerable<ICommandHandler<TCommand, TResponse>> commandHandlers)
    {
        _commandHandlers = commandHandlers;
    }

    public Task<TResponse> Handle(TCommandImpl request,
        CancellationToken cancellationToken) =>
        Task
            .FromResult(
                Task
                    .WhenAll(
                    _commandHandlers
                        .Select(c =>
                            c.Handle(request.Cmd, cancellationToken)))
            .Result.FirstOrDefault());
}