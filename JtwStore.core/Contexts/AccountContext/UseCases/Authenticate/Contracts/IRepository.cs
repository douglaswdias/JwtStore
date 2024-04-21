using JtwStore.core.Contexts.AccountContext.Entities;

namespace JtwStore.core.Contexts.AccountContext.UseCases.Authenticate.Contracts;

public interface IRepository
{
    Task<User?> GetUserByEMailAsync(string email, CancellationToken cancellationToken);
}
