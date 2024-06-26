﻿
using JtwStore.core.Contexts.AccountContext.ValueObjects;
using JtwStore.core.Contexts.SharedContext.Entities;

namespace JtwStore.core.Contexts.AccountContext.Entities;

public class User : Entity
{
    protected User()
    {

    }

    public User(string name,Email email, Password password)
    {
        Name = name;
        Email = email;
        Password = password;
    }
    public User(string email, string? password = null)
    {
        Email = email;
        Password = new Password(password);
    }
    public string Name { get; private set; } = string.Empty;
    public Email Email { get; private set; } = null!;
    public Password Password { get; private set; } = null!;
    public string Image { get; private set; } = string.Empty;
    public List<Role> Roles { get; set; } = [];
    //public IEnumerable<Role> Roles { get; set; } = Enumerable.Empty<Role>();

    public void UpdatePassword(string plainTextPassword, string code)
    {
        if (!string.Equals(code.Trim(), Password.ResetCode.Trim(), StringComparison.CurrentCultureIgnoreCase))
            throw new Exception("Codigo de restauração invalido");

        var password = new Password(plainTextPassword);
        Password = password;
    }

    public void UpdateEmail(Email email)
    {
        Email = email;
    }

    public void ChangePassword(string plainTextPassword)
    {
        var password = new Password(plainTextPassword);
        Password = password;
    }
}
