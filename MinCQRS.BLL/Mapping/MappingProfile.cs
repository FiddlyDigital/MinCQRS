namespace MinCQRS.BLL.Mapping
{
    using AutoMapper;
    using MinCQRS.DAL.Entities;
    using MinCQRS.Domain.Models;

    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SettingGroupModel, SettingGroupEntity>();
            //CreateMap<SettingModel, SettingModelEntity>();
        }

        private new void CreateMap<TSource, TDestination>()
        {
            IMappingExpression<TSource,TDestination> mappingExp = base.CreateMap<TSource, TDestination>();
            mappingExp.ForAllMembers(o => o.ExplicitExpansion());

            IMappingExpression<TDestination, TSource> mappingExpRev = base.CreateMap<TDestination, TSource>();
            mappingExpRev.ForAllMembers(o => o.ExplicitExpansion());
        }
    }
}
