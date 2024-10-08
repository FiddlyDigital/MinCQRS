using YouTooCanKanban.API.Client.Interfaces;
using YouTooCanKanban.API.Client.Models;
using YouTooCanKanban.Domain;
using YouTooCanKanban.Domain.Models.Base;

namespace YouTooCanKanban.WASMUI.Services.Base
{
    public abstract class CRUDDataService<TService, TAPIClient, TModel> : BaseService<TService>, ICRUDDataService<TModel>
        where TService : CRUDDataService<TService, TAPIClient, TModel>
        where TAPIClient : IApiClient<TModel>
        where TModel : BaseModel
    {
        protected readonly TAPIClient _client;

        protected CRUDDataService(
            TAPIClient client,
            ILogger<TService> logger
            ) : base(logger)
        {
            _client = client;
        }

        public async Task<IEnumerable<TModel>?> GetList(GetListParams getListParams)
        {
            try
            {
                return await _client.GetList(getListParams);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unable to get list");
                return null;
            }
        }

        public async Task<TModel?> GetById(int modelId)
        {
            try
            {
                return await _client.GetById(modelId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unable to get by Id");
                return null;
            }
        }

        public async Task<TModel?> CreateOrUpdate(TModel model)
        {
            try
            {
                if (model.Id > 0)
                {
                    await _client.Update(model.Id, model);
                    return model;
                }
                else
                {
                    return await _client.Create(model);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unable to Create Or Update");
                return null;
            }
        }

        public async Task Delete(int modelId)
        {
            try
            {
                await _client.Delete(modelId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unable to Delete");
            }
        }
    }
}
