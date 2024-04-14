namespace MinCQRS.Application.Handlers.SettingsGroups.GetSettingGroups
{
    using LanguageExt.Common;
    using Microsoft.Extensions.Logging;
    using MinCQRS.Application.Handlers.Base;
    using MinCQRS.BLL.Services.Interfaces;
    using MinCQRS.Domain.Models;

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

//public abstract class GetListHandler<TService, TModel> : BaseQueryHandler<GetListHandler<TService, TModel>, GetListQuery<TModel>, ICollection<TModel>>
////where TService : ICrudService<TService, TModel>
////where TModel : BaseModel
//{
//    private readonly ICrudService<TService, TModel> _crudService;

//    public GetListHandler(
//        ILogger<GetListHandler<TService, TModel>> logger,
//        ICrudService<TService, TModel> crudService
//    ) : base(logger)
//    {
//        _crudService = crudService;
//    }

//    protected async override Task<Result<ICollection<TModel>>> Act(GetListQuery<TModel> request, CancellationToken cancellationToken)
//    {
//        return await _crudService.GetList(request.PageIndex, request.PageSize);
//    }
//}

//public sealed class GetSettingGroupHandlerNew : GetListHandler<ISettingGroupService, SettingGroupModel>
//{
//    public GetSettingGroupHandlerNew(
//        ILogger<GetSettingGroupHandlerNew> logger,
//        ISettingGroupService service) : base(logger, service) { }
//}