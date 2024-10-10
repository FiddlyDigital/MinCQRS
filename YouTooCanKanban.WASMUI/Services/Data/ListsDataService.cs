using YouTooCanKanban.API.Client.Interfaces;
using YouTooCanKanban.Domain.Models;
using YouTooCanKanban.WASMUI.Services.Data.Base;

namespace YouTooCanKanban.WASMUI.Services.Data
{
    public interface IListsDataService : ICRUDDataService<ListModel> { }

    public sealed class ListsDataService : CRUDDataService<ListsDataService, IListsClient, ListModel>, IListsDataService
    {
        public ListsDataService(
            IListsClient client,
            ILogger<ListsDataService> logger
        ) : base(client, logger)
        {
        }
    }
}
