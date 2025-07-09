namespace Domain.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int Pages { get; set; }
        public string? Author { get; set; }
        public string Category { get; set; }
        public string Publisher { get; set; }
        public bool Active { get; set; }
    }
}
