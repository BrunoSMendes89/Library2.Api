using Application.Models;
using MediatR;

namespace Application.Handlers
{
    public class GetBooksByAuthorHandler : IRequestHandler<GetBooksByAuthorRequest, List<GetBooksByAuthorResponse>>
    {
        public Task<List<GetBooksByAuthorResponse>> Handle(GetBooksByAuthorRequest request, CancellationToken cancellationToken)
        {
            var bookList = new List<GetBooksByAuthorResponse>();

            var book1 = new GetBooksByAuthorResponse
            {
                Author = "Shakespeare",
                Title = "O Mercador de Veneza",
                Pages = 456
            };
            var book2 = new GetBooksByAuthorResponse
            {
                Author = "Shakespeare",
                Title = "Macbeth",
                Pages = 230
            };

            bookList.Add(book1);
            bookList.Add(book2);
            return Task.FromResult(bookList);
        }
    }
}
