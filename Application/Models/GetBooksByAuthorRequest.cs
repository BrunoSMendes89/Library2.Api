using MediatR;

namespace Application.Models
{
    public class GetBooksByAuthorRequest : IRequest<List<GetBooksByAuthorResponse>>
    {
        public string Author { get; set; }
    }
}
