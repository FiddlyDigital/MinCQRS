using Microsoft.Extensions.Logging;
using YouTooCanKanban.BLL.Services.Base;
using YouTooCanKanban.BLL.Services.Base.Interfaces;
using YouTooCanKanban.DAL.Entities;
using YouTooCanKanban.DAL.Repos;
using YouTooCanKanban.Domain.Models;

namespace YouTooCanKanban.BLL.Services
{
    public interface ILabelService : ICrudService<LabelService, LabelModel>
    {

    }

    public sealed class LabelService : CRUDService<LabelService, LabelModel, LabelEntity>, ILabelService
    {
        public LabelService(ILogger<LabelService> logger, ILabelRepo repository) : base(logger, repository)
        {

        }
    }
}
