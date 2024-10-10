using YouTooCanKanban.API.Client.Interfaces;
using YouTooCanKanban.Domain.Models;
using YouTooCanKanban.WASMUI.Services.Data.Base;

namespace YouTooCanKanban.WASMUI.Services.Data
{
    public interface IBoardsDataService : ICRUDDataService<BoardModel> { }

    public sealed class BoardsDataService : CRUDDataService<BoardsDataService, IBoardsClient, BoardModel>, IBoardsDataService
    {
        public BoardsDataService(
            IBoardsClient client,
            ILogger<BoardsDataService> logger
        ) : base(client, logger)
        {
        }
    }
}
