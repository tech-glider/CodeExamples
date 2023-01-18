using Microsoft.Extensions.Options;

namespace TG.Code.ConfiguratonAPI.Configuration
{
    public class ConfigValidateOptions : IValidateOptions<OptionsConfigWithValidation>
    {
        private OptionsConfigWithValidation options;

        public ConfigValidateOptions(IConfiguration configuration)
        {
            options = configuration.GetSection("SectionOptions").Get<OptionsConfigWithValidation>();
        }

        public ValidateOptionsResult Validate(string name, OptionsConfigWithValidation options)
        {
            return options.IsEnabled && options.Counter <= 100 || !options.IsEnabled
                ? ValidateOptionsResult.Success
                : ValidateOptionsResult.Fail("When is Enabled Counter must be under 100");
        }
    }
}