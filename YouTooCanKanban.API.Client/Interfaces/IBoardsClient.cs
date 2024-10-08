using Refit;
using YouTooCanKanban.API.Client.Models;
using YouTooCanKanban.Domain.Models;

namespace YouTooCanKanban.API.Client.Interfaces
{
    public interface IBoardsClient: IApiClient<BoardModel>
    {
        [Get("/api/v1/boards")]
        new Task<IEnumerable<BoardModel>> GetList(GetListParams getListParams);

        [Get("/api/v1/boards/{boardId}")]
        new Task<BoardModel> GetById(int boardId);

        [Post("/api/v1/boards/")]
        new Task<BoardModel> Create([Body] BoardModel newBoard);

        [Put("/api/v1/boards/{boardId}")]
        new Task Update(int boardId, [Body] BoardModel updatedBoard);

        [Delete("/api/v1/boards/{boardId}")]
        new Task Delete(int boardId);
    }
}
