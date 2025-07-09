using MediatR;

namespace Application.Models.BooksControllerModels
{
    public class InsertBookRequest : IRequest<BaseResponse>
    {
        public string Title { get; set; }
        public int Pages { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Publisher { get; set; }
    }
}
