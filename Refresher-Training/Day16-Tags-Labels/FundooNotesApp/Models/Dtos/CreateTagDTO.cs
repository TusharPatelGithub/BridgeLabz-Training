using System.ComponentModel.DataAnnotations;

namespace Models.Dtos
{
    public class CreateTagDTO
    {
        [Required(ErrorMessage = "Tag name is required")]
        public string Name { get; set; } = string.Empty;
    }
}
