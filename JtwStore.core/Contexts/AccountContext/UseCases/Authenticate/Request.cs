using MediatR;

namespace JtwStore.core.Contexts.AccountContext.UseCases.Authenticate;

public record Request(
    string Email,
    string Password
) : IRequest<Response>;
