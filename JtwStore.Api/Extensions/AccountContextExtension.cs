using MediatR;
using System.Runtime.CompilerServices;

namespace JtwStore.Api.Extensions;

public static class AccountContextExtension
{
    public static void AddAcountContext(this WebApplicationBuilder builder)
    {
        #region Create
        builder.Services.AddTransient<
            JtwStore.core.Contexts.AccountContext.UseCases.Create.Contracts.IRepository,
            JtwStore.Infra.Contexts.AccountContext.UseCases.Create.Repository>();

        builder.Services.AddTransient<
            JtwStore.core.Contexts.AccountContext.UseCases.Create.Contracts.IService,
            JtwStore.Infra.Contexts.AccountContext.UseCases.Create.Service>();
        #endregion
    }

    public static void MapAccountEndpoints(this WebApplication app)
    {
        #region Create
        app.MapPost("api/v1/users", async (
            JtwStore.core.Contexts.AccountContext.UseCases.Create.Request request,
            IRequestHandler<
                JtwStore.core.Contexts.AccountContext.UseCases.Create.Request,
                JtwStore.core.Contexts.AccountContext.UseCases.Create.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
                ? Results.Created($"api/v1/users/{result.Data?.Id}", result)
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion
    }
}
