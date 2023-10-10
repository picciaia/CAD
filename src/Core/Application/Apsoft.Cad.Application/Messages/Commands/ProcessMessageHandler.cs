
using Apsoft.Libs.Architecture.Esb;
using LanguageExt.Pipes;
using LanguageExt;
using System.Transactions;
using Apsoft.Cad.Domain;

namespace Apsoft.Cad.Application;

public class ProcessMessageHandler : ICommandHandler<ProcessMessage, Either<DomainError, Message>>
{
    private readonly IMessageTranslator _messageTranslator;
    private readonly IProcessMessageValidator _processMessageValidator;

    public ProcessMessageHandler(IMessageTranslator messageTranslator,
        IProcessMessageValidator processMessageValidator)
    {
        _messageTranslator = messageTranslator;
        _processMessageValidator = processMessageValidator;
    }
    public Task<Either<DomainError, Message>> Handle(ProcessMessage request, CancellationToken cancellationToken = default) =>
        _processMessageValidator
            .Validate(request)
            .Match<Either<DomainError, Message>>(
                Succ: a => Translate(a),
                Fail: b => b.First())
            .AsTask();

    private Either<DomainError, Message> Translate(Message message) =>
        _messageTranslator.Translate(message);

}