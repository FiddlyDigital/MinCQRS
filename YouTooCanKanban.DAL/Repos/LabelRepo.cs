using YouTooCanKanban.DAL.Data;
using YouTooCanKanban.DAL.Entities;
using YouTooCanKanban.DAL.Repos.Base;

namespace YouTooCanKanban.DAL.Repos
{
    public interface ILabelRepo : IBaseRepository<LabelEntity> { }

    public sealed class LabelRepo : BaseRepository<LabelEntity>, ILabelRepo
    {
        public LabelRepo(BaseDBContext context) : base(context) { }
    }
}
