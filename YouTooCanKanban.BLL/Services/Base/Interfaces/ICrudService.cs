using LanguageExt.Common;

namespace YouTooCanKanban.BLL.Services.Base.Interfaces
{
    public interface ICrudService<TService, TModel>
    {
        Task<Result<IEnumerable<TModel>>> GetList(int pageIndex, int pageSize, string? sortBy, string? sortDir, string? filter);
        Task<Result<TModel?>> GetById(int id, CancellationToken cancellationToken);
        Task<Result<TModel>> Create(TModel model, CancellationToken cancellationToken);
        Task Update(TModel model, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
    }
}
