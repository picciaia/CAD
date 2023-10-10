using LanguageExt;
using Microsoft.AspNetCore.Mvc;

namespace Apsoft.Cad.Presentation;

public static class ActionResultExtensions
{
    public static IActionResult ToActionResult<R>(this Either<DomainError, R> either) =>
        either.Match<IActionResult>(Left: l => new BadRequestObjectResult(l.Value), Right: r => new OkObjectResult(r));

    public static Task<IActionResult> ToActionResult<L, R>(this Task<Either<L, R>> either) =>
        either.Map(Match);

    public static Task<IActionResult> ToActionResult(this Task<Either<DomainError, Task>> either) =>
        either.Bind(Match);

    private static IActionResult Match<L, R>(this Either<L, R> either) =>
        either.Match<IActionResult>(
            Left: l => new BadRequestObjectResult(l),
            Right: r => new OkObjectResult(r));

    private async static Task<IActionResult> Match(Either<DomainError, Task> either) =>
        await either.MatchAsync<IActionResult>(
            RightAsync: async t => { await t; return new OkResult(); },
            Left: e => new BadRequestObjectResult(e));


    public static IActionResult ToActionResult<T>(this Option<T> option) =>
        option.Match<IActionResult>(
            Some: t => new OkObjectResult(t),
            None: () => new NotFoundResult());

    public static Task<IActionResult> ToActionResult<T>(this Task<Option<T>> option) =>
        option.Map(ToActionResult);

    public static IActionResult ToActionResult<T>(this Validation<DomainError, T> validation) =>
              validation.Match<IActionResult>(
                  Succ: t => new OkObjectResult(t),
                  Fail: e => new BadRequestObjectResult(e));

    public static Task<IActionResult> ToActionResult<T>(this Task<Validation<DomainError, T>> validation) =>
        validation.Map(ToActionResult);

    public static Task<IActionResult> ToActionResult(this Task<Validation<DomainError, Task>> validation) =>
        validation.Bind(ToActionResult);

    private static Task<IActionResult> ToActionResult(Validation<DomainError, Task> validation) =>
        validation.MatchAsync<IActionResult>(
            SuccAsync: async t => { await t; return new OkResult(); },
            Fail: e => new BadRequestObjectResult(e));

}
