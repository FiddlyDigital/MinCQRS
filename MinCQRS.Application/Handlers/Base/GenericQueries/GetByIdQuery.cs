namespace MinCQRS.Application.Handlers.Base.GenericQueries
{
    using LanguageExt.Common;
    using MinCQRS.Application.Handlers.Base.Interfaces;

    public abstract class GetByIdQuery<T> : IQuery<Result<T>>
    {
        public GetByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
