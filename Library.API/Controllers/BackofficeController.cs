using Application.Models;
using Application.Models.BackofficeControllerModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[Route("api/v1/backoffice")]
public class BackofficeController : ControllerBase
{
    protected readonly IMediator _mediator;

    public BackofficeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPut("disable-book-by-name")]
    public async Task<Unit> DisableBookAsync(string bookName, string author)
    {
        var request  = new DisableBookByAuthorRequest { BookName = bookName, Author = author };
        try
        {
            return await _mediator.Send(request);
        }
        catch (Exception ex)
        {
            throw ex.InnerException;
        }
    }

    [HttpPut("enable-book-by-id")]
    public async Task<Unit> EnableBookAsync(int bookId)
    {
        var request = new EnableBookById { BookId = bookId };
        try
        {
            return await _mediator.Send(request);
        }
        catch (Exception ex)
        {
            throw ex.InnerException;
        }
    }

    [HttpGet("get-disabled-book-by-name")]
    public async Task<List<BookModels>> GetDisabledBookByNameAsync(string bookName)
    {
        var request = new GetBooksByNameRequest { Name = bookName };
        try
        {
            return await _mediator.Send(request);
        }
        catch (Exception ex)
        {
            throw ex.InnerException;
        }
    }
}

