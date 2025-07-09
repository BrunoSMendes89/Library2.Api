using Application.Models.BooksControllerModels;
using Mapster;
using MediatR;
using Persistence.Context;

namespace Application.Handlers.BooksHandlers
{
    public class GetBooksByAuthorHandler : IRequestHandler<GetBooksByAuthorRequest, List<GetBooksByAuthorResponse>>
    {
        private readonly MySqlContext _sqlcontext;

        public GetBooksByAuthorHandler(MySqlContext sqlcontext)
        {
            _sqlcontext = sqlcontext;
        }

        public async Task<List<GetBooksByAuthorResponse>> Handle(GetBooksByAuthorRequest request, CancellationToken cancellationToken)
        {
            var booksByAuthor = _sqlcontext.Books.Where(x => x.Author == request.Author && x.Active).ToList();

            var bookList = booksByAuthor.Adapt<List<GetBooksByAuthorResponse>>();

            return bookList;
        }
    }
}
