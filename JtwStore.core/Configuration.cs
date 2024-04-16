namespace JtwStore.core;

public static class Configuration
{
    public static SecretsConfiguration Secrets { get; } = new();
    public static DataBaseConfiguration DataBase { get; } = new();
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
}
