using JtwStore.core.Contexts.SharedContext.ValueObjects;

namespace JtwStore.core.Contexts.AccountContext.ValueObjects;

public class Verification : ValueObject
{
    public Verification()
    {

    }
    public string Code { get; } = Guid.NewGuid().ToString("N")[..6].ToUpper();
    public DateTime? ExpiresAt { get; private set; } = DateTime.UtcNow.AddMinutes(5);
    public DateTime? VerifiedAt { get; private set; } = null;
    public bool IsActive => VerifiedAt != null && ExpiresAt == null;

    public void Verify(string code)
    {
        if (IsActive)
            throw new Exception("Este item expirou");

        if (ExpiresAt < DateTime.UtcNow)
            throw new Exception("Codigo expirado");

        if (!string.Equals(code.Trim(), Code.Trim(), StringComparison.CurrentCultureIgnoreCase))
            throw new Exception("Codigo de verificação invalido");

        ExpiresAt = null;
        VerifiedAt = DateTime.UtcNow;
    }
}
