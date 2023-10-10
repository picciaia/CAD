
using Apsoft.Cad.Application;

namespace Apsoft.Cad.Infrastructure;

public class UserOperations : IUserOperations<UserOperationAuthorizationRequirement>
{
    public UserOperationAuthorizationRequirement AuthCreate() => new UserOperationAuthorizationRequirement { Name = Operations.CREATE };
    public UserOperationAuthorizationRequirement AuthRead() => new UserOperationAuthorizationRequirement { Name = Operations.READ };
    public UserOperationAuthorizationRequirement AuthEdit() => new UserOperationAuthorizationRequirement { Name = Operations.EDIT };
    public UserOperationAuthorizationRequirement AuthDelete() => new UserOperationAuthorizationRequirement { Name = Operations.DELETE };

    public static UserOperationAuthorizationRequirement Create => new UserOperations().AuthCreate();
    public static UserOperationAuthorizationRequirement Read => new UserOperations().AuthRead();
    public static UserOperationAuthorizationRequirement Edit => new UserOperations().AuthEdit();
    public static UserOperationAuthorizationRequirement Delete => new UserOperations().AuthDelete();
}
