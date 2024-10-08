using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;
using YouTooCanKanban.API.Client.Models;
using YouTooCanKanban.Domain.Models;

namespace YouTooCanKanban.API.Client.Interfaces
{
    public interface ILabelsClient : IApiClient<LabelModel>
    {
        [Get("/api/v1/Labels")]
        new Task<IEnumerable<LabelModel>> GetList(GetListParams getListParams);

        [Get("/api/v1/Labels/{LabelId}")]
        new Task<LabelModel> GetById(int LabelId);

        [Post("/api/v1/Labels/")]
        new Task<LabelModel> Create([Body] LabelModel newLabel);

        [Put("/api/v1/Labels/{LabelId}")]
        new Task Update(int LabelId, [Body] LabelModel updatedLabel);

        [Delete("/api/v1/Labels/{LabelId}")]
        new Task Delete(int LabelId);
    }
}
