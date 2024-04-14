using Microsoft.Extensions.Logging;
using MinCQRS.BLL.Services.Base;
using MinCQRS.BLL.Services.Base.Interfaces;
using MinCQRS.DAL.Entities;
using MinCQRS.DAL.Repos;
using MinCQRS.Domain.Models;

namespace MinCQRS.BLL.Services
{
    public interface IPageService : ICrudService<SettingGroupService, PageModel>
    {

    }

    public sealed class PageService : CRUDService<PageService, PageModel, PageEntity>, IPageService
    {
        public PageService(ILogger<PageService> logger, IPageRepo repository) : base(logger, repository)
        {

        }
    }
}
