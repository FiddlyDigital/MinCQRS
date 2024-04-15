using MinCQRS;
using MinCQRS.API;
using MinCQRS.API.Constants;
using MinCQRS.API.Endpoints;
using MinCQRS.API.Endpoints.Base;
using MinCQRS.Application.Handlers.Microsites;
using MinCQRS.Domain.Models;

namespace MinCQRS.API.Endpoints
{
    public sealed class GetMicrositeListEndpoint : GetListEndpoint<GetMicrositeListQuery, MicrositeModel>, IEndpoint
    {
        public GetMicrositeListEndpoint() : base(Resources.Routes.Microsites) { }
    }

    public sealed class GetMicrositeByIdEndpoint : GetByIdEndpoint<GetMicrositeByIdQuery, MicrositeModel>, IEndpoint
    {
        public GetMicrositeByIdEndpoint() : base(Resources.Routes.Microsites) { }
    }
}
