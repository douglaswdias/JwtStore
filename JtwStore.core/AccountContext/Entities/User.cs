using JtwStore.core.SharedContext.Entities;

namespace JtwStore.core.AccountContext.Entities;

public class User : Entity
{
    public Email Email { get; set; }
}
