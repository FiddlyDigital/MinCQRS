namespace MinCQRS.DAL.Data.Interfaces
{
    using MinCQRS.DAL.Entities.Base;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity?> GetById(int id, CancellationToken cancellationToken, params string[] includeProperties);
        void Add(TEntity entity);
        void Update(TEntity entity, CancellationToken cancellationToken);
        void Delete(int id, CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);

        //void SaveChanges();
        //void RollbackSavedChanges();
    }
}
