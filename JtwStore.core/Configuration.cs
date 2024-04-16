namespace JtwStore.core;

public static class Configuration
{
    public static SecretsConfiguration Secrets { get; } = new();
    public static DataBaseConfiguration DataBase { get; } = new();
    public static SmtpConfiguration Smtp = new();
    public class DataBaseConfiguration
    {
        public string ConnectionString { get; set; } = string.Empty;
    }
    public class SecretsConfiguration
    {
        public string ApiKey { get; set; } = string.Empty;
        public string JwtPrivateKey { get; set; } = string.Empty;
        public string PasswordSaltKey { get; set; } = string.Empty;
    }

    public class SmtpConfiguration
    {
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; } = 25;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
