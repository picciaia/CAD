using Apsoft.Libs.Architecture.Esb;
using LanguageExt.Pipes;
using LanguageExt;
using System.Transactions;
using Apsoft.Cad.Domain;
using AutoMapper;

namespace Apsoft.Cad.Application;

public class GetAllMessagesHandler : ICommandHandler<GetAllMessages, Option<IEnumerable<MessageReadModel>>>
{
    private readonly IMessageRepository _messageRepository;
    private readonly IMapper _mapper;

    public GetAllMessagesHandler(IMessageRepository messageRepository, 
        IMapper mapper)
    {
        _messageRepository = messageRepository;
        _mapper = mapper;
    }

    public Task<Option<IEnumerable<MessageReadModel>>> Handle(GetAllMessages request, CancellationToken cancellationToken = default)=>
        Fetch()
            .MapT(Project);

    private Task<Option<IEnumerable<Message>>> Fetch() => _messageRepository.GetAll();

    private IEnumerable<MessageReadModel> Project(IEnumerable<Message> messages) =>
            _mapper.Map<IEnumerable<MessageReadModel>>(messages);
}
