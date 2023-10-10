using Apsoft.Cad.Infrastructure;
using Apsoft.Cad.Presentation.Api;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
AddServivesConfiguration(builder.Services);
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
((IHost)app)
    .SeedDatabase();
app.Run();


void AddServivesConfiguration(IServiceCollection services) =>
    AddDbConfig(services)
        .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
        .AddApplicationServices()
        .AddInfrastructureServices();

IServiceCollection AddDbConfig(IServiceCollection services) =>
    services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("name=ConnectionStrings:CadDatabase"));
