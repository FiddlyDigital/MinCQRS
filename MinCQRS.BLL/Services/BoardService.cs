using Microsoft.Extensions.Logging;
using MinCQRS.BLL.Services.Base;
using MinCQRS.BLL.Services.Base.Interfaces;
using MinCQRS.DAL.Entities;
using MinCQRS.DAL.Repos;
using MinCQRS.Domain.Models;

namespace MinCQRS.BLL.Services
{
    public interface IBoardService : ICrudService<WorkspaceService, BoardModel>
    {

    }

    public sealed class BoardService : CRUDService<BoardService, BoardModel, BoardEntity>, IBoardService
    {
        public BoardService(ILogger<BoardService> logger, IBoardRepo repository) : base(logger, repository)
        {

        }
    }
}
