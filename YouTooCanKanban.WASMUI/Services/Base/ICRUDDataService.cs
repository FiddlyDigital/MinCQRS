using YouTooCanKanban.API.Client.Models;

namespace YouTooCanKanban.WASMUI.Services.Base
{
    public interface ICRUDDataService<TModel>
    {
        Task<TModel?> CreateOrUpdate(TModel model);
        Task Delete(int modelId);
        Task<TModel?> GetById(int modelId);
        Task<IEnumerable<TModel>?> GetList(GetListParams getListParams);
    }
}
