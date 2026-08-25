namespace Models.Dtos
{
    public class NoteResponseDTO
    {
        public int NoteId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime? Reminder { get; set; }
        public string? Backgroundcolor { get; set; }
        public string? Image { get; set; }
        public bool Pin { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public bool Trash { get; set; }
        public bool Archive { get; set; }
        public List<TagResponseDTO> Tags { get; set; } = new();
    }
}
