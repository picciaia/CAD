using LanguageExt;

namespace Apsoft.Cad.Application;

public interface IValidator<TRequest, TResult>
{
    Validation<DomainError, TResult> Validate(TRequest request);
}
