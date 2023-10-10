using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apsoft.Cad.Application;

public class MessageReadModel : Record<MessageReadModel>
{
	public MessageReadModel(string text)
	{
        Text = text;
    }

    public string Text { get; }
}
