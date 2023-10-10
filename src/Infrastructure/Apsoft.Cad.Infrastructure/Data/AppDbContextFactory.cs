using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Apsoft.Cad.Infrastructure;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        var cs = new ConfigurationManager();
        string localConnection = cs.GetConnectionString("CadDatabase");
        optionsBuilder.UseSqlServer(localConnection);
        return new AppDbContext(optionsBuilder.Options);
    }
}