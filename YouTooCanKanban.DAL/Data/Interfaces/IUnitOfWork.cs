using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace YouTooCanKanban.DAL.Data.Interfaces
{
    public interface IUnitOfWork
    {
        //IDbContextTransaction BeginTransaction();
        //void CommitTransaction();
        //void RollbackTransaction();

        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
        Task CommitTransactionAsync(CancellationToken cancellationToken);
        Task RollbackTransactionAsync(CancellationToken cancellationToken);
    }
}
