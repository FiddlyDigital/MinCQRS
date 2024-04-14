using LanguageExt.Common;

namespace MinCQRS.BLL.Services.Base.Interfaces
{
    public interface ICrudService<TService, TModel>
    {
        Task<Result<ICollection<TModel>>> GetList(int pageIndex, int pageSize);
        Task<Result<TModel?>> GetById(int id, CancellationToken cancellationToken);
        Task<Result<TModel>> Create(TModel model, CancellationToken cancellationToken);
        Task Update(TModel model, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
    }
}
