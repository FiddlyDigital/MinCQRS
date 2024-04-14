using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using MinCQRS.Application.Handlers.Base;
using MinCQRS.Application.Handlers.Base.GenericQueries;
using MinCQRS.BLL.Services;
using MinCQRS.Domain.Models;

namespace MinCQRS.Application.Handlers.SettingGroups
{
    public sealed class GetSettingGroupListQuery : GetListQuery<SettingGroupModel>
    {
        public GetSettingGroupListQuery(int pageIndex, int pageSize) : base(pageIndex, pageSize) { }
    }

    public sealed class GetSettingGroupListQueryValidator : AbstractValidator<GetSettingGroupListQuery>
    {
        public GetSettingGroupListQueryValidator()
        {
            RuleFor(x => x.PageIndex).GreaterThan(-1).LessThan(100);
            RuleFor(x => x.PageSize).GreaterThan(-1).LessThanOrEqualTo(50);
        }
    }

    public sealed class GetSettingGroupListHandler : BaseQueryHandler<GetSettingGroupListHandler, GetSettingGroupListQuery, ICollection<SettingGroupModel>>
    {
        private readonly ISettingGroupService settingGroupService;

        public GetSettingGroupListHandler(
            ILogger<GetSettingGroupListHandler> logger,
            ISettingGroupService settingGroupService
        ) : base(logger)
        {
            this.settingGroupService = settingGroupService;
        }

        protected async override Task<Result<ICollection<SettingGroupModel>>> Act(GetSettingGroupListQuery request, CancellationToken cancellationToken)
        {
            return await settingGroupService.GetList(request.PageIndex, request.PageSize);
        }
    }
}
