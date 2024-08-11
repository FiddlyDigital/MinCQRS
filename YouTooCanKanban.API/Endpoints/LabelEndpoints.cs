using YouTooCanKanban.API.Constants;
using YouTooCanKanban.API.Endpoints.Base;
using YouTooCanKanban.Application.Handlers.UseCases.Label;
using YouTooCanKanban.Domain.Models;

namespace YouTooCanKanban.API.Endpoints
{
    public sealed class GetLabelListEndpoint : GetListEndpoint<GetLabelListQuery, LabelModel>, IEndpoint
    {
        public GetLabelListEndpoint() : base(Resources.Routes.Labels) { }
    }

    public sealed class GetLabelByIdEndpoint : GetByIdEndpoint<GetLabelByIdQuery, LabelModel>, IEndpoint
    {
        public GetLabelByIdEndpoint() : base(Resources.Routes.Labels) { }
    }

    public sealed class CreateLabelEndpoint : CreateEndpoint<CreateLabelCommand, LabelModel>, IEndpoint
    {
        public CreateLabelEndpoint() : base(Resources.Routes.Labels) { }
    }

    public sealed class UpdateLabelEndpoint : UpdateEndpoint<UpdateLabelCommand, LabelModel>, IEndpoint
    {
        public UpdateLabelEndpoint() : base(Resources.Routes.Labels) { }
    }

    public sealed class DeleteLabelEndpoint : DeleteEndpoint<DeleteLabelCommand, LabelModel>, IEndpoint
    {
        public DeleteLabelEndpoint() : base(Resources.Routes.Labels) { }
    }
}
