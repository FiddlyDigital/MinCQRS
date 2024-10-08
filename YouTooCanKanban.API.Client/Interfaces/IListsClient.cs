using Refit;
using YouTooCanKanban.API.Client.Models;
using YouTooCanKanban.Domain.Models;

namespace YouTooCanKanban.API.Client.Interfaces
{
    public interface IListsClient : IApiClient<ListModel>
    {
        [Get("/api/v1/Lists")]
        new Task<IEnumerable<ListModel>> GetList(GetListParams getListParams);

        [Get("/api/v1/Lists/{ListId}")]
        new Task<ListModel> GetById(int ListId);

        [Post("/api/v1/Lists/")]
        new Task<ListModel> Create([Body] ListModel newList);

        [Put("/api/v1/Lists/{ListId}")]
        new Task Update(int ListId, [Body] ListModel updatedList);

        [Delete("/api/v1/Lists/{ListId}")]
        new Task Delete(int ListId);
    }
}
