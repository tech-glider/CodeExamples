namespace TG.Code.ConfiguratonAPI.Configuration
{
    public class FeatureOptions
    {
        public bool? IsEnabled { get; set; }
        public LogsLevel LogsLevel { get; set; } = LogsLevel.Undefined;
        public string? FeatureName { get; set; }
    }
}