namespace Apsoft.Libs.Esb.MediatR;


public class Event<TEvent> : INotification
{
    public TEvent Evt { get; }

    public Event(TEvent evt)
    {
        Evt = evt;
    }
}