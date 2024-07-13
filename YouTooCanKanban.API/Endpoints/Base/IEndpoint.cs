using YouTooCanKanban;
using YouTooCanKanban.API;
using YouTooCanKanban.API.Endpoints;
using YouTooCanKanban.API.Endpoints.Base;

namespace YouTooCanKanban.API.Endpoints.Base
{
    public interface IEndpoint
    {
        void MapEndpoint(IEndpointRouteBuilder app);
    }
}
