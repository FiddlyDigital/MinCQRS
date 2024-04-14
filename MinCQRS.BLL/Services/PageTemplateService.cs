using Microsoft.Extensions.Logging;
using MinCQRS.BLL.Services.Base;
using MinCQRS.BLL.Services.Base.Interfaces;
using MinCQRS.DAL.Entities;
using MinCQRS.DAL.Repos;
using MinCQRS.Domain.Models;

namespace MinCQRS.BLL.Services
{
    public interface IPageTemplateService : ICrudService<SettingGroupService, PageTemplateModel>
    {

    }

    public sealed class PageTemplateService : CRUDService<PageTemplateService, PageTemplateModel, PageTemplateEntity>, IPageTemplateService
    {
        public PageTemplateService(ILogger<PageTemplateService> logger, IPageTemplateRepo repository) : base(logger, repository)
        {

        }
    }
}
