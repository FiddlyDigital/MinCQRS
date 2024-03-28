namespace MinCQRS.Application.Handlers.Base.Interfaces
{
    using MediatR;

    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
