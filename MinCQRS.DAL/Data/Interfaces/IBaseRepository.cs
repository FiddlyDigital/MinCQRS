using MinCQRS.DAL.Entities.Base;

namespace MinCQRS.DAL.Data.Interfaces
{
    public interface IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        ICollection<TEntity> GetAll(int pageIndex, int pagesize);
        Task<TEntity?> GetById(int id, CancellationToken cancellationToken, params string[] includeProperties);
        void Add(TEntity entity);
        void Update(TEntity entity, CancellationToken cancellationToken);
        void Delete(int id, CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
