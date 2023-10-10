
using Apsoft.Libs.Architecture.Esb;
using LanguageExt.Pipes;
using LanguageExt;
using System.Transactions;
using Apsoft.Cad.Domain;

namespace Apsoft.Cad.Application;

public class CreateMessageHandler : ICommandHandler<CreateMessage, Either<DomainError, Guid>>
{
    private readonly IMessageRepository _messageRepository;
    private readonly ICreateMessageValidator _createMessageValidator;

    public CreateMessageHandler(IMessageRepository messageRepository, 
        ICreateMessageValidator createMessageValidator)
    {
        _messageRepository = messageRepository;
        _createMessageValidator = createMessageValidator;
    }

    public Task<Either<DomainError, Guid>> Handle(CreateMessage request, CancellationToken cancellationToken = default) =>
        _createMessageValidator
            .Validate(request)
            .Map(Persist)
            .ToEitherAsync();

    private Task<Guid> Persist(Message message) =>
        _messageRepository.Add(message);
}