using Apsoft.Cad.Domain;
using LanguageExt;

public interface IMessageRepository 
{
    Task<Option<Message>> Get(Guid id);
    Task<Option<IEnumerable<Message>>> GetAll();
    Task<Guid> Add(Message message);
}

