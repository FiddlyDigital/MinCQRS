using Refit;
using YouTooCanKanban.API.Client.Models;

namespace YouTooCanKanban.API.Client.Interfaces
{
    public interface IApiClient<TModel>
    {
        Task<IEnumerable<TModel>> GetList(GetListParams getListParams);
        Task<TModel> GetById(int modelId);
        Task<TModel> Create([Body] TModel newModel);
        Task Update(int modelId, [Body] TModel updatedModel);
        Task Delete(int modelId);
    }
}
