using Microsoft.AspNetCore.Mvc;
using TG.Code.ConfiguratonAPI.Configuration;

namespace TG.Code.ConfiguratonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassicController : ControllerBase
    {
        private readonly IClassicConfig classicConfig;

        public ClassicController(IClassicConfig classicConfig)
        {
            this.classicConfig = classicConfig;
        }

        [HttpGet]
        public IActionResult GetConfig()
        {
            return new OkObjectResult(classicConfig);
        }
    }
}