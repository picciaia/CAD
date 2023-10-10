
using Apsoft.Libs.Architecture.Esb;
using LanguageExt.Pipes;
using LanguageExt;
using System.Transactions;
using Apsoft.Cad.Domain;
using static LanguageExt.Prelude;

namespace Apsoft.Cad.Application;


public interface ICreateMessageValidator : IValidator<CreateMessage, Message>
{

}

public class CreateMessageValidator : ICreateMessageValidator
{
    public Validation<DomainError, Message> Validate(CreateMessage msg) =>
        ValidateText(msg)
            .Map(a => new Message(a));

    private Validation<DomainError, string> ValidateText(CreateMessage msg) =>
        string.IsNullOrEmpty(msg.Text)
            ? Fail<DomainError, string>($"The 'Text' must not be empty")
            : Success<DomainError, string>(msg.Text);

}