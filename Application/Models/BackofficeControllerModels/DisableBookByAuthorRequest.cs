using MediatR;

namespace Application.Models.BackofficeControllerModels
{
    public class DisableBookByAuthorRequest : IRequest<Unit>
    {
        public string BookName { get; set; }
        public string Author { get; set; }
    }
}
