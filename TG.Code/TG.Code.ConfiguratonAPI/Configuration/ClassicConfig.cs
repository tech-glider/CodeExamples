namespace TG.Code.ConfiguratonAPI.Configuration
{
    public class ClassicConfig : IClassicConfig
    {
        private readonly IConfiguration configuration;

        public ClassicConfig(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string ConnectionString => configuration.GetValue<string>(nameof(ConnectionString));

        public bool IsEnabled => configuration.GetValue<bool>(nameof(IsEnabled));

        public int Counter => configuration.GetValue<int>(nameof(Counter));
    }
}