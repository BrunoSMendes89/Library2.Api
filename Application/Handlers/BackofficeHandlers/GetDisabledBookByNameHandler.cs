using Application.Models;
using Application.Models.BackofficeControllerModels;
using Mapster;
using MediatR;
using Persistence.Context;

namespace Application.Handlers.BackofficeHandlers
{
    public class GetDisabledBookByNameHandler : IRequestHandler<GetBooksByNameRequest, List<BookModels>>
    {
        private readonly MySqlContext _sqlcontext;

        public GetDisabledBookByNameHandler(MySqlContext sqlcontext)
        {
            _sqlcontext = sqlcontext;
        }

        public async Task<List<BookModels>> Handle(GetBooksByNameRequest request, CancellationToken cancellationToken)
        {
            var booksByAuthor = _sqlcontext.Books.Where(x => x.Title == request.Name && !x.Active).ToList();

            var bookList = booksByAuthor.Adapt<List<BookModels>>();

            return bookList;
        }
    }
}
