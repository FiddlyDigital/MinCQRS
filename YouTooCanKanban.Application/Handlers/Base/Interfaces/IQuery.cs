using MediatR;

namespace YouTooCanKanban.Application.Handlers.Base.Interfaces
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {

    }
}
