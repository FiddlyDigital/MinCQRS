using MediatR;

namespace YouTooCanKanban.Application.Handlers.Base.Interfaces
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {

    }
}
