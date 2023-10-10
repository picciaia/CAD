using Apsoft.Libs.Architecture.Esb;
using LanguageExt.Pipes;
using LanguageExt;
using System.Transactions;
using Apsoft.Cad.Domain;

namespace Apsoft.Cad.Application;

public class CreateMessage : Record<CreateMessage>, ICommand<Either<DomainError, Guid>>
{
    public CreateMessage()
    {

    }

    public CreateMessage(string text)
    {
        Status = MessageStatus.Original;
        Text = text;
    }


    public MessageStatus Status { get; set; }
    public string? Text { get; set; }
}