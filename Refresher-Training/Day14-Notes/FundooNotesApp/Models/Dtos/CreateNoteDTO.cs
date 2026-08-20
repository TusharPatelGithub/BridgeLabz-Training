using System.ComponentModel.DataAnnotations;

namespace Models.Dtos
{
    public class CreateNoteDTO
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime? Reminder { get; set; }

        public string? Backgroundcolor { get; set; }

        public string? Image { get; set; }

        public bool Pin { get; set; } = false;

        public bool Archive { get; set; } = false;
    }
}
