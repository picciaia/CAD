using Apsoft.Cad.Domain;
using LanguageExt;

namespace Apsoft.Cad.Application;

public interface IMessageTranslator
{
    Either<DomainError, Message> Translate(Message message);
}
