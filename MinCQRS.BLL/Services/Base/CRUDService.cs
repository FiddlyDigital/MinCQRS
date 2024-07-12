using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using MinCQRS.BLL.Services.Base.Interfaces;
using MinCQRS.DAL.Data.Interfaces;
using MinCQRS.DAL.Entities.Base;
using MinCQRS.Domain.Exceptions;
using MinCQRS.Domain.Extensions;
using MinCQRS.Domain.Models.Base;
using System.Globalization;

namespace MinCQRS.BLL.Services.Base
{
    public abstract class CRUDService<TService, TModel, TEntity> : BaseService<TService>, ICrudService<TService, TModel>
        where TService : BaseService<TService>
        where TModel : BaseModel
        where TEntity : BaseEntity
    {
        protected readonly IBaseRepository<TEntity> _repository;

        // TODO: IncludedProperties(Entities) string[]

        public CRUDService(ILogger<TService> logger, IBaseRepository<TEntity> repository) : base(logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Result<IEnumerable<TModel>>> GetList(int pageIndex, int pageSize, string? sortBy, string? sortDir, string? filter)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(pageIndex, 0);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(pageSize);

            try
            {
                IEnumerable<TEntity> entities = _repository.GetAll(pageIndex, pageSize, sortBy, sortDir, filter);
                IEnumerable<TModel> list = entities.MapTo<IEnumerable<TModel>>();
                return new Result<IEnumerable<TModel>>(list);
            }
            catch (Exception ex)
            {
                string errorMessage = $"Error getting list of {typeof(TModel).Name}";
                Logger.LogError(ex, errorMessage);
                return new Result<IEnumerable<TModel>>(new Exception(errorMessage, ex));
            }
        }

        public async Task<Result<TModel?>> GetById(int id, CancellationToken cancellationToken)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

            try
            {
                TEntity? entity = await GetFromRepoById(id, cancellationToken);
                TModel? item = entity.MapTo<TModel>();
                return new Result<TModel?>(item);
            }
            catch (Exception ex)
            {
                string errorMessage = $"Error getting the {typeof(TModel).Name} with id {id}";
                Logger.LogError(ex, errorMessage);
                return new Result<TModel?>(new Exception(errorMessage, ex));
            }
        }

        public async Task<Result<TModel>> Create(TModel model, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(model);
            ArgumentOutOfRangeException.ThrowIfNotEqual(model.Id, 0, $"When creating a new {typeof(TModel).Name}, it cannot have an existing Id value");

            try
            {
                TEntity modelAsEntity = model.MapTo<TEntity>();

                _repository.Add(modelAsEntity);
                await _repository.SaveChangesAsync(cancellationToken);

                model.Id = modelAsEntity.Id;
                return new Result<TModel>(model);
            }
            catch (Exception ex)
            {
                string errorMessage = $"Error creating {typeof(TModel).Name}";
                Logger.LogError(ex, errorMessage);
                return new Result<TModel>(new Exception(errorMessage, ex));
            }
        }

        public async Task Update(TModel model, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(model);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(model.Id);

            try
            {
                TEntity? entityToUpdate = model.MapTo<TEntity>();
                _repository.Update(entityToUpdate, cancellationToken);
                await _repository.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error updating {type} with Id of {id}", typeof(TModel).Name, model.Id);
            }
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

            try
            {
                _repository.Delete(id, cancellationToken);
                await _repository.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error deleting {type} with Id of {id}", typeof(TModel).Name, id);
            }
        }

        private async Task<TEntity> GetFromRepoById(int id, CancellationToken cancellationToken)
        {
            TEntity? entity = await _repository.GetById(id, cancellationToken);
            if (entity is null)
            {
                throw new NotFoundException(id.ToString(CultureInfo.InvariantCulture), typeof(TModel).Name);
            }

            return entity;
        }
    }
}
