using Microsoft.Extensions.Logging;
using MinCQRS.BLL.Services.Base;
using MinCQRS.BLL.Services.Base.Interfaces;
using MinCQRS.DAL.Entities;
using MinCQRS.DAL.Repos;
using MinCQRS.Domain.Models;

namespace MinCQRS.BLL.Services
{
    public interface IElementService : ICrudService<SettingGroupService, ElementModel>
    {

    }

    public sealed class ElementService : CRUDService<ElementService, ElementModel, ElementEntity>, IElementService
    {
        public ElementService(ILogger<ElementService> logger, IElementRepo repository) : base(logger, repository)
        {

        }
    }
}
