using JtwStore.core.Contexts.AccountContext.Entities;
using JtwStore.core.Contexts.AccountContext.UseCases.Create.Contracts;
using JtwStore.core.Contexts.AccountContext.ValueObjects;

namespace JtwStore.core.Contexts.AccountContext.UseCases.Create;

public class Handler
{
    private readonly IRepository _repository;
    private readonly IService _service;

    public Handler(IRepository repository, IService service)
    {
        _repository = repository;
        _service = service;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancelationToken)
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
            return new Response("Nao foi possivel validar", 500);
        }
        #endregion

        #region Create Object
        Email email;
        Password password;
        User user;

        try
        {
            email = new Email(request.Email);
            password = new Password(request.Password);
            user = new User(request.Name, email, password);
        }
        catch (Exception ex)
        {
            return new Response(ex.Message, 400);
        }
        #endregion

        #region Check User
        try
        {
            var exists = await _repository.AnyAsync(request.Email, cancelationToken);
            if (exists)
                return new Response("Email ja existe", 400);
        }
        catch
        {
            return new Response("Falha ao verificar email", 500);
        }
        #endregion

        #region Persist Data
        try
        {
            await _repository.SaveAsync(user, cancelationToken);
        }
        catch
        {
            return new Response("Falha ao salvar dados", 500);
        }
        #endregion

        #region Send Activation Email
        try
        {
            await _service.SendVerificationEmailAsync(user, cancelationToken);
        }
        catch
        {

        }
        #endregion

        return new Response("Conta Criada", new ResponseData(user.Id, user.Name, user.Email));
    }
}
