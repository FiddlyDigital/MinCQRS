﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using MinCQRS.DAL.Entities.Base;
using MinCQRS.DAL.Data.Interfaces;

namespace MinCQRS.DAL.Data
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        

        public BaseRepository(DbContext context)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll(int pageIndex = 0, int pagesize = 25)
        {
            return _dbSet.Skip(pageIndex * pagesize).Take(pagesize);
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
            
            var existingEntity = await _dbSet.FindAsync([entity.Id], cancellationToken: cancellationToken);
            if (existingEntity is null)
            {
                throw new Exception($"{typeof(TEntity).Name} with id {entity.Id} does not exist to update.");
            }

            _dbSet.Update(entity);
        }

        public async void Delete(int id, CancellationToken cancellationToken = default)
        {
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(0, id);

            var existingEntity = await _dbSet.FindAsync([id], cancellationToken: cancellationToken);
            if (existingEntity is null) {
                throw new Exception($"{typeof(TEntity).Name} with id {id} does not exist to delete.");
            }

            _dbSet.Remove(existingEntity);
        }
        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            if (_context.ChangeTracker.HasChanges())
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

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
