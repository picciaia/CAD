using LanguageExt;

namespace Apsoft.Cad.Domain;

public static class LanguageExtensions
{
    public static Either<DomainError, R> ToEither<R>(this Validation<DomainError, R> validation) =>
        validation.ToEither().MapLeft(errors => errors.Join());

    public static Task<Either<DomainError, R>> ToEither<R>(this Task<Validation<DomainError, R>> validation) =>
        validation.Map(v => v.ToEither<R>());

    public static Task<Either<DomainError, R>> ToEitherAsync<R>(this Validation<DomainError, Task<R>> validation) =>
        validation.ToEither()
            .MapLeft(errors => errors.Join())
            .MapAsync<DomainError, Task<R>, R>(e => e);
}
