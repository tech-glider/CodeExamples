using System.ComponentModel.DataAnnotations;

namespace TG.Code.ConfiguratonAPI.Configuration
{
    public class OptionsConfigWithValidation
    {
        [Required]
        public string? ConnectionString { get; set; }

        public bool IsEnabled { get; set; }

        [Range(0, 1000, ErrorMessage = "Value {0}, is out of range {1}-{2}.")]
        public int? Counter { get; set; }
    }
}