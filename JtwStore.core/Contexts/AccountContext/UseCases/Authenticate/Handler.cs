using JtwStore.core.Contexts.AccountContext.Entities;
using JtwStore.core.Contexts.AccountContext.UseCases.Authenticate.Contracts;
using MediatR;

namespace JtwStore.core.Contexts.AccountContext.UseCases.Authenticate;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IRepository _repository;
    public Handler(IRepository repository) => _repository = repository;
    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Validate Request
        try
        {
            var res = Specification.Ensure(request);
            if (!res.IsValid)
                return new Response("Requisicao invalida", 400, res.Notifications);
        }
        catch 
        {
            return new Response("Nao foi posssivel validar a requisicao", 500);
        }
        #endregion

        #region Get User
        User? user;

        try
        {
            user = await _repository.GetUserByEMailAsync(request.Email, cancellationToken);
            if (user is null)
                return new Response("Usuaio nao encontrado", 404);
        }
        catch (Exception)
        {
            return new Response("Nao foi possivel encontraro o usuario", 500);
        }
        #endregion

        #region Validate Password
        if (!user.Password.Challange(request.Password))
            return new Response("Usuario ou senha invalido", 400);
        #endregion

        #region Check if Account is Verified
        try
        {
            if (!user.Email.Verification.IsActive)
                return new Response("Conta inativa", 400);
        }
        catch
        {
            return new Response("Nao foi possivel verificar o usuario", 500);
        }
        #endregion

        #region Return User
        try
        {
            var data = new ResponseData
            {
                Id = user.Id.ToString(),
                Name = user.Name,
                Email = user.Email,
                Roles = user.Roles.Select(x => x.Name).ToArray()
            };

            return new Response(string.Empty, data);
        }
        catch
        {
            return new Response("Nao foi possivel obter os dados", 500);
        }
        #endregion
    }
}
