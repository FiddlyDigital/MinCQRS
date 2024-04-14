using MinCQRS.DAL.Data;
using MinCQRS.DAL.Data.Interfaces;
using MinCQRS.DAL.Entities;

namespace MinCQRS.DAL.Repos
{
    public interface IElementTemplateRepo : IBaseRepository<ElementTemplateEntity> { }

    public sealed class ElementTemplateRepo : BaseRepository<ElementTemplateEntity>, IElementTemplateRepo
    {
        public ElementTemplateRepo(BaseDBContext context) : base(context)
        {
        }
    }
}
