using JwtStore.core.AccountContext.ValueObjects;
using JwtStore.core.SharedContext.Extensions;
using JwtStore.core.SharedContext.ValueObjects;
using System.Text.RegularExpressions;

namespace JtwStore.core.AccountContext.ValueObjects;

public partial class Email : ValueObject
{
    private const string _pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

    protected Email()
    {
        
    }
    public Email(string address)
    {
        if (string.IsNullOrEmpty(address))
            throw new Exception("E-mail invalido");

        Address = address.Trim().ToLower();

        if (Address.Length < 8)
            throw new Exception("E-mail invalido");

        if (!EmailRegex().IsMatch(Address))
            throw new Exception("E-mail invalido");
    }
    public string Address { get; }
    public string Hash => Address.ToBase64();
    public Verification Verification { get; private set; } = new();

    public void ResetVerification()
    {
        Verification = new Verification();
    }

    public static implicit operator string(Email email) => email.ToString();

    public static implicit operator Email(string address) => new(address);
    public override string ToString() => Address;

    [GeneratedRegex(_pattern)]
    private static partial Regex EmailRegex();
}