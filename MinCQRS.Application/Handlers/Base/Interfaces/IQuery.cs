using MediatR;

namespace MinCQRS.Application.Handlers.Base.Interfaces
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {

    }
}
