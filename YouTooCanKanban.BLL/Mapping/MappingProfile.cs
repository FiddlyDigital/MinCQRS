using AutoMapper;
using YouTooCanKanban.DAL.Entities;
using YouTooCanKanban.Domain.Models;

namespace YouTooCanKanban.BLL.Mapping
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WorkspaceModel, WorkspaceEntity>();
            CreateMap<BoardModel, BoardEntity>();
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
