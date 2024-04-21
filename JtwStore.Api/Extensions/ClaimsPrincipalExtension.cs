using JtwStore.core.Contexts.AccountContext.UseCases.Authenticate;
using System.Security.Claims;

namespace JtwStore.Api.Extensions;

public static class ClaimsPrincipalExtension
{
    public static string Id(this ClaimsPrincipal user)
        => user.Claims.FirstOrDefault(c => c.Type == "Id")?.Value ?? String.Empty;

    public static string Name(this ClaimsPrincipal user)
        => user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value ?? String.Empty;

    public static string Email(this ClaimsPrincipal user)
        => user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value ?? String.Empty;
}
