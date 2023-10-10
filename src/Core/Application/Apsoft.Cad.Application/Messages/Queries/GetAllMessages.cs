using Apsoft.Libs.Architecture.Esb;
using LanguageExt;

namespace Apsoft.Cad.Application;

public class GetAllMessages : Record<GetAllMessages>, ICommand<Option<IEnumerable<MessageReadModel>>>
{

}
