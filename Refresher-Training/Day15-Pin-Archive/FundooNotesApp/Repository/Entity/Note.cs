using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entity
{
    public class Note
    {
        [Key]
        public int NoteId { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime? Reminder { get; set; }

        public string? Backgroundcolor { get; set; }

        public string? Image { get; set; }

        public bool Pin { get; set; } = false;

        public DateTime Created { get; set; } = DateTime.UtcNow;

        public DateTime Edited { get; set; } = DateTime.UtcNow;

        public bool Trash { get; set; } = false;

        public bool Archive { get; set; } = false;
    }
}
