using MediatR;

namespace Application.Models.BackofficeControllerModels;

public class EnableBookById : IRequest<Unit>
{
    public int BookId { get; set; }
}

