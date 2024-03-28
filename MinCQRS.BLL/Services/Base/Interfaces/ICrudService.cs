namespace MinCQRS.BLL.Services.Base.Interfaces
{
    using LanguageExt.Common;
    using System.Collections.Generic;

    public interface ICrudService<TService, TModel>
    {
        Task<Result<ICollection<TModel>>> GetAll();
        Task<Result<TModel?>> GetById(int id, CancellationToken cancellationToken);
        Task<Result<TModel>> Create(TModel model, CancellationToken cancellationToken);
        Task Update(TModel model, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
    }
}
