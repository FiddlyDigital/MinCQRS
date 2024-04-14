using Microsoft.Extensions.Logging;
using MinCQRS.BLL.Services.Base;
using MinCQRS.BLL.Services.Base.Interfaces;
using MinCQRS.DAL.Entities;
using MinCQRS.DAL.Repos;
using MinCQRS.Domain.Models;

namespace MinCQRS.BLL.Services
{
    public interface IElementTemplateService : ICrudService<SettingGroupService, ElementTemplateModel>
    {
    }

    public sealed class ElementTemplateService : CRUDService<ElementTemplateService, ElementTemplateModel, ElementTemplateEntity>, IElementTemplateService
    {
        public ElementTemplateService(ILogger<ElementTemplateService> logger, IElementTemplateRepo repository) : base(logger, repository)
        {

        }
    }
}
