using Microsoft.Extensions.Logging;
using YouTooCanKanban.BLL.Services.Base;
using YouTooCanKanban.BLL.Services.Base.Interfaces;
using YouTooCanKanban.DAL.Entities;
using YouTooCanKanban.DAL.Repos;
using YouTooCanKanban.Domain.Models;

namespace YouTooCanKanban.BLL.Services
{
    public interface IListService : ICrudService<WorkspaceService, ListModel>
    {

    }

    public sealed class ListService : CRUDService<ListService, ListModel, ListEntity>, IListService
    {
        public ListService(ILogger<ListService> logger, IListRepo repository) : base(logger, repository)
        {

        }
    }
}
