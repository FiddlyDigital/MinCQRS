using MediatR;

namespace MinCQRS.Application.Handlers.Base.Interfaces
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {

    }
}
