using Microsoft.Extensions.Logging;
using MinCQRS.BLL.Services.Base;
using MinCQRS.BLL.Services.Base.Interfaces;
using MinCQRS.DAL.Entities;
using MinCQRS.DAL.Repos;
using MinCQRS.Domain.Models;

namespace MinCQRS.BLL.Services
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
