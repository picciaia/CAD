namespace Apsoft.Cad.Application;
public interface IUserOperations<T>
{
    public T AuthCreate();
    public T AuthRead();
    public T AuthEdit();
    public T AuthDelete();
}
