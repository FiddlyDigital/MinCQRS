namespace MinCQRS.DAL.Data
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using MinCQRS.DAL.Entities.Base;
    using MinCQRS.DAL.Data.Interfaces;
    using System.Threading;

    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
            where TEntity : BaseEntity
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        

        public BaseRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<TEntity?> GetById(int id, CancellationToken cancellationToken = default, params string[] includeProperties)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

            TEntity? entity = null;

            if (includeProperties is not null && includeProperties.Length != 0)
            {
                entity = Find(e => e.Id == id, cancellationToken, includeProperties).SingleOrDefault();
            }
            else
            {
                entity = await _dbSet.FindAsync(id, cancellationToken);
            }

            return entity;
        }

        public void Add(TEntity entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            if (entity.Id != 0)
            {
                throw new ArgumentOutOfRangeException(nameof(entity), "Entities cannot be created with Ids greater than Zero.");
            }

            _dbSet.Add(entity);
        }

        public async void Update(TEntity entity, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(0, entity.Id);
            
            var existingEntity = await _dbSet.FindAsync(new object[] { entity.Id }, cancellationToken: cancellationToken);
            if (existingEntity is null)
            {
                throw new Exception($"{typeof(TEntity).Name} with id {entity.Id} does not exist to update.");
            }

            _dbSet.Update(entity);
        }

        public async void Delete(int id, CancellationToken cancellationToken = default)
        {
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(0, id);

            var existingEntity = await _dbSet.FindAsync(new object[] { id }, cancellationToken: cancellationToken);
            if (existingEntity is null) {
                throw new Exception($"{typeof(TEntity).Name} with id {id} does not exist to delete.");
            }

            _dbSet.Remove(existingEntity);
        }

        //public void SaveChanges()
        //{
        //    if (Context.ChangeTracker.HasChanges())
        //    {
        //        Context.SaveChanges();
        //    }
        //}

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            if (_context.ChangeTracker.HasChanges())
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        //public void RollbackSavedChanges()
        //{
        //    if (!Context.ChangeTracker.HasChanges())
        //    {
        //        return;
        //    }

        //    foreach (EntityEntry item in (IEnumerable<EntityEntry>)(
        //        from e in Context.ChangeTracker.Entries()
        //        where e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted
        //        select e).ToList())
        //    {
        //        item.State = EntityState.Detached;
        //    }
        //}

        protected IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken, params string[] includeProperties)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (includeProperties is not null && includeProperties.Length != 0)
            {
                IQueryable<TEntity> source = _dbSet.Where(predicate).AsQueryable();
                foreach (string navigationPropertyPath in includeProperties)
                {
                    source = source.Include(navigationPropertyPath);
                }

                return source;
            }

            return _dbSet.Where(predicate);
        }
    }
}
