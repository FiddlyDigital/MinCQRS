using YouTooCanKanban.API.Client.Interfaces;
using YouTooCanKanban.Domain.Models;
using YouTooCanKanban.WASMUI.Services.Data.Base;

namespace YouTooCanKanban.WASMUI.Services.Data
{
    public interface ICardsDataService : ICRUDDataService<CardModel> { }

    public sealed class CardsDataService : CRUDDataService<CardsDataService, ICardsClient, CardModel>, ICardsDataService
    {
        public CardsDataService(
            ICardsClient client,
            ILogger<CardsDataService> logger
        ) : base(client, logger)
        {
        }
    }
}
