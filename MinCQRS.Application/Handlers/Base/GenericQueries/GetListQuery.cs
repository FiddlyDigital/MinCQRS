using LanguageExt.Common;
using MinCQRS.Application.Handlers.Base.Interfaces;

namespace MinCQRS.Application.Handlers.Base.GenericQueries
{
    public abstract class GetListQuery<TModel> : IQuery<Result<IEnumerable<TModel>>>
    {
        public GetListQuery() { }

        public GetListQuery(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
