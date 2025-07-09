using MediatR;

namespace Application.Models.BooksControllerModels
{
    public class GetBooksByAuthorRequest : IRequest<List<GetBooksByAuthorResponse>>
    {
        public string Author { get; set; }
    }
}
