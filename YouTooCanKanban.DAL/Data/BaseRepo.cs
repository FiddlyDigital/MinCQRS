using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using YouTooCanKanban.DAL.Data.Interfaces;
using YouTooCanKanban.DAL.Entities.Base;
using YouTooCanKanban.DAL.Enums;
using YouTooCanKanban.DAL.Models;
using static System.Linq.Expressions.Expression;

namespace YouTooCanKanban.DAL.Data
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

        public IEnumerable<TEntity> GetAll(int pageIndex = 0, int pagesize = 25, string? sortBy = null, string? sortDir = null, string? filter = null)
        {
            IQueryable<TEntity> query = _dbSet.AsQueryable<TEntity>().Where(x => !x.IsDeleted);

            // Props to https://github.com/raulshma/dotnet-dynamic-pagination-filtering-sorting 
            if (!string.IsNullOrEmpty(filter))
            {
                FilterParameters filterParameters = FilterParameters.Create(filter);
                if (!string.IsNullOrEmpty(filterParameters.FilterBy) &&
                    !string.IsNullOrEmpty(filterParameters.FilterValue) &&
                    !string.IsNullOrEmpty(filterParameters.FilterOperator))
                {
                    query = AddFilterClause(query, filterParameters.FilterBy!, filterParameters.FilterValue!, filterParameters.FilterOperator!);
                }
            }

            if (!string.IsNullOrEmpty(sortBy) && !string.IsNullOrEmpty(sortDir))
            {
                query = AddSortClause(query, sortBy!, sortDir!);
            }

            return query.Skip(pageIndex * pagesize).Take(pagesize);
        }

        public async Task<TEntity?> GetById(int id, CancellationToken cancellationToken = default, params string[] includeProperties)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

            TEntity? entity = null;

            if (includeProperties is not null && includeProperties.Any())
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

            entity.CreatedDate = DateTime.UtcNow;
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

            entity.UpdatedDate = DateTime.UtcNow;
            _dbSet.Update(entity);
        }

        public async void Delete(int id, CancellationToken cancellationToken = default)
        {
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0);

            var existingEntity = await _dbSet.FindAsync([id], cancellationToken: cancellationToken);
            if (existingEntity is null)
            {
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

        // https://github.com/raulshma/dotnet-dynamic-pagination-filtering-sorting/blob/main/PaginationFilteringSorting.Core/Helpers/QueryHelpers.cs
        private static IQueryable<TEntity> AddFilterClause<TEntity>(IQueryable<TEntity> query, string filterBy, string filterValue, string op = "eq")
        {
            var objectType = typeof(TEntity);
            var property = objectType.GetProperty(filterBy);

            if (property == null)
            {
                return query;
            }

            var propertyType = property.PropertyType;
            ParameterExpression prm = Parameter(objectType);

            var queryOp = op switch
            {
                "eq" => "Equals",
                "cont" => "Contains",
                _ => "Equals"
            };

            var prop = Property(prm, property);
            var method = propertyType.GetMethod(queryOp, [propertyType])!;

            Expression body = Call(
                prop,
                method,
                Constant(filterValue)
            );

            if (op == "ne")
            {
                body = Not(body);
            }

            Expression<Func<TEntity, bool>> expr = Lambda<Func<TEntity, bool>>(body, prm);
            if (expr != null)
            {
                query = query.Where(expr);
            }

            return query;
        }

        private static IQueryable<T> AddSortClause<T>(IQueryable<T> query, string sort, string sortBy)
        {
            var objectType = typeof(T);
            var property = objectType.GetProperty(sort);

            if (property == null)
            {
                return query;
            }

            var parameter = Parameter(objectType);
            var accessor = PropertyOrField(parameter, property.Name);

            var expr = Lambda<Func<T, object>>(accessor, parameter);

            if (sortBy == nameof(SortDirection.asc))
            {
                return query.OrderBy(expr);
            }
            else
            {
                return query.OrderByDescending(expr);
            }
        }
    }
}
