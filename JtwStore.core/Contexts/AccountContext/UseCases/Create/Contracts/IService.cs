using JtwStore.core.Contexts.AccountContext.Entities;

namespace JtwStore.core.Contexts.AccountContext.UseCases.Create.Contracts;

public interface IService
{
    Task SendVerificationEmailAsync(User user, CancellationToken cancellationToken);
}
