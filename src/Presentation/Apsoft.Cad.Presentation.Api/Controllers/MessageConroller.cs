using Apsoft.Cad.Application;
using Apsoft.Cad.Infrastructure;
using Apsoft.Libs.Architecture.Esb;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Apsoft.Cad.Presentation.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MessageConroller : AuthConrollerBase
{
    private readonly IServiceBus _servicebus;

    public MessageConroller(IServiceBus servicebus,
        IAuthorizationService authorizationService)
            : base(authorizationService) =>
        _servicebus = servicebus;

    [HttpGet]
    public async Task<IActionResult> Index() =>
        await WhenAuthorized(
            UserOperations.Read,
            ((await _servicebus.Send(new GetAllMessages()))
            .ToActionResult()));

    [HttpGet("noauth")]
    public async Task<IActionResult> IndexNoAuth() =>
        (await _servicebus.Send(new GetAllMessages()))
            .ToActionResult();

    [HttpPost]
    public async Task<IActionResult> Create(CreateMessage msg) =>
        (await _servicebus.Send(msg))
            .ToActionResult();


    //[HttpGet]
    //public async Task<IActionResult> Process(ProcessMessage msg) =>
    //    (await _servicebus.Send(msg))
    //        .ToActionResult();
}
