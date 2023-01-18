namespace TG.Code.ConfiguratonAPI.Configuration
{
    public interface IClassicConfig
    {
        string ConnectionString { get; }
        bool IsEnabled { get; }
        int Counter { get; }
    }
}