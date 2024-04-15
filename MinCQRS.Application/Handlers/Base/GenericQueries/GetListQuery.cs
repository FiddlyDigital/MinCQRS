namespace MinCQRS.Application.Handlers.Base.GenericQueries
{
    using LanguageExt.Common;
    using MinCQRS.Application.Handlers.Base.Interfaces;

    public abstract class GetListQuery<TModel> : IQuery<Result<ICollection<TModel>>>
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
