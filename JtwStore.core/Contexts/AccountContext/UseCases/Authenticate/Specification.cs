using Flunt.Notifications;
using Flunt.Validations;

namespace JtwStore.core.Contexts.AccountContext.UseCases.Authenticate;

public static class Specification
{
    public static Contract<Notification> Ensure(Request request)
        => new Contract<Notification>()
            .Requires()
            .IsGreaterThan(request.Password.Length, 8, "Password", "Senha precisa ter pelo menos 8 caracteres")
            .IsLowerThan(request.Password.Length, 40, "Password", "Senha precisa ter menos de 40 caracteres")
            .IsEmail(request.Email, "Email", "Email invalido");
}
