using Application.Models;
using Application.Models.BooksControllerModels;
using Domain.Entities;
using Mapster;
using MediatR;
using Persistence.Context;

namespace Application.Handlers.BooksHandlers
{
    public class InsertBooksHandler : IRequestHandler<InsertBookRequest, BaseResponse>
    {
        private readonly MySqlContext _sqlcontext;

        public InsertBooksHandler(MySqlContext sqlcontext)
        {
            _sqlcontext = sqlcontext;
        }

        public async Task<BaseResponse> Handle(InsertBookRequest request, CancellationToken cancellationToken)
        {
            var book = request.Adapt<Book>();

            var existingBook = _sqlcontext.Books
                .FirstOrDefault(x => x.Title == book.Title && x.Author == book.Author);

            if (existingBook != null && existingBook.Active)
            {
                return new BaseResponse { BookId = existingBook.BookId };
            }

            if (existingBook != null && !existingBook.Active)
            {
                existingBook.Active = true;
                _sqlcontext.Books.Update(existingBook);
                await _sqlcontext.SaveChangesAsync();
                return new BaseResponse { BookId = existingBook.BookId };
            }

            _sqlcontext.Books.Add(book);
            await _sqlcontext.SaveChangesAsync();

            return new BaseResponse { BookId = book.BookId };
        }
    }
}
