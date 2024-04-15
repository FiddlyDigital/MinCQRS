using MinCQRS;
using MinCQRS.API;
using MinCQRS.API.Endpoints;
using MinCQRS.API.Endpoints.Base;

namespace MinCQRS.API.Endpoints.Base
{
    public interface IEndpoint
    {
        void MapEndpoint(IEndpointRouteBuilder app);
    }
}
