using MinCQRS.DAL.Data;
using MinCQRS.DAL.Data.Interfaces;
using MinCQRS.DAL.Entities;

namespace MinCQRS.DAL.Repos
{
    public interface IPageTemplateRepo : IBaseRepository<PageTemplateEntity> { }

    public sealed class PageTemplateRepo : BaseRepository<PageTemplateEntity>, IPageTemplateRepo
    {
        public PageTemplateRepo(BaseDBContext context) : base(context)
        {

        }
    }
}
