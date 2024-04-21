using JtwStore.core.Contexts.AccountContext.Entities;
using JtwStore.core.Contexts.AccountContext.UseCases.Authenticate.Contracts;
using JtwStore.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace JtwStore.Infra.Contexts.AccountContext.UseCases.Authenticate;

public class Repository : IRepository
{ 
    private readonly AppDbContext _context;
    public Repository(AppDbContext context) => _context = context;

    public async Task<User?> GetUserByEMailAsync(string email, CancellationToken cancellationToken)
    {
        return await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email.Address == email, cancellationToken);
    }
}
