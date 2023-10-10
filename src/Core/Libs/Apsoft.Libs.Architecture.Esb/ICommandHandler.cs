namespace Apsoft.Libs.Architecture.Esb;

public interface ICommandHandler<in TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
    Task<TResponse> Handle(TCommand request, 
        CancellationToken cancellationToken = default(CancellationToken));
}