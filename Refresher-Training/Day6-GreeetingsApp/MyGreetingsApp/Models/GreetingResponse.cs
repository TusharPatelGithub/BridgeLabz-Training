namespace MyGreetingsApp.Models
{
    public class GreetingResponse
    {
        public string? Message { get; set; }
        public string? TimeOfDay { get; set; }
        public DateTime ServerTime { get; set; }
    }
}