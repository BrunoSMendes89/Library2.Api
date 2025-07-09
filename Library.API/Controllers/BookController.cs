using Application.Models;
using Application.Models.BooksControllerModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/v1/book")]
    public class BookController : ControllerBase
    {
        protected readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost()]
        public async Task<BaseResponse> PostBookAsync([FromBody] InsertBookRequest request)
        {
            try
            {
                return await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        [HttpGet("/by-author/{author}")]
        public async Task<List<GetBooksByAuthorResponse>> GetByAuthorAsync(string author)
        {
            try
            {
                var request = new GetBooksByAuthorRequest { Author = author };
                var response = await _mediator.Send(request);

                return response;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
