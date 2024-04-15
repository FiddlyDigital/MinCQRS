using MinCQRS.API.Constants;
using MinCQRS.API.Endpoints.Base;
using MinCQRS.Application.Handlers.PageTemplate;
using MinCQRS.Domain.Models;

namespace MinCQRS.API.Endpoints
{
    //public sealed class GetPageTemplateListEndpoint : GetListEndpoint<GetPageTemplateListQuery, PageTemplateModel>, IEndpoint
    //{
    //    public GetPageTemplateListEndpoint() : base(Resources.Routes.PageTemplates) { }
    //}

    public sealed class GetPageTemplateByIdEndpoint : GetByIdEndpoint<GetPageTemplateByIdQuery, PageTemplateModel>, IEndpoint
    {
        public GetPageTemplateByIdEndpoint() : base(Resources.Routes.PageTemplates) { }
    }
}
