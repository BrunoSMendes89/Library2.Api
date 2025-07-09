using MediatR;

namespace Application.Models.BackofficeControllerModels
{
    public class GetBooksByNameRequest : IRequest<List<BookModels>>
    {
        public string Name { get; set; } = string.Empty;
    }
}
