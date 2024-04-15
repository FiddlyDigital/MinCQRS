using MinCQRS.API.Constants;
using MinCQRS.API.Endpoints.Base;
using MinCQRS.Application.Handlers.Page;
using MinCQRS.Domain.Models;

namespace MinCQRS.API.Endpoints
{
    //public sealed class GetPageListEndpoint : GetListEndpoint<GetPageListQuery, PageModel>, IEndpoint
    //{
    //    public GetPageListEndpoint() : base(Resources.Routes.Pages) { }
    //}

    public sealed class GetPageByIdEndpoint : GetByIdEndpoint<GetPageByIdQuery, PageModel>, IEndpoint
    {
        public GetPageByIdEndpoint() : base(Resources.Routes.Pages) { }
    }
}
