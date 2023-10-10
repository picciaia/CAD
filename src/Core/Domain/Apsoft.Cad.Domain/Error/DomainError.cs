using LanguageExt;

public class DomainError : NewType<DomainError, string>
{
    public DomainError(string str) : base(str) { }
    public static implicit operator DomainError(string str) => New(str);
}

public static class ErrorExtensions
{
    public static DomainError Join(this Seq<DomainError> errors) => string.Join("; ", errors);
}