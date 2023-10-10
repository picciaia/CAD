using LanguageExt;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Apsoft.Cad.Infrastructure.Extensions;

public static class DbSetExtensions
{
    public static TEntity AddSave<TDbContext, TEntity>(
        this TDbContext dbContext,
        DbSet<TEntity> dbSet,
        TEntity entity)
        where TDbContext : DbContext
        where TEntity : class
    {
        dbSet.Add(entity);
        dbContext.SaveChanges();
        return entity;
    }

    public async static ValueTask<TEntity> AddSaveAsync<TDbContext, TEntity>(
        this TDbContext dbContext,
        DbSet<TEntity> dbSet,
        TEntity entity)
        where TDbContext : DbContext
        where TEntity : class
    {
        await dbSet.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }
}
