using Application.Models.BackofficeControllerModels;
using MediatR;
using Persistence.Context;

namespace Application.Handlers.BackofficeHandlers
{
    public class DisableBookByAuthorHandler : IRequestHandler<DisableBookByAuthorRequest, Unit>
    {
        private readonly MySqlContext _sqlcontext;

        public DisableBookByAuthorHandler(MySqlContext sqlcontext)
        {
            _sqlcontext = sqlcontext;
        }

        public async Task<Unit> Handle(DisableBookByAuthorRequest request, CancellationToken cancellationToken)
        {
            var booksByAuthor = _sqlcontext.Books.Where(x => x.Title == request.BookName && x.Author == request.Author && x.Active).ToList();

            var book = booksByAuthor.FirstOrDefault();

            if (book != null)
            {
                book.Active = false;
                _sqlcontext.SaveChanges();
            }

            return Unit.Value;
        }
    }
}
