namespace Apsoft.Libs.Esb.MediatR;

public class EventHandler<TEventImpl, TEvent> : INotificationHandler<TEventImpl>
    where TEventImpl : Event<TEvent>
    where TEvent : IEvent
{
    private readonly IEnumerable<IEventHandler<TEvent>> _eventHandlers;

    public EventHandler(IEnumerable<IEventHandler<TEvent>> eventHandlers)
    {
        _eventHandlers = eventHandlers;
    }

    public Task Handle(TEventImpl e, CancellationToken cancellationToken) =>
        Task
            .WhenAll(_eventHandlers.Select(h =>
                h.Handle(e.Evt, cancellationToken)));
}