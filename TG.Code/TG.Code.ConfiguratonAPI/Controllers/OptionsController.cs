using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TG.Code.ConfiguratonAPI.Configuration;

namespace TG.Code.ConfiguratonAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OptionsController : ControllerBase
    {
        private readonly IOptions<OptionsConfig> options;
        private readonly IOptionsSnapshot<OptionsConfig> optionsSnapshot;
        private readonly IOptionsMonitor<OptionsConfig> optionsMonitor;
        private readonly IOptionsSnapshot<FeatureOptions> featuresOptionsSnapshot;
        private readonly IOptions<OptionsConfigWithValidation> validatedOptions;

        public OptionsController(
            IOptions<OptionsConfig> options,
            IOptionsSnapshot<OptionsConfig> optionsSnapshot,
            IOptionsMonitor<OptionsConfig> optionsMonitor,
            IOptionsSnapshot<FeatureOptions> featuresOptionsSnapshot,
            IOptions<OptionsConfigWithValidation> validatedOptions)
        {
            this.options = options;
            this.optionsSnapshot = optionsSnapshot;
            this.optionsMonitor = optionsMonitor;
            this.featuresOptionsSnapshot = featuresOptionsSnapshot;
            this.validatedOptions = validatedOptions;
        }

        [HttpGet("GetOptions/{delay}")]
        public async Task<IActionResult> GetOptions(int delay)
        {
            var oldValue = optionsMonitor.CurrentValue.ConnectionString;
            await Task.Delay(delay);
            return new OkObjectResult(new
            {
                IOptions = options.Value,
                IOptionsSnapshot = optionsSnapshot.Value,
                IOptionsMonitor = optionsMonitor.CurrentValue,
                Features = new
                {
                    Feature1 = featuresOptionsSnapshot.Get("Feature1"),
                    Feature2 = featuresOptionsSnapshot.Get("Feature2")
                }
            });
        }

        [HttpGet("GetValidatedOptions")]
        public IActionResult GetValidatedOptions()
        {
            return new OkObjectResult(new
            {
                ValidatedOptions = validatedOptions.Value
            });
        }
    }
}