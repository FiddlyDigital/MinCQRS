using LanguageExt.Common;
using YouTooCanKanban.Application.Handlers.Base.Interfaces;

namespace YouTooCanKanban.Application.Handlers.Base.GenericQueries
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
