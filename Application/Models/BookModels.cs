namespace Application.Models
{
    public class BookModels : BaseResponse
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public int Pages { get; set; }
        public string? Author { get; set; }
        public string Category { get; set; }
        public string Publisher { get; set; }
        public bool Active { get; set; }
    }
}
