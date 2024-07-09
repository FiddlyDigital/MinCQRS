﻿using MinCQRS.DAL.Entities.Base;

namespace MinCQRS.DAL.Data.Interfaces
{
    public interface IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll(int pageIndex, int pagesize, string? sortBy, string? sortDir, string? filter);
        Task<TEntity?> GetById(int id, CancellationToken cancellationToken, params string[] includeProperties);
        void Add(TEntity entity);
        void Update(TEntity entity, CancellationToken cancellationToken);
        void Delete(int id, CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
