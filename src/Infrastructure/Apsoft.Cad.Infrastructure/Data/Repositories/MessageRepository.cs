using Apsoft.Cad.Domain;
using LanguageExt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apsoft.Cad.Infrastructure.Extensions;

namespace Apsoft.Cad.Infrastructure;

public class MessageRepository : IMessageRepository
{
    private readonly AppDbContext _appDbContext;

    public MessageRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<Guid> Add(Message message) =>
        (await (_appDbContext
            .AddSaveAsync(
                _appDbContext.Messages,
                message)))
        .Id;

    public async Task<Option<Message>> Get(Guid id) =>
        await _appDbContext
            .Messages
            .SingleOrDefaultAsync(b => b.Id == id);

    public async Task<Option<IEnumerable<Message>>> GetAll() =>
        await _appDbContext
            .Messages
            .ToListAsync();

}
