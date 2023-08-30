using System.ComponentModel.DataAnnotations;

namespace TemplateWebAPI.Models
{
    public class TemplateModel
    {
        [Required]
        public int Id { get; set; }

        [MinLength(10)]
        public string? Name { get; set; }
    }
}
