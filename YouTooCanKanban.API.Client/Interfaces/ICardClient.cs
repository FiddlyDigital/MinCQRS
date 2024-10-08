using Refit;
using YouTooCanKanban.API.Client.Models;
using YouTooCanKanban.Domain.Models;

namespace YouTooCanKanban.API.Client.Interfaces
{
    public interface ICardsClient : IApiClient<CardModel>
    {
        [Get("/api/v1/Cards")]
        new Task<IEnumerable<CardModel>> GetList(GetListParams getListParams);

        [Get("/api/v1/Cards/{CardId}")]
        new Task<CardModel> GetById(int CardId);

        [Post("/api/v1/Cards/")]
        new Task<CardModel> Create([Body] CardModel newCard);

        [Put("/api/v1/Cards/{CardId}")]
        new Task Update(int CardId, [Body] CardModel updatedCard);

        [Delete("/api/v1/Cards/{CardId}")]
        new Task Delete(int CardId);
    }
}
