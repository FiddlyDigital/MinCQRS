using System.ComponentModel;
using LanguageExt.Common;
using YouTooCanKanban.Application.Handlers.Base.Interfaces;

namespace YouTooCanKanban.Application.Handlers.Base.GenericQueries
{
    public abstract class GetListQuery<TModel> : IQuery<Result<IEnumerable<TModel>>>
    {
        public GetListQuery() { }

        public GetListQuery(int pageIndex, int pageSize, string? sortby, string? sortDir, string? filter)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            SortBy = sortby;
            SortDir = sortDir;
            Filter = filter;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public string? SortBy { get; set; }
        public string? SortDir { get; set; }

        public string? Filter { get; set; }
    }
}
