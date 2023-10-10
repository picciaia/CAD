namespace Apsoft.Libs.Architecture.Esb;

public interface IEventHandler<in TEventNotification> 
    where TEventNotification : IEvent
{
    Task Handle(TEventNotification notification,
        CancellationToken cancellationToken = default(CancellationToken));
}
