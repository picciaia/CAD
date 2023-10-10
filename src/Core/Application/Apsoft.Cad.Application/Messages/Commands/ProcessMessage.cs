using Apsoft.Libs.Architecture.Esb;
using LanguageExt.Pipes;
using LanguageExt;
using System.Transactions;
using Apsoft.Cad.Domain;

namespace Apsoft.Cad.Application;

public class ProcessMessage : Record<ProcessMessage>, ICommand<Either<DomainError, Message>>
{
    public ProcessMessage()
    {

    }

    public ProcessMessage(Message message)
    {
        Message = message;
    }

    public Message? Message { get; }
}