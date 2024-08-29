using Microsoft.Extensions.Logging;
using YouTooCanKanban.BLL.Services.Base;
using YouTooCanKanban.BLL.Services.Base.Interfaces;
using YouTooCanKanban.DAL.Entities;
using YouTooCanKanban.DAL.Repos;
using YouTooCanKanban.Domain.Models;

namespace YouTooCanKanban.BLL.Services
{
    public interface IBoardService : ICrudService<WorkspaceService, BoardModel> { }

    public sealed class BoardService : CRUDService<BoardService, BoardModel, BoardEntity>, IBoardService
    {
        public BoardService(ILogger<BoardService> logger, IBoardRepo repository)
            : base(logger, repository) { }
    }
}
