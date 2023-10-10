namespace Apsoft.Libs.Esb.MediatR;

public class Command<TCommand, TResponse> : IRequest<TResponse>
{
    public TCommand Cmd { get; }

    public Command(TCommand command)
    {
        Cmd = command;
    }
}