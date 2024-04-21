using JtwStore.core.Contexts.SharedContext.Entities;

namespace JtwStore.core.Contexts.AccountContext.Entities;

public class Role : Entity
{
    public string Name { get; set; } = string.Empty;
    public List<User> Users { get; set; } = [];
}
