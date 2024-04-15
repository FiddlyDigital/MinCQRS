using LanguageExt.Common;
using MinCQRS.Application.Handlers.Base.Interfaces;

namespace MinCQRS.Application.Handlers.Base.GenericQueries
{
    public abstract class GetByIdQuery<T> : IQuery<Result<T>>
    {
        public GetByIdQuery() { }

        public GetByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
