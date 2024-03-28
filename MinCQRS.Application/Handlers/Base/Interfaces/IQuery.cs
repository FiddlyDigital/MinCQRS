namespace MinCQRS.Application.Handlers.Base.Interfaces
{
    using MediatR;

    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
