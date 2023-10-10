using Apsoft.Cad.Application;
using Apsoft.Cad.Domain;
using LanguageExt;

namespace Apsoft.Cad.Infrastructure;

public class MessageTranslator : IMessageTranslator
{
    public Either<DomainError, Message> Translate(Message message) =>
        (message, message?.Text) switch
        {
            (null, _) => new DomainError("Message is null"),
            (_, null) => new DomainError("Message text is null"),
            _ => new Message(message.Text.ToUpper())
        };
        
}
