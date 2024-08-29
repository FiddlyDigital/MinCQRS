using YouTooCanKanban.DAL.Data;
using YouTooCanKanban.DAL.Data.Interfaces;
using YouTooCanKanban.DAL.Entities;

namespace YouTooCanKanban.DAL.Repos
{
    public interface ILabelRepo : IBaseRepository<LabelEntity> { }

    public sealed class LabelRepo : BaseRepository<LabelEntity>, ILabelRepo
    {
        public LabelRepo(BaseDBContext context) : base(context) { }
    }
}
