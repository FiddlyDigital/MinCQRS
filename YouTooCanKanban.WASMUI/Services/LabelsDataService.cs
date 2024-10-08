using YouTooCanKanban.API.Client.Interfaces;
using YouTooCanKanban.Domain.Models;
using YouTooCanKanban.WASMUI.Services.Base;

namespace YouTooCanKanban.WASMUI.Services
{
    public interface ILabelsDataService : ICRUDDataService<LabelModel> { }

    public sealed class LabelsDataService : CRUDDataService<LabelsDataService, ILabelsClient, LabelModel>, ILabelsDataService
    {
        public LabelsDataService(
            ILabelsClient client,
            ILogger<LabelsDataService> logger
        ) : base(client, logger)
        {
        }
    }
}
