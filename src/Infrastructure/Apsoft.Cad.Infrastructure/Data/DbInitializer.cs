using Apsoft.Cad.Domain;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apsoft.Cad.Infrastructure;

public class DbInitializer
{
    public static Unit Initialize(AppDbContext context)
    {
        if (context == null)
            return Unit.Default;

        if (context.Messages.Any())
            return Unit.Default;

        context.Messages.AddRange(new[]
        {
            new Message("Msg1"),
            new Message("Msg2")
        });
        context.SaveChanges();
        return Unit.Default;
    }
}