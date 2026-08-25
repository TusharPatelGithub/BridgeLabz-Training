using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entity
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        [Required(ErrorMessage = "Tag name is required")]
        public string Name { get; set; } = string.Empty;

        public ICollection<Note> Notes { get; set; } = new List<Note>();
    }
}
