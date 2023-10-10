
using Apsoft.Libs.Architecture.Esb;
using LanguageExt.Pipes;
using LanguageExt;
using System.Transactions;
using Apsoft.Cad.Domain;
using static LanguageExt.Prelude;

namespace Apsoft.Cad.Application;


public interface IProcessMessageValidator : IValidator<ProcessMessage, Message>
{

}

public class ProcessMessageValidator : IProcessMessageValidator
{
    public Validation<DomainError, Message> Validate(ProcessMessage msg) =>
        (ValidateMessage(msg),
            ValidateMessageText(msg.Message))
            .Apply((m,a) => a);

    private Validation<DomainError, Message> ValidateMessage(ProcessMessage msg) =>
        (msg == null)
            ? Fail<DomainError, Message>($"Message is null")
            : Success<DomainError, Message>(msg.Message);

    private Validation<DomainError, Message> ValidateMessageText(Message msg) =>
        string.IsNullOrEmpty(msg.Text)
            ? Fail<DomainError, Message>($"The 'Text' must not be empty")
            : Success<DomainError, Message>(msg);

}